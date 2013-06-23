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
        WorldElement world;
        string pitname;

        public XmlPit(string pitname = "forest") : base(pitname)
        {
            this.pitname = pitname;
            world = new WorldElement();

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
            XElement pit = world.getPitElement(pitname);
            return new XmlPit(pit.Element(direction).Attribute("ref").Value);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            XElement pit = world.getPitElement(pitname);
            EtGame.instanz.getScreen().setBgColor(getColor(pit.Element("outer_background").Value));
            EtGame.instanz.getScreen().setInnerBackground(getColor(pit.Element("inner_background").Value));
        }

        public override Pit getNorth()
        {
            return getPit("north");
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
            IEnumerable<XElement> pit = world.getPits(pitname);

            foreach (XElement pitfall in pit.Elements("pitfall"))
            {
                if (checkOnPit(pitfall, playerBox))
                {
                    string id = pitfall.Attribute("id").Value;
                    return Convert.ToInt16(id.Substring(1));
                }
            }

            return -1;
        }

        public override int checkPitFall(Rectangle playerBox)
        {
            return checkCollision(playerBox) ? whichPit(playerBox) : -1;
        }

        public override string ToString()
        {
            return pitname;
        }
    }
}
