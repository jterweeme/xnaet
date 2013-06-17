using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Agent : Foe
    {
        Point pos = new Point(100, 100);
        Point frameSize = new Point(32, 57);
        Point currentFrame = new Point(0, 0);

        Point et_pos;

        int animationSpeed = 12;
        int animationCount = 0;

        int runSpeed = 2;

        SpriteEffects agentEffect = SpriteEffects.None;


        public Point ETPosition
        {
            get
            {
                return et_pos;
            }
            set
            {
                et_pos = value;
            }
        }

        public Agent()
        {
            DrawOrder = 9999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("agent-et");
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
                    Color.White, 0, Vector2.Zero, 1, agentEffect, 0);
            sb.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if ((animationCount++ % animationSpeed) == 0)
            {
                if (currentFrame.X++ > 0)
                    currentFrame.X = 0;
            }

            if (animationCount % runSpeed == 0)
                this.goToET();
        }

        private void goToET()
        {
            if (et_pos != null)
            {
                if (et_pos.X > pos.X)
                {
                    agentEffect = SpriteEffects.None;
                    pos.X++;
                }
                else
                {
                    agentEffect = SpriteEffects.FlipHorizontally;
                    pos.X--;
                }

                if (et_pos.Y > pos.Y)
                {
                    pos.Y++;
                }
                else
                {
                    pos.Y--;
                }
            }
        }
    }
}
