using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace XnaEt
{
    public class Debugger
    {
        public Debugger()
        {
            Thread thread = new Thread(new ThreadStart(Maine));
            thread.Start();
        }

        public static void Maine()
        {
            while (true)
            {
                Console.Write(">");

                if (Console.ReadLine().Equals("exit"))
                    Environment.Exit(0);

                if (Console.ReadLine().Equals("fullscreen"))
                    EtGame.instanz.setFullScreen();
            }
        }
    }
}
