using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class FlowerPit : Pit
    {
        static Zones zones;

        public FlowerPit() : base("flowerpit")
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
        {   return new Forest();
        }

        public override Pit getWest()
        {   return new OlivePit();
        }

        public override Pit getEast()
        {   return new SnakePit();
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

        public int whichPit(Point pos)
        {
            if (pos.X < 240 && pos.Y < 120)
                return 5;

            if (pos.X > 240 && pos.Y < 120)
                return 6;

            if (pos.X < 240 && pos.Y > 120)
                return 7;

            if (pos.X > 240 && pos.Y > 120)
                return 8;

            return -1;
        }

        public override int checkPitFall(Point pos)
        {   return checkCollision2(pos) ? whichPit(pos) : -1;
        }

        public override int getZone(Point pos)
        {   return zones.getZone(pos);
        }
    }
}
