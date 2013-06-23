using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
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
        TimeSpan blinkStart;
        Rectangle blinkRect;
        GameTime currentGameTime;
        

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
            return EtGame.instanz.getWorld().getPit(pit.Element(direction).Attribute("ref").Value);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            setBackground();
        }

        public override void setBackground()
        {
            XElement pit = world.getPitElement(pitname);
            EtGame.instanz.getScreen().setBgColor(getColor(pit.Element("outer_background").Value));
            EtGame.instanz.getScreen().setInnerBackground(getColor(pit.Element("inner_background").Value));
        }

        public override Pit getNorth()
        {
            return getPit("north");
        }

        public override void blink(PiecePlaces piecePlaces)
        {
            XElement pit = world.getPitElement(pitname);

            foreach (XElement pitfall in pit.Elements("pitfall"))
            {
                string id = pitfall.Attribute("id").Value;
                int nr = Convert.ToInt16(id.Substring(1));

                if (piecePlaces.hasPiece(nr))
                {
                    blinkRect = getRect(pitfall);
                    blinkStart = currentGameTime.TotalGameTime;

                }
            }
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

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            currentGameTime = gameTime;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            Texture2D dot = new Texture2D(GraphicsDevice, 1, 1);
            dot.SetData(new Color[] { Color.Coral });

            if (gameTime.TotalGameTime - blinkStart < new TimeSpan(0, 0, 1))
            {
                System.Console.WriteLine(blinkStart);
                sb.Begin();
                sb.Draw(dot, new Rectangle(blinkRect.X + blinkRect.Width / 2, blinkRect.Y + blinkRect.Height / 2, 14, 4), Color.White);
                sb.End();
            }
        }
    }
}
