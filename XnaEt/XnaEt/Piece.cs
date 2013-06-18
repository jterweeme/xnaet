using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Piece : DrawableGameComponent
    {
        Texture2D texture;
        SpriteBatch sb;
        Rectangle boundingBox;
        string asset;

        public Piece(string asset) : base(EtGame.instanz)
        {
            DrawOrder = 9999;
            this.asset = asset;
            boundingBox = new Rectangle(220, 240, 42, 42);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            texture = Game.Content.Load<Texture2D>(asset);
        }

        public Rectangle getBoundingBox()
        {
            return boundingBox;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, boundingBox, Color.White);
            sb.End();
        }
    }
}
