﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Scientist : Foe
    {
        public Scientist()
        {
            DrawOrder = 9999;

            pos = new Point(200, 150);
            frameSize = new Point(24, 55);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("scientist-run");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Vector2(pos.X + 64, pos.Y + 50), new Rectangle(
                    frameSize.X * currentFrame.X,
                    frameSize.Y * currentFrame.Y,
                    frameSize.X,
                    frameSize.Y),
                    Color.White, 0, Vector2.Zero, 1, foeEffect, 0);
            sb.End();
        }
    }
}
