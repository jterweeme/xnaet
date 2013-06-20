using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Screen : DrawableGameComponent
    {
        protected Header header;
        protected Footer footer;
        protected Texture2D bgColor;
        protected SpriteBatch sb;

        public Screen() : base(EtGame.instanz)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            bgColor = new Texture2D(GraphicsDevice, 1, 1);
            bgColor.SetData(new Color[] { Color.Black });
        }

        public void setBgColor(Color color)
        {   bgColor.SetData(new Color[] { color });
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(bgColor, new Rectangle(0, 50, 640, 274), Color.White);
            sb.End();
        }

        public override void Initialize()
        {
            header = new Header();
            footer = new Footer();
            EtGame.instanz.Components.Add(header);
            EtGame.instanz.Components.Add(footer);
            base.Initialize();     
        }

        public virtual void removeContent() { }
    }
}
