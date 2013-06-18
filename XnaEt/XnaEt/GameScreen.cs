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
        Elliott elliot;
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
                setCurrentPit(value);
            }
        }

        public void setCurrentPit(Pit pit)
        {
            Game.Components.Remove(currentPit);
            currentPit = pit;
            Game.Components.Add(pit);
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
            elliot = new Elliott();
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

        public void goPitFall(int pit)
        {
            //System.Console.Error.WriteLine(pit);
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.Position = new Point(250, 40);
            player.setPitLocation(true);
            PitFall dePit = currentPit.getPitFall(pit);
            System.Console.Error.WriteLine(dePit.getNummer());
            Piece piece = piecePlaces.getPieceFromPlace(pit);

            if (piece != null)
                dePit.addPiece(piece);

            CurrentPit = dePit;
            header.setZone(10);
        }

        public void findPiece()
        {
            if (currentPit.hasPiece())
            {
                Piece piece = currentPit.getPiece();
                if (player.getBoundingBox().Intersects(piece.getBoundingBox()))
                {
                    System.Console.Error.WriteLine("Bingo!");
                    player.addPiece(piecePlaces.fetchPieceFrom(currentPit.getNummer()));
                    currentPit.removePiece();
                    System.Console.Error.WriteLine(piecePlaces);
                    header.setPieces(player.getItems().Count);
                }
            }
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            header.setZone((int)currentPit.getZone(player.getPos()));
            footer.Text = player.getEnergy().ToString();
            KeyboardState kb = Keyboard.GetState();
            int pit;

            if ((pit = currentPit.checkPitFall(player.getPos())) >= 0)
                goPitFall(pit);

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

            findPiece();

            // Give the Foes the acutal position of ET
            agent.ETPosition = player.Position;
            elliot.ETPosition = player.Position;
            scientist.ETPosition = player.Position;
        }
    }
}
