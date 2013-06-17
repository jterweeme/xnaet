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

        public override Pit getPitFall()
        {
            return new PitFall(this);
        }

        public override bool checkCollision(Point pos)
        {   return checkCollision2(pos);
        }

        public override int checkPitFall(Point pos)
        {   return checkCollision(pos) ? 1 : -1;
        }

        public override int getZone(Point pos)
        {   return zone.getZone(pos);
        }
    }
}
