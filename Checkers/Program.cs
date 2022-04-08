﻿using System;
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
            int numberOfPieces = (size / 2 - 1) * (size / 2);
            var pieces = new List<Piece>();
            Board CheckerBoard = new Board(size, size);
            ValidationRules vr = new ValidationRules(CheckerBoard);

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
            CheckerBoard.AddPiece(new Queen(new Position(4, 4), ConsoleColor.DarkBlue));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            vr.MovePiece(-1,1, CheckerBoard.Pieces.Find(x => x.PiecePosition.GetPos()[0]==4 && x.PiecePosition.GetPos()[1] == 4));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

        }
    }
}
