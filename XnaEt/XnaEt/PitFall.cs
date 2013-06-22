using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

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

        public PitFall(Pit originalPit, int nummer) : base("pitfall")
        {
            this.originalPit = originalPit;
            this.nummer = nummer;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            EtGame.instanz.getScreen().setBgColor(new Color(0, 0, 0));
            EtGame.instanz.getScreen().setInnerBackground(new Color(170, 170, 170));
            SoundEffect sndFall = Game.Content.Load<SoundEffect>("fall");
            sndFall.Play();
        }

        public void addPiece(Piece piece)
        {
            this.piece = piece;
            EtGame.instanz.Components.Add(piece);
        }

        public override Piece getPiece()
        {   return piece;
        }

        public override int getZone(Point pos)
        {   return Zones.PITFALL;
        }

        public override bool hasPiece()
        {   return (piece != null);
        }

        public override void removePiece()
        {
            EtGame.instanz.Components.Remove(piece);
            piece = null;
        }
    }
}
