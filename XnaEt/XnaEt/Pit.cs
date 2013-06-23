using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.IO;

namespace XnaEt
{
    public abstract class Pit : DrawableGameComponent
    {
        protected int nummer;
        Texture2D dinges;
        protected SpriteBatch sb;
        public abstract Pit getNorth();
        public abstract int getZone(Point pos);
        string asset;

        public virtual void blink(PiecePlaces piecePlaces)
        {
        }

        public virtual Pit getPit(string direction)
        {
            return null;
        }

        public virtual void setBackground()
        {
        }

        public Pit(string asset) : base(EtGame.instanz)
        {
            DrawOrder = 9998;
            this.asset = asset;
        }

        public int getNummer()
        {
            return nummer;
        }

        public virtual int checkPitFall(Rectangle rect)
        {   
            return -1;
        }

        public virtual PitFall getPitFall()
        {   
            return null;
        }

        public virtual PitFall getPitFall(int pit)
        {   
            return null;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            dinges = Texture2D.FromStream(GraphicsDevice, File.OpenRead(asset + ".png"));
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(dinges, new Rectangle(64, 58, 512, 260), Color.White);
            sb.End();
        }

        protected bool checkCollision(Rectangle playerBox)
        {
            Color[] retrievedColor = new Color[700 * 500];
            Rectangle positie = new Rectangle(playerBox.X - 64, playerBox.Y - 50, 1, 1);
            dinges.GetData<Color>(0, positie, retrievedColor, 0, 1);
            return retrievedColor[0].A > 100;
        }

        public virtual bool hasPiece()
        {   
            return false;
        }

        public virtual void removePiece()
        {
        }

        public virtual Piece getPiece()
        {   
            return null;
        }
    }
}
