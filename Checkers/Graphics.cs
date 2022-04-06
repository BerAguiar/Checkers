﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Checkers
{
    class Graphics
    {
        public Graphics()
        {
        }



        public static void DrawBoard(int size, List<Piece> board)
        {
            Console.Clear();
            foreach(Piece piece in board)
                Console.WriteLine(piece.GetXY()[0] + "," + piece.GetXY()[1]);
            Console.OutputEncoding = System.Text.Encoding.Unicode;
            Console.WriteLine("  ABCDEFGHIJKLMNOPQRSTUVWXYZ".Substring(0, size + 2));
            for (int i = 0; i < size; i++)
            {
                Console.Write((i+1).ToString("D2"));
                for (int j = 0; j < size; j++)
                {
                    if ((i + j) % 2 == 0)
                        Console.BackgroundColor = ConsoleColor.Gray;
                    else
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                    var hasPiece = board.FirstOrDefault(p => p.GetXY()[1] == i && p.GetXY()[0] == j);
                    if (hasPiece != null)
                    {
                        Console.ForegroundColor = hasPiece.PieceColor;
                        Console.Write(hasPiece.PieceImage);
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