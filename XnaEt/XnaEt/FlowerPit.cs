using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class FlowerPit : Pit
    {
        public FlowerPit()
            : base("flowerpit")
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
        {   return new OlivePit();
        }

        public override Pit getEast()
        {   return new SnakePit();
        }

        public override Pit getSouth()
        {   return new City();
        }

        public override Pit getPitFall()
        {
            return new PitFall(this);
        }
    }
}
