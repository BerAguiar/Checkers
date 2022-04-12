using System;
using System.Collections.Generic;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphics.SplashScreen();
            
            Engine engine = new Engine(10);
            engine.GamePlay();

        }
    }
}
