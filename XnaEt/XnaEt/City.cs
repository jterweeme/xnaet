using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class City : Pit
    {
        static Zones zones;

        public City() : base("city")
        {
            if (zones == null)
                zones = new Zones();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.CurrentScreen.setBgColor(new Color(0, 0, 96));
            background.SetData(new Color[] { new Color(45, 50, 184) });
        }

        public override Pit getNorth()
        {   return new FlowerPit();
        }

        public override Pit getWest()
        {   return new OlivePit();
        }

        public override Pit getEast()
        {   return new SnakePit();
        }

        public override Pit getSouth()
        {   return new TarPit();
        }

        public override PitFall getPitFall()
        {   return new PitFall(this);
        }

        public override int getZone(Point pos)
        {   return zones.getZone(pos);
        }
    }
}
