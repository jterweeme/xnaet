using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

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
        SoundEffect sndAction;
        bool ctrlKeyActive = false;
        

        public GameScreen()
        {
            piecePlaces = new PiecePlaces();
            System.Console.Error.WriteLine(piecePlaces);
        }

        public void setCurrentPit(Pit pit)
        {
            Game.Components.Remove(currentPit);
            currentPit = pit;
            Game.Components.Add(pit);
        }

        public void action()
        {
            sndAction.Play();
            switch (currentPit.getZone(player.getPos()))
            {
                case Zones.UP:
                    goNorth();
                    break;
                case Zones.LEFT:
                    goWest();
                    break;
                case Zones.RIGHT:
                    goEast();
                    break;
                case Zones.DOWN:
                    goSouth();
                    break;
                case Zones.CALLSHIP:

                    if (player.getItems().Count == 3)
                        header.setClock(8);

                    break;
                case Zones.LANDING:

                    if (header.getClock() > 0)
                        EtGame.instanz.setScreen(new EndingScreen());

                    break;
                case Zones.CANDY_MUNCHING:
                    System.Console.Error.WriteLine("Candy Munching Zone");
                    break;

                case Zones.HUMAN_REPELLANT:
                    System.Console.Error.WriteLine("Human Repellant Zone");
                    break;

                case Zones.PHONE_LOCATION:
                    System.Console.Error.WriteLine("Reveil locations");
                    break;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            header.setZone(Zones.LANDING);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            player = new Player(this);
            currentPit = new Forest();
            agent = new Agent();
            elliot = new Elliott();
            scientist = new Scientist();
            sndAction = Game.Content.Load<SoundEffect>("action");
            EtGame.instanz.Components.Add(player);
            EtGame.instanz.Components.Add(currentPit);
            EtGame.instanz.Components.Add(agent);
            EtGame.instanz.Components.Add(elliot);
            EtGame.instanz.Components.Add(scientist);
        }

        public override void removeContent()
        {
            base.removeContent();
            EtGame.instanz.Components.Remove(player);
            EtGame.instanz.Components.Remove(currentPit);
            EtGame.instanz.Components.Remove(agent);
            EtGame.instanz.Components.Remove(elliot);
            EtGame.instanz.Components.Remove(scientist);
        }

        private void goNorth()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            setCurrentPit(currentPit.getNorth());
            player.setPos(new Point(player.getPos().X, 200));
        }

        private void goWest()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            setCurrentPit(currentPit.getWest());
            player.setPos(new Point(460, player.getPos().Y));
        }

        private void goEast()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            setCurrentPit(currentPit.getEast());
            player.setPos(new Point(20, player.getPos().Y));
        }

        private void goSouth()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPitLocation(false);
            setCurrentPit(currentPit.getSouth());
            player.setPos(new Point(player.getPos().X, 15));
        }

        public void goPitFall(int pit)
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPos(new Point(250, 40));
            player.setPitLocation(true);
            PitFall dePit = currentPit.getPitFall(pit);
            System.Console.Error.WriteLine(dePit.getNummer());
            Piece piece = piecePlaces.getPieceFromPlace(pit);

            if (piece != null)
                dePit.addPiece(piece);

            setCurrentPit(dePit);
            header.setZone(10);
        }

        public void findPiece()
        {
            if (currentPit.hasPiece())
            {
                Piece piece = currentPit.getPiece();
                if (player.getBoundingBox().Intersects(piece.getBoundingBox()))
                {
                    SoundEffect blieb = Game.Content.Load<SoundEffect>("clocktick");
                    blieb.Play();
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
            agent.ETPosition = player.getPos();
            elliot.ETPosition = player.getPos();
            scientist.ETPosition = player.getPos();
        }
    }
}
