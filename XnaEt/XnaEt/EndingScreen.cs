using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class EndingScreen : Screen
    {
        protected Texture2D background;
        Texture2D house;
        Elliott elliot;
        Player player;

        public EndingScreen()
        {
            DrawOrder = 10000;
        }

        public override void Initialize()
        {
            base.Initialize();
            header.setZone(Zones.CANDY_MUNCHING);
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            setBgColor(new Color(51, 26, 163));
            background = new Texture2D(GraphicsDevice, 1, 1);
            background.SetData(new Color[] { new Color(0, 28, 136) });
            house = Game.Content.Load<Texture2D>("house");

            player = new Player();
            elliot = new Elliott();

            elliot.Visible = true;

            EtGame.instanz.Components.Add(player);
            EtGame.instanz.Components.Add(elliot);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(background, new Rectangle(64, 58, 512, 260), Color.White);
            sb.Draw(house, new Rectangle(64, 58, 512, 260), Color.White);
            sb.End();
        }
    }
}
