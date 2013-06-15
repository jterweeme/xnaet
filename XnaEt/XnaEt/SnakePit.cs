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
            background.SetData(new Color[] { Color.Green });
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
    }
}
