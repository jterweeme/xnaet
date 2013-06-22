using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XnaEt
{
    public class World
    {
        XElement world;

        public World(string filename = "world.xml")
        {
            world = XElement.Load(filename);
        }

        public IEnumerable<XElement> getPits()
        {
            return (from nm in world.Elements("pit") select nm);
        }

        public IEnumerable<XElement> getPits(string pitname)
        {
            return (from nm in world.Elements("pit") where (string)nm.Attribute("id") == pitname select nm);
        }

        public XElement getPitElement(string pitname)
        {
            IEnumerable<XElement> pits = from nm in world.Elements("pit") where (string)nm.Attribute("id") == pitname select nm;
            return pits.ElementAt(0);
        }
    }
}
