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

        private Pit getPit(string direction)
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

        public override Pit getNorth()
        {
            return getPit("north");
        }

        public override Pit getWest()
        {
            return getPit("west");
        }

        public override Pit getEast()
        {
            return getPit("east");
        }

        public override Pit getSouth()
        {
            return getPit("south");
        }

        public override int getZone(Point pos)
        {
            return zones.getZone(pos);
        }
    }
}
