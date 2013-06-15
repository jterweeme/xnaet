using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Agent : Foe
    {

        public Agent()
        {
            DrawOrder = 9999;
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            texture = Game.Content.Load<Texture2D>("agent");
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(texture, new Rectangle(200, 100, 94, 94), Color.White);
            sb.End();
        }
    }
}
