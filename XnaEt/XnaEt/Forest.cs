using Microsoft.Xna.Framework;

namespace XnaEt
{
    public class Forest : Pit
    {
        static Zones zones;

        public Forest() : base("forest")
        {
            if (zones == null)
                zones = new Zones();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.CurrentScreen.setBgColor(new Color(0, 64, 0));
            background.SetData(new Color[] { new Color(82, 126, 45) });
        }

        public override Pit getNorth()
        {   return new TarPit();
        }

        public override Pit getWest()
        {   return new OlivePit();
        }

        public override Pit getEast()
        {   return new SnakePit();
        }

        public override Pit getSouth()
        {   return new FlowerPit();
        }

        public override int getZone(Point pos)
        {   return zones.getZone(pos);
        }
    }
}
