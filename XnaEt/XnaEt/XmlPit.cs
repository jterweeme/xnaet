using Microsoft.Xna.Framework;
using System.Linq;
using System.Xml.Linq;
using System.Collections.Generic;
using System;

namespace XnaEt
{
    public class XmlPit : Pit
    {
        static Zones zones;
        XElement world;
        string pitname;

        public XmlPit(string pitname = "forest") : base(pitname)
        {
            this.pitname = pitname;
            world = XElement.Load("world.xml");
            IEnumerable<XElement> pits = world.Elements();

            if (zones == null)
                zones = new Zones();
        }

        private Color getColor(string color)
        {
            System.Drawing.Color dinges = System.Drawing.ColorTranslator.FromHtml(color);
            return new Color(dinges.R, dinges.G, dinges.B, dinges.A);
        }

        public override Pit getPit(string direction)
        {
            var dinges = from nm in world.Elements("pit") where (string)nm.Attribute("id") == pitname select nm;
            Console.WriteLine(dinges.ElementAt<XElement>(0).Element(direction).Attribute("ref").Value);
            return new XmlPit(dinges.ElementAt<XElement>(0).Element(direction).Attribute("ref").Value);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            var dinges = from nm in world.Elements("pit") where (string)nm.Attribute("id") == pitname select nm;
            EtGame.instanz.getScreen().setBgColor(getColor(dinges.ElementAt<XElement>(0).Element("outer_background").Value));
            EtGame.instanz.getScreen().setInnerBackground(getColor(dinges.ElementAt<XElement>(0).Element("inner_background").Value));
        }

        public override int getZone(Point pos)
        {
            return zones.getZone(pos);
        }

        public bool checkOnPit(XElement pitfall, Rectangle playerBox)
        {
            return playerBox.Intersects(getRect(pitfall));
        }

        public Rectangle getRect(XElement pitfall)
        {
            int x = Convert.ToInt16(pitfall.Element("x").Value);
            int y = Convert.ToInt16(pitfall.Element("y").Value);
            int w = Convert.ToInt16(pitfall.Element("w").Value);
            int h = Convert.ToInt16(pitfall.Element("h").Value);
            return new Rectangle(x + 64, y + 58, w, h);
        }

        public int whichPit(Rectangle playerBox)
        {
            var pit = from nm in world.Elements("pit") where (string)nm.Attribute("id") == pitname select nm;

            foreach (XElement pitfall in pit.Elements("pitfall"))
                if (checkOnPit(pitfall, playerBox))
                    Console.WriteLine(getRect(pitfall));

            return -1;
        }

        public override int checkPitFall(Rectangle playerBox)
        {
            return checkCollision(playerBox) ? whichPit(playerBox) : -1;
        }
    }
}
