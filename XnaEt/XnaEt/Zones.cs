using System;

namespace XnaEt
{
    public class Zones
    {
        int zone;

        public Zones()
        {
            Random random = new Random();
            zone = random.Next(0, 10);
        }

        public const int TITLE = 0, CANDY_MUNCHING = 1, HUMAN_REPELLANT = 2, CALLSHIP = 3,
                        LANDING = 4,
                        UP = 5,
                        LEFT = 6,
                        RIGHT = 7,
                        DOWN = 8,
                        CALLELLIOT = 9,
                        PITFALL = 10;

        public int getZone()
        {
            return zone;
        }
    }
}
