using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Screen : DrawableGameComponent
    {
        protected Header header;
        protected Footer footer;
        protected Texture2D outerBackground;
        protected Texture2D innerBackground;
        protected SpriteBatch sb;
        protected EtGame theGame;

        public Screen(EtGame theGame) : base(EtGame.instanz)
        {
            this.theGame = theGame;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            outerBackground = new Texture2D(GraphicsDevice, 1, 1);
            innerBackground = new Texture2D(GraphicsDevice, 1, 1);
            outerBackground.SetData(new Color[] { Color.Black });
            innerBackground.SetData(new Color[] { Color.Black });
        }

        public void setBgColor(Color color)
        {   outerBackground.SetData(new Color[] { color });
        }

        public void setInnerBackground(Color color)
        {   innerBackground.SetData(new Color[] { color });
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(outerBackground, new Rectangle(0, 50, 640, 274), Color.White);
            sb.Draw(innerBackground, new Rectangle(64, 58, 512, 260), Color.White);
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
