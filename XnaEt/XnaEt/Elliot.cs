using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Elliot : Foe
    {
        public Elliot()
        {
            DrawOrder = 9999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("elliot");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Rectangle(300, 100, 48, 48), Color.White);
            sb.End();
        }
    }
}
