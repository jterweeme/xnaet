using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class SnakePit : Pit
    {
        public SnakePit()
            : base("snakepit")
        {
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

        public override Pit getPitFall()
        {
            return new PitFall(this);
        }

        public override bool checkCollision(Point pos)
        {
            return (checkCollision2(pos));
        }

        public override int getZone()
        {
            return 1;
        }
    }
}
