using System;
using System.Text;
using Microsoft.Xna.Framework;

namespace XnaEt
{
    public class PiecePlaces
    {
        int[] piecePlaatsen;

        public PiecePlaces()
        {
            piecePlaatsen = new int[20];    // er zijn 20 pits waar je in kan vallen

            // getLength oid moet nog
            for (int i = 0; i < 20; i++)
                piecePlaatsen[i] = 0;

            for (int i = 1; i <= 3; i++)
            {
                Random random = new Random();
                int x = random.Next(0, 19);

                while (piecePlaatsen[x] != 0)
                    x = random.Next(0, 19);

                piecePlaatsen[x] = i;
            }
        }

        public Piece getPieceFromPlace(int pitfall)
        {
            switch (piecePlaatsen[pitfall - 1])
            {
                case 1:
                    return new Piece("piece1");
                case 2:
                    return new Piece("piece2");
                case 3:
                    return new Piece("piece3");
            }
            return null;
        }

        public Piece fetchPieceFrom(int pitfall)
        {
            Piece piece = getPieceFromPlace(pitfall);
            piecePlaatsen[pitfall - 1] = 0;
            return piece;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            Array.ForEach(piecePlaatsen, x => builder.Append(x));
            return builder.ToString();
        }
    }
}
