using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.GamerServices;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace XnaEt
{
    public class EtGame : Microsoft.Xna.Framework.Game
    {
        public static EtGame instanz;
        GraphicsDeviceManager graphics;
        Screen currentScreen;

        public Screen CurrentScreen
        {
            get
            {
                return currentScreen;
            }
            set
            {
                setScreen(value);
            }
        }

        public void setScreen(Screen screen)
        {
            Components.Remove(currentScreen);
            currentScreen = screen;
            Components.Add(currentScreen);
        }

        public EtGame()
        {
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 400;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            currentScreen = new SplashScreen();
            Components.Add(currentScreen);
            base.Initialize();      
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            if (Keyboard.GetState().IsKeyDown(Keys.Escape))
                this.Exit();

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);
            base.Draw(gameTime);
        }

        static void Main(string[] args)
        {
            EtGame.instanz = new EtGame();
            EtGame.instanz.Run();
        }
    }
}
