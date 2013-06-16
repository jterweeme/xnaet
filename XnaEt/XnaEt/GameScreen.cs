using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XnaEt
{
    public class GameScreen : Screen
    {
        Player player;
        Pit currentPit;
        Agent agent;
        Scientist scientist;
        Elliot elliot;

        public Pit CurrentPit
        {
            get
            {
                return currentPit;
            }
            set
            {
                Game.Components.Remove(currentPit);
                currentPit = value;
                Game.Components.Add(value);
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            header.setZone(4);
        }

        protected override void LoadContent()
        {
            base.LoadContent();

            sb = new SpriteBatch(GraphicsDevice);
            player = new Player();
            currentPit = new Forest();
            agent = new Agent();
            elliot = new Elliot();
            scientist = new Scientist();

            EtGame.instanz.Components.Add(player);
            EtGame.instanz.Components.Add(currentPit);
            EtGame.instanz.Components.Add(agent);
            EtGame.instanz.Components.Add(elliot);
            EtGame.instanz.Components.Add(scientist);
        }

        public void goNorth()
        {
            CurrentPit = currentPit.getNorth();
            player.Position = new Point(300, 200);
        }

        public void goWest()
        {
            CurrentPit = currentPit.getWest();
            player.Position = new Point(300, 200);
        }

        public void goEast()
        {
            CurrentPit = currentPit.getEast();
            player.Position = new Point(300, 200);
        }

        public void goSouth()
        {
            CurrentPit = currentPit.getSouth();
            player.Position = new Point(300, 200);
        }

        public override void Update(GameTime gameTime)
        {

            base.Update(gameTime);

            footer.Text = player.getEnergy().ToString();

            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.Up))
            {
                player.moveUp();

                if (currentPit.checkCollision(player.getPos()))
                    System.Console.WriteLine("Collission!");
            }

            if (kb.IsKeyDown(Keys.Left))
                player.moveLeft();

            if (kb.IsKeyDown(Keys.Right))
                player.moveRight();

            if (kb.IsKeyDown(Keys.Down))
                player.moveDown();

            if (kb.IsKeyDown(Keys.LeftControl) && kb.GetPressedKeys().Length == 1)
                player.setFlightMode(false);

            if (player.getPos().Y < 5)
                goNorth();

            if (player.getPos().X < 5)
                goWest();

            if (player.getPos().X > 470)
                goEast();

            if (player.getPos().Y > 240)
                goSouth();
        }
    }
}
