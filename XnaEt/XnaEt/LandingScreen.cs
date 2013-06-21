using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XnaEt
{
    public class LandingScreen : Screen
    {
        Texture2D splash;
        Song titelSong;
        protected Texture2D background;
        Texture2D spaceship;
        int spaceshipY;
        int counter;

        public LandingScreen()
        {
            spaceshipY = 10;
            counter = 0;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            footer.Text = "9999";
            sb = new SpriteBatch(GraphicsDevice);
            splash = Game.Content.Load<Texture2D>("forest");
            titelSong = Game.Content.Load<Song>("spaceship");
            spaceship = Game.Content.Load<Texture2D>("spaceship_png");
            setBgColor(new Color(0, 64, 0));
            background = new Texture2D(GraphicsDevice, 1, 1);
            background.SetData(new Color[] { new Color(82, 126, 45) });
            MediaPlayer.Play(titelSong);
            footer.setFont("bulawayo");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(background, new Rectangle(64, 58, 512, 260), Color.White);
            sb.Draw(splash, new Rectangle(64, 58, 512, 260), Color.White);
            sb.Draw(spaceship, new Rectangle(288, spaceshipY, 64, 64), Color.White);
            sb.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState kb = Keyboard.GetState();
            spaceshipY++;

            if (++counter > 100)
                EtGame.instanz.setScreen(new GameScreen());
        }
    }
}
