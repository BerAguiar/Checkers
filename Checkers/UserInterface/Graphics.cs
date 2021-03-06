using Checkers.GameEnvironment;
using System;
using System.Linq;
using System.Threading;

namespace Checkers.UserInterface
{
    class Graphics
    {
        public Graphics()
        {
        }



        public static void DrawBoard(Board board)
        {
            Console.Clear();
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            //letter coordinates
            Console.WriteLine("  ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, board.HorizontalLenght + 2));
            for (int i = 0; i < board.VerticalLenght; i++)
            {
                //number coordinates
                Console.Write((i+1).ToString("D2"));
                for (int j = 0; j < board.HorizontalLenght; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.Gray;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    var hasPiece = board.Pieces.FirstOrDefault(p => p.GetXY()[1] == i && p.GetXY()[0] == j);
                    if (hasPiece != null)
                    {
                        Console.ForegroundColor = hasPiece.PieceColor;
                        Console.Write(hasPiece.PieceImage);
                    }
                    else
                        Console.Write(" ");
                }
                Console.ResetColor();
                //added to ease writing the moves close to the right
                Console.Write((i + 1).ToString("D2"));
                Console.WriteLine();
            }

            //added to ease writing the moves close to the bottom
            Console.WriteLine("  ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, board.HorizontalLenght + 2));
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
                Console.WriteLine(@"|C:\{0} |", typedTitle);
                Console.WriteLine(@"|             |");
                Console.WriteLine(@"|             |");
                Console.WriteLine(@"|_____________|");
                Thread.Sleep(200);
            }
            Thread.Sleep(1800);
        }
    }
}