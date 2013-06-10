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
        SpriteBatch sb;
        Point pos;
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
            links = Game.Content.Load<Texture2D>("links");
            rechts = Game.Content.Load<Texture2D>("rechts");
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
            sb.Draw(texture, new Rectangle(pos.X, pos.Y, 32, 30), Color.White);
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
    }
}
