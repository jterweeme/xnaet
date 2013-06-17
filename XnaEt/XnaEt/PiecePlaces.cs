﻿using System;
using System.Text;

namespace XnaEt
{
    public class PiecePlaces
    {
        int[] piecePlaatsen;

        public PiecePlaces()
        {
            piecePlaatsen = new int[24];    // er zijn 24 pits waar je in kan vallen

            for (int i = 0; i < 24; i++)
                piecePlaatsen[i] = 0;

            for (int i = 1; i <= 3; i++)
            {
                Random random = new Random();
                int x = random.Next(0, 23);

                while (piecePlaatsen[x] != 0)
                    x = random.Next(0, 23);

                piecePlaatsen[x] = i;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            Array.ForEach(piecePlaatsen, x => builder.Append(x));
            return builder.ToString();
        }
    }
}
