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

        public Pit getPit(string pitname)
        {
            // moet nog beter
            switch (pitname)
            {
                case "forest":
                    return getPit(0);
                case "olivepit":
                    return getPit(1);
                case "flowerpit":
                    return getPit(2);
                case "snakepit":
                    return getPit(3);
                case "tarpit":
                    return getPit(4);
                case "city":
                    return getPit(5);
            }
            return null;
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
