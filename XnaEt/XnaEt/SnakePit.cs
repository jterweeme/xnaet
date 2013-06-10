namespace XnaEt
{
    public class SnakePit : Pit
    {
        public SnakePit()
            : base("snakepit")
        {
        }

        public override Pit getNorth()
        {
            return new Forest();
        }

        public override Pit getWest()
        {
            return new FlowerPit();
        }

        public override Pit getEast()
        {
            return new TarPit();
        }

        public override Pit getSouth()
        {
            return new City();
        }
    }
}
