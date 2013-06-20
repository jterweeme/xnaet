using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Elliott : Foe
    {
        public bool endScreen = false;
        private bool runLeft = true;

        public Elliott()
        {
            DrawOrder = 10001;
            pos = new Point(200, 50);
            frameSize = new Point(16, 38);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("elliott-run");
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

        public override void Update(GameTime gameTime)
        {
            if (!endScreen)
            {
                base.Update(gameTime);
            }
            else
            {
                if ((animationCount++ % animationSpeed) == 0)
                {
                    if (currentFrame.X++ > 0)
                        currentFrame.X = 0;
                }

                this.pos.Y = 70;
                if (runLeft)
                {
                    this.pos.X -= 1;
                }
                else
                {
                    this.pos.X += 1;
                }

                // Check for way
                if (this.pos.X > 350)
                {
                    runLeft = true;
                    foeEffect = SpriteEffects.FlipHorizontally;
                }
                else if (this.pos.X < 150)
                {
                    runLeft = false;
                    foeEffect = SpriteEffects.None;
                }
            }
            
        }
    }
}
