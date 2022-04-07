using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Checkers
{
    class Program
    {
        static void Main(string[] args)
        {
            Graphics.SplashScreen();
            var size = 10;
            int numberOfPieces = (size / 2 - 1) * (size / 2);
            var pieces = new List<Piece>();
            Board CheckerBoard = new Board(size, size);
            int x = 0, y = 0;
 
            for (int i = 0; i < numberOfPieces; i++)
            {
                CheckerBoard.AddPiece(new Checker(new Position(x, y), ConsoleColor.DarkBlue));
                CheckerBoard.AddPiece(new Checker(new Position(size - x - 1, size - y - 1), ConsoleColor.DarkRed));
                x += 2;
                if(x >= size)
                {
                    y++;
                    x = 0 + y % 2;
                }
            }
            
            Graphics.DrawBoard(CheckerBoard);
        }
    }
}
