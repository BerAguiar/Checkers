using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace Checkers
{
    class Graphics
    {
        public Graphics()
        { 
        }



        public static void DrawBoard(int[,] board)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    else
                        Console.BackgroundColor = ConsoleColor.Gray;
                    if (board[i, j] == 1)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("●");
                    }
                    else if (board[i, j] == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("●");
                    }
                    else if (board[i, j] == 10)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkBlue;
                        Console.Write("♠");
                    }
                    else if (board[i, j] == 20)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkRed;
                        Console.Write("♠");
                    }
                    else
                        Console.Write(" ");
                }
                Console.ResetColor();
                Console.WriteLine();
            }
        }



        public static void SplashScreen()
        {
            string title = "CHECKERS";
            for (int i = 0; i <= title.Length; i++)
            {
                Console.Clear();
                string typedTitle = title.Substring(0, i) + "_             ";
                typedTitle = typedTitle.Substring(0, title.Length + 1);
                Console.WriteLine(@"===============");
                Console.WriteLine(@"|C:\{0} |",typedTitle);
                Console.WriteLine(@"|             |");
                Console.WriteLine(@"|             |");
                Console.WriteLine(@"|_____________|");
                Thread.Sleep(200);
            }
            Thread.Sleep(1800);
        }
    }
}
