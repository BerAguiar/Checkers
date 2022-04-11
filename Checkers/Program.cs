using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

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
            ValidationRules vr = new ValidationRules(CheckerBoard, ConsoleColor.DarkBlue);

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
            CheckerBoard.AddPiece(new Queen(new Position(3, 5), ConsoleColor.Red, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(6, 6), ConsoleColor.Red, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(4, 4), ConsoleColor.Red, CheckerBoard));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 6 && x.PiecePosition.PosY == 6).MovePiece(new Position(9, 3));

            
            //vr.MovePiece(new Position(3,7), CheckerBoard.Pieces.Find(x => x.PiecePosition.GetPos()[0]==2 && x.PiecePosition.GetPos()[1] == 6));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

        }
    }
}
