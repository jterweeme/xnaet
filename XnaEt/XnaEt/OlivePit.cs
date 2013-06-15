using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
namespace XnaEt
{
    public class OlivePit : Pit
    {
        public OlivePit()
            : base("olivepit")
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
        {   return new TarPit();
        }

        public override Pit getEast()
        {   return new FlowerPit();
        }

        public override Pit getSouth()
        {   return new City();
        }
    }


}
