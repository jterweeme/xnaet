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
        }

        public override Pit getNorth()
        {
            return new Forest();
        }

        public override Pit getWest()
        {
            return new OlivePit();
        }

        public override Pit getEast()
        {
            return new SnakePit();
        }

        public override Pit getSouth()
        {
            return new City();
        }
    }
}
