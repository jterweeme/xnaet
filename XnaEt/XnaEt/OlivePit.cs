using Microsoft.Xna.Framework;
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
        }

        public override Pit getNorth()
        {
            return new Forest();
        }

        public override Pit getWest()
        {
            return new TarPit();
        }

        public override Pit getEast()
        {
            return new FlowerPit();
        }

        public override Pit getSouth()
        {
            return new City();
        }
    }


}
