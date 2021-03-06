﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Footer : DrawableGameComponent
    {
        protected Texture2D texture;
        SpriteBatch sb;
        public string Text { get; set; }
        SpriteFont font;

        public Footer() : base(EtGame.instanz)
        {   Text = "";
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            font = Game.Content.Load<SpriteFont>("spriteFont1");
            texture = new Texture2D(GraphicsDevice, 1, 1);
            texture.SetData(new Color[] { Color.CornflowerBlue });
        }

        public void setFont(string asset)
        {   this.font = Game.Content.Load<SpriteFont>(asset);
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Rectangle(0, 354, 640, 40), Color.White);
            sb.DrawString(font, Text, new Vector2(320 - font.MeasureString(Text).X / 2, 360), new Color(0, 68, 0));
            sb.End();
        }
    }
}
