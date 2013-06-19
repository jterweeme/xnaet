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

        protected override void LoadContent()
        {
            base.LoadContent();
            footer.Text = "(c)2013 Jasper tari Weeme";
            sb = new SpriteBatch(GraphicsDevice);
            splash = Game.Content.Load<Texture2D>("forest");
            titelSong = Game.Content.Load<Song>("spaceship");
            setBgColor(new Color(0, 64, 0));
            background = new Texture2D(GraphicsDevice, 1, 1);
            background.SetData(new Color[] { new Color(82, 126, 45) });
            MediaPlayer.Play(titelSong);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(background, new Rectangle(64, 58, 512, 260), Color.White);
            sb.Draw(splash, new Rectangle(64, 58, 512, 260), Color.White);
            sb.End();
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);
            KeyboardState kb = Keyboard.GetState();

            if (kb.IsKeyDown(Keys.LeftControl))
            {
                MediaPlayer.Stop();
                EtGame.instanz.CurrentScreen = new GameScreen();
            }
        }
    }
}
