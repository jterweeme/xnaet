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
        List<Texture2D> pieces;
        Clock clock;
        Texture2D currentZone;
        int itemCount;
        int clockCount;
        EtGame etGame;

        public Header(EtGame theGame) : base(theGame)
        {
            etGame = theGame;
            itemCount = 0;
            clockCount = 0;
            zones = new List<Texture2D>();
            pieces = new List<Texture2D>();
            clock = new Clock(EtGame.instanz);
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
            zones.Add(Game.Content.Load<Texture2D>("zoneUp"));
            zones.Add(Game.Content.Load<Texture2D>("zoneLeft"));
            zones.Add(Game.Content.Load<Texture2D>("zoneRight"));
            zones.Add(Game.Content.Load<Texture2D>("zoneDown"));
            zones.Add(Game.Content.Load<Texture2D>("zoneCallElliott"));
            zones.Add(Game.Content.Load<Texture2D>("zonePitfall"));
            zones.Add(Game.Content.Load<Texture2D>("zoneQuestion"));
            pieces.Add(Game.Content.Load<Texture2D>("pieces0"));
            pieces.Add(Game.Content.Load<Texture2D>("pieces1"));
            pieces.Add(Game.Content.Load<Texture2D>("pieces2"));
            pieces.Add(Game.Content.Load<Texture2D>("pieces3"));
            etGame.Components.Add(clock);
            currentZone = zones[0];
        }

        public void setZone(int zone)
        {
            currentZone = zones[zone];
        }

        public void setPieces(int pieces)
        {
            itemCount = pieces;
        }

        public Clock getClock2()
        {
            return clock;
        }

        /*
        public void setClock(int n)
        {
            clockCount = n;
        }*/
        
        public int getClock()
        {
            return clockCount;
        }

        public override void Draw(GameTime gameTime)
        {
            base.Draw(gameTime);
            sb.Begin();
            sb.Draw(bgcolor, new Rectangle(0, 14, 640, 30), Color.White);
            sb.Draw(currentZone, new Rectangle(295, 14, 50, 30), Color.White);
            sb.Draw(pieces[itemCount], new Rectangle(150, 14, 51, 30), Color.White);
            //sb.Draw(clock[clockCount], new Rectangle(480, 14, 50, 30), Color.White);
            sb.End();
        }
    }
}
