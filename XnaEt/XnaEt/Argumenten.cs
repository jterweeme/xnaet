using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XnaEt
{
    public class Argumenten
    {
        string[] args;

        public Argumenten(string[] args)
        {
            this.args = args;
        }

        public bool getFullScreen()
        {
            foreach (string arg in args)
                if (arg.Equals("-fullscreen"))
                    return true;

            return false;
        }

        public override string ToString()
        {
            string returnstring = null;

            foreach (string arg in args)
                returnstring += arg;

            return returnstring;
        }
    }
}
