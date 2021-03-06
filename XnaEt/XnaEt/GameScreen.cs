﻿using System;
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
        

        public GameScreen(EtGame theGame) : base(theGame)
        {
            piecePlaces = new PiecePlaces();
        }

        public void setCurrentPit(Pit pit)
        {
            Game.Components.Remove(currentPit);
            currentPit = pit;
            Game.Components.Add(pit);
        }

        public void action(GameTime gameTime)
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
                        header.getClock2().start(gameTime.TotalGameTime);

                    break;
                case Zones.LANDING:

                    if (header.getClock2().getCount() > 0)
                        EtGame.instanz.setScreen(new EndingScreen());

                    break;
                case Zones.CANDY_MUNCHING:
                    Console.Error.WriteLine("Candy Munching Zone");
                    break;

                case Zones.HUMAN_REPELLANT:
                    Console.Error.WriteLine("Human Repellant Zone");
                    break;

                case Zones.PHONE_LOCATION:
                    Console.Error.WriteLine(piecePlaces);
                    currentPit.blink(piecePlaces);
                    break;
            }
        }

        public override void Initialize()
        {
            base.Initialize();
            header.setZone(Zones.LANDING);
            footer.setFont("bulawayo");
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            player = new Player(this);
            currentPit = theGame.getWorld().getPit(0);
            agent = new Agent();
            elliot = new Elliott();
            scientist = new Scientist();
            sndAction = Game.Content.Load<SoundEffect>("action");
            theGame.Components.Add(player);
            theGame.Components.Add(currentPit);
            theGame.Components.Add(agent);
            theGame.Components.Add(elliot);
            theGame.Components.Add(scientist);
        }

        public override void removeContent()
        {
            base.removeContent();
            theGame.Components.Remove(player);
            theGame.Components.Remove(currentPit);
            theGame.Components.Remove(agent);
            theGame.Components.Remove(elliot);
            theGame.Components.Remove(scientist);
        }

        private void goNorth()
        {
            player.setPitLocation(false);
            setCurrentPit(currentPit.getNorth());
            player.setPos(new Point(player.getPos().X, 200));
            goCommon();
        }

        public void goCommon()
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            currentPit.setBackground();
        }

        private void goWest()
        {
            player.setPitLocation(false);
            setCurrentPit(currentPit.getPit("west"));
            player.setPos(new Point(460, player.getPos().Y));
            goCommon();
        }

        private void goEast()
        {
            player.setPitLocation(false);
            setCurrentPit(currentPit.getPit("east"));
            player.setPos(new Point(20, player.getPos().Y));
            goCommon();
        }

        private void goSouth()
        {
            player.setPitLocation(false);
            setCurrentPit(currentPit.getPit("south"));
            player.setPos(new Point(player.getPos().X, 15));
            goCommon();
        }

        public void goPitFall(int pit)
        {
            scientist.Visible = false;
            elliot.Visible = false;
            agent.Visible = false;
            player.setPos(new Point(250, 40));
            player.setPitLocation(true);
            PitFall dePit2 = new PitFall(currentPit, pit);
            System.Console.Error.WriteLine(dePit2.getNummer());
            Piece piece = piecePlaces.getPieceFromPlace(pit);

            if (piece != null)
                dePit2.addPiece(piece);

            setCurrentPit(dePit2);
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
#if DEBUG
                    Console.Error.WriteLine(piecePlaces);
#endif
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

            if ((pit = currentPit.checkPitFall(player.getBoundingBox())) >= 0)
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
