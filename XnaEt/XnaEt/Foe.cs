using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Foe : DrawableGameComponent
    {
        protected Texture2D texture;
        protected SpriteBatch sb;

        public Foe()
            : base(EtGame.instanz)
        {
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
        }
    }
}
