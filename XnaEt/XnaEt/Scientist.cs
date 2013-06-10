using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Scientist : Foe
    {
        public Scientist()
        {
            DrawOrder = 9999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("scientist");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Rectangle(400, 250, 48, 48), Color.White);
            sb.End();
        }
    }
}
