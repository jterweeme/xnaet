using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class SnakePit : Pit
    {
        static Zones zones;

        public SnakePit() : base("snakepit")
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
        {   return new FlowerPit();
        }

        public override Pit getEast()
        {   return new TarPit();
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
            if (pos.X < 240 && pos.Y < 120)
                return 9;

            if (pos.X > 240 && pos.Y < 120)
                return 10;

            if (pos.X < 240 && pos.Y > 120)
                return 11;

            if (pos.X > 240 && pos.Y > 120)
                return 12;

            if (pos.X < 240 && pos.Y < 120)
                return 13;

            if (pos.X > 240 && pos.Y < 120)
                return 14;

            if (pos.X < 240 && pos.Y > 120)
                return 15;

            if (pos.X > 240 && pos.Y > 120)
                return 16;

            return -1;
        }

        public override int checkPitFall(Point pos)
        {   return checkCollision(pos) ? whichPit(pos) : -1;
        }

        public override int getZone(Point pos)
        {   return zones.getZone(pos);
        }
    }
}
