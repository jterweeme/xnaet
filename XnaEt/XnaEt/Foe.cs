using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Foe : DrawableGameComponent
    {
        protected Texture2D texture;
        protected SpriteBatch sb;
        protected Point pos = new Point(100, 100);
        protected Point frameSize = new Point(32, 57);
        protected Point currentFrame = new Point(0, 0);

        protected Point et_pos = new Point(0,0);

        protected int animationSpeed = 12;
        protected int animationCount = 0;

        protected int runSpeed = 2;

        protected SpriteEffects foeEffect = SpriteEffects.None;


        public Foe()
            : base(EtGame.instanz)
        {
        }

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

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
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

        protected void goToET()
        {
            if (et_pos != null)
            {
                if (et_pos.X > pos.X)
                {
                    foeEffect = SpriteEffects.None;
                    pos.X++;
                }
                else
                {
                    foeEffect = SpriteEffects.FlipHorizontally;
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
