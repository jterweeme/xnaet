using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Media;

namespace XnaEt
{
    public class SplashScreen : Screen
    {
        Texture2D splash;
        Song titelSong;

        public SplashScreen() : base(null)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            footer.Text = "(c)2013 Jasper tari Weeme";
            sb = new SpriteBatch(GraphicsDevice);
            setInnerBackground(new Color(0, 0, 148));
            splash = Game.Content.Load<Texture2D>("title");
            titelSong = Game.Content.Load<Song>("titelsong");
            MediaPlayer.Play(titelSong);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
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
                EtGame.instanz.setScreen(new LandingScreen());
            }
        }
    }
}
