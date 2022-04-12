using System;
using System.Collections.Generic;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            //Graphics.SplashScreen();
            var size = 10;
            int numberOfPieces = 10; //(size / 2 - 1) * (size / 2);
            var pieces = new List<Piece>();
            Board CheckerBoard = new Board(size, size);

            int x = 0, y = 0;
 
            for (int i = 0; i < numberOfPieces; i++)
            {
                CheckerBoard.AddPiece(new Checker(new Position(x, y), ConsoleColor.DarkBlue, CheckerBoard));
                CheckerBoard.AddPiece(new Checker(new Position(size - x - 1, size - y - 1), ConsoleColor.DarkRed, CheckerBoard));
                x += 2;
                if(x >= size)
                {
                    y++;
                    x = 0 + y % 2;
                }
            }
            CheckerBoard.AddPiece(new Queen(new Position(2, 6), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Queen(new Position(3, 5), ConsoleColor.Red, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(6, 6), ConsoleColor.Red, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(4, 4), ConsoleColor.Red, CheckerBoard));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 4 && x.PiecePosition.PosY == 4).MovePiece(new Position(5, 3));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            Piece test = CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 3 && x.PiecePosition.PosY == 1);

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 3 && x.PiecePosition.PosY == 1).MovePiece(new Position(4, 2));

            int[] test2 = test.GetXY();


            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 5 && x.PiecePosition.PosY == 3).MovePiece(new Position(3, 1));
            Graphics.DrawBoard(CheckerBoard);
            Console.Read();

        }
    }
}
