using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class TarPit : Pit
    {
        public TarPit()
            : base("tarpit")
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
        {   return new SnakePit();
        }

        public override Pit getEast()
        {   return new OlivePit();
        }

        public override Pit getSouth()
        {   return new City();
        }
    }
}
