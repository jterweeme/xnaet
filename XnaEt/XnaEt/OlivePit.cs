using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

namespace XnaEt
{
    public class OlivePit : Pit
    {
        static Zones zone;

        public OlivePit() : base("olivepit")
        {
            if (zone == null)
                zone = new Zones();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.CurrentScreen.setBgColor(new Color(0, 64, 0));
            background.SetData(new Color[] { new Color(82, 126, 45) });
        }

        public override Pit getNorth()
        {   return new Forest();
        }

        public override Pit getWest()
        {   return new TarPit();
        }

        public override Pit getEast()
        {   return new FlowerPit();
        }

        public override Pit getSouth()
        {   return new City();
        }

        public override PitFall getPitFall()
        {   return new PitFall(this);
        }

        public override PitFall getPitFall(int pit)
        {
            return new PitFall(this, pit);
        }
        
        public bool checkCollision(Point pos)
        {   return checkCollision2(pos);
        }

        public int whichPit(Point pos)
        {
            if (pos.X < 240 && pos.Y < 100)
                return 1;

            if (pos.X > 240 && pos.Y < 100)
                return 2;

            if (pos.X < 240 && pos.Y > 100)
                return 3;

            if (pos.X > 240 && pos.Y > 100)
                return 4;

            return -1;
        }

        public override int checkPitFall(Point pos)
        {   return checkCollision(pos) ? whichPit(pos) : -1;
        }

        public override int getZone(Point pos)
        {   return zone.getZone(pos);
        }
    }
}
