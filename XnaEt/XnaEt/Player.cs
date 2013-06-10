using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XnaEt
{
    public class Player : DrawableGameComponent
    {
        Texture2D texture;

        Texture2D links;
        Texture2D rechts;

        Texture2D left_neck_up;
        Texture2D right_neck_up;

        SpriteBatch sb;
        Point pos;

        int animation_speed = 4;
        int animation_count = 0;

        Point frameSize = new Point(33,30);
        Point currentFrame = new Point (0,0);


        public Point Position
        {
            get
            {
                return pos;
            }
            set
            {
                pos = value;
            }
        }

        int energy;

        public Player()
            : base(EtGame.instanz)
        {
            DrawOrder = 9999;
            pos = new Point(300, 200);
            energy = 9999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            links = Game.Content.Load<Texture2D>("left-run");
            rechts = Game.Content.Load<Texture2D>("right-run");
            texture = links;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            texture = links;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            //sb.Draw(texture, new Rectangle(pos.X, pos.Y, 32, 30), Color.White);
            //sb.Draw(
            sb.Draw(texture, new Vector2(pos.X, pos.Y), new Rectangle(
                    frameSize.X * currentFrame.X,
                    frameSize.Y * currentFrame.Y,
                    frameSize.X,
                    frameSize.Y),
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            sb.End();
        }

        public Point getPos()
        {
            return pos;
        }

        public void moveUp()
        {
            int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;

            

            for (int i = 0; i < speed; i++)
            {
                pos.Y--;
                energy--;
            }
        }

        public void moveLeft()
        {
            int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;
            texture = links;

            this.animate();

            for (int i = 0; i < speed; i++)
            {
                pos.X--;
                energy--;
            }
        }

        public void moveRight()
        {
            int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;
            texture = rechts;

            this.animate();

            for (int i = 0; i < speed; i++)
            {
                pos.X++;
                energy--;
            }
        }

        public void moveDown()
        {
            int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;

            for (int i = 0; i < speed; i++)
            {
                pos.Y++;
                energy--;
            }
        }

        public int getEnergy()
        {
            return energy;
        }

        private void animate()
        {
            if (animation_count++ % animation_speed == 0)
            {
                if (currentFrame.X++ > 1)
                    currentFrame.X = 0;
            }
        }
    }
}
