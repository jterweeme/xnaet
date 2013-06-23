using System;
using System.Collections.Generic;
using System.Threading;
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
        Debugger debugger;
        World world;

        public Screen getScreen()
        {
            return currentScreen;
        }

        public World getWorld()
        {
            return world;
        }

        public void setScreen(Screen screen)
        {
            currentScreen.removeContent();
            Components.Remove(currentScreen);
            currentScreen = screen;
            Components.Add(currentScreen);
        }

        public void setFullScreen()
        {
            System.Console.Error.WriteLine("going fullscreen");
            graphics.IsFullScreen = true;
        }

        public EtGame(bool fullscreen = false)
        {
            
            //debugger = new Debugger(this);
            graphics = new GraphicsDeviceManager(this);
            graphics.PreferredBackBufferWidth = 640;
            graphics.PreferredBackBufferHeight = 480;
            graphics.IsFullScreen = fullscreen;
            Content.RootDirectory = "Content";
        }

        protected override void Initialize()
        {
            world = new World();
            System.Console.Error.WriteLine(world);
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
            Argumenten argumenten = new Argumenten(args);
            System.Console.WriteLine(argumenten);
            EtGame.instanz = new EtGame(argumenten.getFullScreen());
            EtGame.instanz.Run();
        }
    }
}
