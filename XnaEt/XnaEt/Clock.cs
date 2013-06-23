using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace XnaEt
{
    public class Clock : DrawableGameComponent
    {
        private List<Texture2D> textures;
        private SpriteBatch sb;
        int clockCount;
        TimeSpan clockStart;
        SoundEffect tick;

        public Clock(EtGame etGame) : base(etGame)
        {
            DrawOrder = 10002;
            textures = new List<Texture2D>();
            clockCount = 0;
        }

        public override void Initialize()
        {
            base.Initialize();
            sb = new SpriteBatch(GraphicsDevice);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            tick = Game.Content.Load<SoundEffect>("clocktick");
            textures.Add(Game.Content.Load<Texture2D>("pieces0"));
            textures.Add(Game.Content.Load<Texture2D>("clock2"));
            textures.Add(Game.Content.Load<Texture2D>("clock2"));
            textures.Add(Game.Content.Load<Texture2D>("clock3"));
            textures.Add(Game.Content.Load<Texture2D>("clock4"));
            textures.Add(Game.Content.Load<Texture2D>("clock5"));
            textures.Add(Game.Content.Load<Texture2D>("clock6"));
            textures.Add(Game.Content.Load<Texture2D>("clock7"));
            textures.Add(Game.Content.Load<Texture2D>("clock8"));
        }

        public void start(TimeSpan nu)
        {
            clockStart = nu;
            clockCount = 8;
        }

        public int getCount()
        {
            return clockCount;
        }

        public override void Update(GameTime gameTime)
        {
            base.Update(gameTime);

            if (clockStart.Ticks > 0)
            {
                int verlopenTijdSec = gameTime.TotalGameTime.Seconds - clockStart.Seconds;
                System.Console.WriteLine(verlopenTijdSec);
                int remaining = 8 - verlopenTijdSec;

                if (remaining >= 0 /*&& remaining != clockCount*/)
                {
                    clockCount = remaining;
                    //tick.Play();
                }
            }
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(textures[clockCount], new Rectangle(480, 14, 50, 30), Color.White);
            sb.End();
        }
    }
}
