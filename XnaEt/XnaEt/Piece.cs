using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Piece : DrawableGameComponent
    {
        Texture2D texture;
        SpriteBatch sb;
        string asset;

        public Piece(string asset) : base(EtGame.instanz)
        {
            DrawOrder = 9999;
            this.asset = asset;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>(asset);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Rectangle(220, 240, 42, 42), Color.White);
            sb.End();
        }
    }
}
