using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XnaEt
{
    public class GameScreen : Screen
    {
        PiecePlaces piecePlaces;
        Player player;
        Pit currentPit;
        Agent agent;
        Scientist scientist;
        Elliot elliot;
        bool ctrlKeyActive = false;

        public GameScreen()
        {
            piecePlaces = new PiecePlaces();
            System.Console.Error.WriteLine(piecePlaces);
        }

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
                //System.Console.Error.WriteLine(value);
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

        private void goNorth()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            CurrentPit = currentPit.getNorth();
            player.Position = new Point(player.getPos().X, 200);
        }

        private void goWest()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            CurrentPit = currentPit.getWest();
            player.Position = new Point(460, player.getPos().Y);
        }

        private void goEast()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            CurrentPit = currentPit.getEast();
            player.Position = new Point(20, player.getPos().Y);
        }

        private void goSouth()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            CurrentPit = currentPit.getSouth();
            player.Position = new Point(player.getPos().X, 15);
        }

        public void goPitFall()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.Position = new Point(250, 40);
            player.setPitLocation(true);
            CurrentPit = currentPit.getPitFall();
            header.setZone(10);
        }

        public void goPitFall(Point pos)
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.Position = new Point(250, 40);
            player.setPitLocation(true);
            CurrentPit = currentPit.getPitFall();
            header.setZone(10);
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            header.setZone((int)currentPit.getZone(player.getPos()));
            footer.Text = player.getEnergy().ToString();
            KeyboardState kb = Keyboard.GetState();
            int pit;

            if ((pit = currentPit.checkPitFall(player.getPos())) >= 0)
                goPitFall(player.getPos());

            if (kb.IsKeyDown(Keys.Up))
                player.moveUp();

            if (kb.IsKeyDown(Keys.Left))
                player.moveLeft();

            if (kb.IsKeyDown(Keys.Right))
                player.moveRight();

            if (kb.IsKeyDown(Keys.Down))
                player.moveDown();

            if (kb.IsKeyDown(Keys.LeftControl) && kb.GetPressedKeys().Length == 1 && !this.ctrlKeyActive)
            {
                player.setFlightMode();
                this.ctrlKeyActive = true;
            }

            if (player.getPos().Y < 5)
                goNorth();

            if (player.getPos().X < 5)
                goWest();

            if (player.getPos().X > 470)
                goEast();

            if (player.getPos().Y > 240)
                goSouth();

            if (kb.IsKeyUp(Keys.LeftControl))
                this.ctrlKeyActive = false;

            // Give the Agent the acutal position of ET
            agent.ETPosition = player.Position;
        }
    }
}
