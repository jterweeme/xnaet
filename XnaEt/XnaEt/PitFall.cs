using Microsoft.Xna.Framework;
namespace XnaEt
{
    public class PitFall : Pit
    {
        // de pit van waar je in de kuil bent gevallen
        private Pit originalPit;
        private Piece piece;

        public PitFall(Pit originalPit) : base("pitfall")
        {   this.originalPit = originalPit;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.CurrentScreen.setBgColor(new Color(0, 0, 0));
            background.SetData(new Color[] { new Color(170, 170, 170) });
        }

        public void addPiece(Piece piece)
        {
            this.piece = piece;
            EtGame.instanz.Components.Add(piece);
        }

        public override Piece getPiece()
        {   return piece;
        }

        public override Pit getNorth()
        {   return originalPit;
        }

        public override Pit getWest()
        {   return originalPit;
        }

        public override Pit getEast()
        {   return originalPit;
        }

        public override Pit getSouth()
        {   return originalPit;
        }

        public override int getZone(Point pos)
        {   return Zones.PITFALL;
        }

        public override bool hasPiece()
        {   return (piece != null);
        }
    }
}
