using Checkers.GameEngines;
using Checkers.UserInterface;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphics.SplashScreen();
            
            CheckersEngine engine = new CheckersEngine(10);
            engine.GamePlay();

        }
    }
}
