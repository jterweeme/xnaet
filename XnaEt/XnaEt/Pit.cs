using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public abstract class Pit : DrawableGameComponent
    {
        protected int nummer;
        Texture2D dinges;
        protected Texture2D background;
        SpriteBatch sb;
        public abstract Pit getNorth();
        public abstract Pit getWest();
        public abstract Pit getEast();
        public abstract Pit getSouth();
        public abstract int getZone(Point pos);
        string asset;

        public Pit(string asset) : base(EtGame.instanz)
        {
            DrawOrder = 9998;
            this.asset = asset;
        }

        public int getNummer()
        {
            return nummer;
        }

        public virtual int checkPitFall(Point pos)
        {   return -1;
        }

        public virtual PitFall getPitFall()
        {   return null;
        }

        public virtual PitFall getPitFall(int pit)
        {   return null;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            dinges = Game.Content.Load<Texture2D>(asset);
            background = new Texture2D(GraphicsDevice, 1, 1);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(background, new Rectangle(64, 58, 512, 260), Color.White);
            sb.Draw(dinges, new Rectangle(64, 58, 512, 260), Color.White);
            sb.End();
        }

        protected bool checkCollision2(Point pos)
        {
            Color[] retrievedColor = new Color[700 * 500];
            Rectangle positie = new Rectangle(pos.X, pos.Y, 1, 1);
            dinges.GetData<Color>(0, positie, retrievedColor, 0, 1);
            return retrievedColor[0].A > 100;
        }

        public virtual bool hasPiece()
        {   return false;
        }

        public virtual void removePiece()
        {
        }

        public virtual Piece getPiece()
        {   return null;
        }
    }
}
