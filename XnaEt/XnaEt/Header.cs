using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace XnaEt
{
    public class Header : DrawableGameComponent
    {
        Texture2D bgcolor;
        SpriteBatch sb;
        List<Texture2D> zones;
        Texture2D currentZone;

        public Header()
            : base(EtGame.instanz)
        {
            zones = new List<Texture2D>();
        }

        protected override void LoadContent()
        {
            base.LoadContent();
            sb = new SpriteBatch(GraphicsDevice);
            bgcolor = new Texture2D(GraphicsDevice, 1, 1);
            bgcolor.SetData(new Color[] { Color.Purple });

            zones.Add(Game.Content.Load<Texture2D>("zoneTitle"));
            zones.Add(Game.Content.Load<Texture2D>("zoneCandyMunching"));
            zones.Add(Game.Content.Load<Texture2D>("zoneHumanRepellant"));
            zones.Add(Game.Content.Load<Texture2D>("zoneCallship"));
            zones.Add(Game.Content.Load<Texture2D>("zoneLanding"));
            currentZone = zones[0];
        }

        public void setZone(int zone)
        {
            currentZone = zones[zone];
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(bgcolor, new Rectangle(0, 14, 640, 30), Color.White);
            sb.Draw(currentZone, new Rectangle(200, 14, 30, 30), Color.White);
            sb.End();
        }
    }
}
