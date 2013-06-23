using System;
using System.Threading;

namespace XnaEt
{
    public class Debugger
    {
        EtGame etGame;

        public Debugger(EtGame etGame)
        {
            this.etGame = etGame;
            Thread thread = new Thread(new ThreadStart(Maine));
            thread.Start();
        }

        public void Maine()
        {
            while (true)
            {
                Console.Write(">");

                if (Console.ReadLine().Equals("exit"))
                    Environment.Exit(0);

                if (Console.ReadLine().Equals("fullscreen"))
                    etGame.setFullScreen();
            }
        }
    }
}
