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

        bool freezeeVertical = false;
        bool freezeHorizontal = false;
        bool flightMode = false;
        bool inPit = false;
        bool flightReverse = false;

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

            left_neck_up = Game.Content.Load<Texture2D>("links");
            right_neck_up = Game.Content.Load<Texture2D>("right-neck-up");

            texture = links;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            if (!this.flightMode)
                texture = links;
            else
            {
                
                texture = left_neck_up;
                this.flightAnimate();
            }
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
                    Color.White, 0, Vector2.Zero, 1, SpriteEffects.None, 0);
            sb.End();
        }

        public Point getPos()
        {
            return pos;
        }

        public void moveUp()
        {
            if (!this.freezeeVertical)
            {
                int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;

                for (int i = 0; i < speed; i++)
                {
                    pos.Y--;
                    energy--;
                }
            }
        }

        public void moveLeft()
        {
            if (!this.freezeHorizontal)
            {
                int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;
                texture = links;

                this.animate(1);
                frameSize.Y = 30;

                for (int i = 0; i < speed; i++)
                {
                    pos.X--;
                    energy--;
                }
            }
        }

        public void moveRight()
        {
            if (!this.freezeHorizontal)
            {
                int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;
                texture = rechts;

                this.animate(1);
                frameSize.Y = 30;

                for (int i = 0; i < speed; i++)
                {
                    pos.X++;
                    energy--;
                }
            }
        }

        public void moveDown()
        {
            if (!this.freezeeVertical)
            {
                int speed = (Keyboard.GetState().IsKeyDown(Keys.LeftControl)) ? 3 : 1;

                for (int i = 0; i < speed; i++)
                {
                    pos.Y++;
                    energy--;
                }
            }
        }

        public int getEnergy()
        {
            return energy;
        }

        private void animate(int max_step)
        {
            if (animation_count++ % animation_speed == 0)
            {
                if (currentFrame.X++ > max_step)
                    currentFrame.X = 0;
            }
        }

        private void flightAnimate()
        {
            if (animation_count++ % 6 == 0)
            {
                if (!this.flightReverse && currentFrame.X > 4) 
                {
                    if(!this.inPit)
                        this.flightReverse = true;
                }
                else
                {
                    if(!this.flightReverse)
                        currentFrame.X++;
                }

                if (this.flightReverse && currentFrame.X == 0)
                {
                    // Finished with animation
                    this.freezeeVertical = false;
                    this.freezeHorizontal = false;
                    this.flightMode = false;

                    frameSize.Y = 30;
                    flightReverse = false;
                    this.pos.Y = this.pos.Y + 16;
                }
                else
                {
                    // Count down if it neccesarry
                    if(this.flightReverse)
                        currentFrame.X--;
                }
            }
        }

        public void setFlightMode(bool inPit)
        {
            this.inPit = inPit;

            if (!flightMode)
            {
                this.currentFrame.X = 0;

                texture = left_neck_up;
                this.frameSize.Y = 46;

                this.pos.Y -= 16;

                this.freezeeVertical = true;
                this.freezeHorizontal = true;
                this.flightMode = true;
            }
        }
    }
}
