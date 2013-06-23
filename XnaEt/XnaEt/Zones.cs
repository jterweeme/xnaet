using System;
using Microsoft.Xna.Framework;

namespace XnaEt
{
    public class Zones
    {
        int[] zones;

        public Zones()
        {
            Random random = new Random();
            zones = new int[16];

            zones[0] = CALLSHIP;
            zones[1] = PHONE_LOCATION;
            zones[2] = LANDING;

            for (int i = 3; i < 16; i++)
                zones[i] = random.Next(0, 12);
        }

        public const int TITLE = 0, CANDY_MUNCHING = 1, HUMAN_REPELLANT = 2, CALLSHIP = 3,
                        LANDING = 4, UP = 5, LEFT = 6, RIGHT = 7,
                        DOWN = 8, CALLELLIOT = 9, PITFALL = 10, PHONE_LOCATION = 11;

        public int getZone(Point pos)
        {
            int x = pos.X / (512 / 4);
            return zones[x];
        }

        public int getZone()
        {   return zones[0];
        }
    }
}
