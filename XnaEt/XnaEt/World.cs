using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;

namespace XnaEt
{
    public class World
    {
        private List<Pit> pits;

        public World()
        {
            pits = new List<Pit>();
            XElement worldFile = XElement.Load("world.xml");
            IEnumerable<XElement> pitElements = from nm in worldFile.Elements("pit") select nm;

            foreach (XElement pitElement in pitElements)
                pits.Add(new XmlPit(pitElement.Attribute("id").Value));
        }

        public Pit getPit(int i)
        {
            return pits[i];
        }

        public override string ToString()
        {
            string returnstring = null;

            foreach (Pit pit in pits)
                returnstring += pit.ToString() + "\n";

            return returnstring;
        }
    }
}
