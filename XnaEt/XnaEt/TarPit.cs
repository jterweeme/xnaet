using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class TarPit : Pit
    {
        static Zones zones;

        public TarPit() : base("tarpit")
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
        {   return new SnakePit();
        }

        public override Pit getEast()
        {   return new OlivePit();
        }

        public override Pit getSouth()
        {   return new City();
        }

        public override Pit getPitFall()
        {   return new PitFall(this);
        }

        public bool checkCollision(Point pos)
        {   return checkCollision2(pos);
        }

        public int whichPit(Point pos)
        {
            if (pos.X < 180)
                return 17;

            if (pos.X > 240 && pos.X < 400 && pos.Y < 100)
                return 18;

            if (pos.X < 240 && pos.X < 400 && pos.Y > 100)
                return 19;

            if (pos.X > 400)
                return 20;

            return -1;
        }

        public override int checkPitFall(Point pos)
        {
            return checkCollision(pos) ? whichPit(pos) : -1;
        }

        public override int getZone(Point pos)
        {   return zones.getZone(pos);
        }
    }
}
