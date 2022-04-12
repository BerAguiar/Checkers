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
            CheckerBoard.AddPiece(new Checker(new Position(2, 2), ConsoleColor.DarkRed, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(2, 6), ConsoleColor.DarkBlue, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(6, 6), ConsoleColor.DarkRed, CheckerBoard));
            CheckerBoard.AddPiece(new Queen(new Position(4, 4), ConsoleColor.DarkRed, CheckerBoard));

            Engine engine = new Engine(CheckerBoard);

            Graphics.DrawBoard(CheckerBoard);
            engine.GamePlay();

            /*Graphics.DrawBoard(CheckerBoard);
            Console.WriteLine("Select piece to move: ");
            var position = Input.ReadInputs();

            Console.WriteLine(CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == position[0] && x.PiecePosition.PosY == position[1]));

            Console.WriteLine("Select where to move piece: ");
            var position2 = Input.ReadInputs();

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == position[0] && x.PiecePosition.PosY == position[1]).MovePiece(new Position(position2[0], position2[1]));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            Graphics.DrawBoard(CheckerBoard);

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 3 && x.PiecePosition.PosY == 1).MovePiece(new Position(2, 2));

            Graphics.DrawBoard(CheckerBoard);

            Console.Read();

            CheckerBoard.Pieces.Find(x => x.PiecePosition.PosX == 5 && x.PiecePosition.PosY == 3).MovePiece(new Position(3, 1));
            Graphics.DrawBoard(CheckerBoard);
            Console.Read();*/

        }
    }
}
