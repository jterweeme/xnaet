using System.Collections.Generic;
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
        Rectangle boundingBox;
        List<Piece> items;
        int animation_speed = 4;
        int animation_count = 0;
        bool freezeeVertical = false;
        bool freezeHorizontal = false;
        bool flightMode = false;
        bool inPit = false;
        bool flightReverse = false;
        Point frameSize = new Point(33,30);
        Point currentFrame = new Point (0,0);
        int energy;
        GameScreen gameScreen;

        public Player() : this(null)
        {
        }

        public Player(GameScreen gameScreen) : base(EtGame.instanz)
        {
            this.gameScreen = gameScreen;
            items = new List<Piece>();
            boundingBox = new Rectangle(300, 200, 33, 30);
            DrawOrder = 9999;
            pos = new Point(300, 200);
            energy = 9999;
        }

        public Rectangle getBoundingBox()
        {
            return boundingBox;
        }

        public void addPiece(Piece piece)
        {
            items.Add(piece);
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
            {
                texture = links;

                if (this.inPit && this.pos.Y < 206 && !this.flightMode)
                {
                    this.pos.Y += 1;

                    if (!this.freezeeVertical)
                        this.freezeeVertical = true;

                    if (!this.freezeHorizontal)
                        this.freezeHorizontal = true;
                }
                else
                {
                    this.freezeHorizontal = false;
                }
            }
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
            Rectangle frame = new Rectangle(frameSize.X * currentFrame.X, frameSize.Y * currentFrame.Y, frameSize.X, frameSize.Y);
            boundingBox = new Rectangle(pos.X + 64, pos.Y + 50, frameSize.X, frameSize.Y);
            sb.Draw(texture, boundingBox, frame, Color.White, 0, Vector2.Zero, SpriteEffects.None, 0);
            sb.End();
        }

        public Point getPos()
        {
            return pos;
        }

        public void setPos(Point pos)
        {
            this.pos = pos;
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
                    if (!this.inPit || (this.inPit && pos.X > 130))
                    {
                        pos.X--;
                        energy--;
                    }
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
                    if (!this.inPit || (this.inPit && pos.X < 350))
                    {
                        pos.X++;
                        energy--;
                    }
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
                if (currentFrame.X++ > max_step)
                    currentFrame.X = 0;
        }

        private void flightAnimate()
        {
            if (animation_count++ % 6 == 0)
            {
                if (!this.flightReverse && currentFrame.X > 4) 
                {
                    if (!this.inPit)
                    {
                        this.flightReverse = true;
                        gameScreen.action();
                    }

                    if (this.freezeeVertical)
                        this.freezeeVertical = false;
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

        public void setFlightMode()
        {
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
            else
            {
                this.flightReverse = true;
            }
        }

        public void setPitLocation(bool inPit)
        {
            this.inPit = inPit;
        }

        public List<Piece> getItems()
        {
            return items;
        }
    }
}
