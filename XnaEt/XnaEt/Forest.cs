using Microsoft.Xna.Framework;

namespace XnaEt
{
    public class Forest : Pit
    {
        public Forest()
            : base("forest")
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.CurrentScreen.setBgColor(new Color(0, 64, 0));
            background.SetData(new Color[] { Color.Red });
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
    }
}
