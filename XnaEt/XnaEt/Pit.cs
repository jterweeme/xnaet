using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public abstract class Pit : DrawableGameComponent
    {
        Texture2D dinges;
        SpriteBatch sb;
        string asset;

        public Pit(string asset)
            : base(EtGame.instanz)
        {
            DrawOrder = 9998;
            this.asset = asset;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            dinges = Game.Content.Load<Texture2D>(asset);
        }

        public abstract Pit getNorth();
        public abstract Pit getWest();
        public abstract Pit getEast();
        public abstract Pit getSouth();

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(dinges, new Rectangle(64, 58, 512, 260), Color.White);
            sb.End();
        }
    }
}
