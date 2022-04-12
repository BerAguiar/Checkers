using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Checkers
{
    class Engine
    {
        private Board board;
        private ConsoleColor turn;

        public Engine(int size)
        {
            board = new Board(size, size);
            turn = ConsoleColor.DarkBlue;
        }



        public Engine(Board _board)
        {
            board = _board;
            turn = ConsoleColor.DarkBlue;
        }



        private void Move()
        {
            Console.ForegroundColor = turn;
            Console.Write("\nPlease input your initial position: ");
            var initialPos = Input.ReadInputs();
            Piece movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            while (movingPiece == null || movingPiece.PieceColor != turn)
            {
                Console.Write("\nInvalid Piece!\nPlease input your initial position: ");
                initialPos = Input.ReadInputs();
                movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            }
            Console.Write("\nPlease input your final position: ");
            var finalPos = Input.ReadInputs();

            bool validMove = movingPiece.MovePiece(new Position(finalPos[0], finalPos[1]));

            if(validMove && Math.Abs(finalPos[0] - initialPos[0]) > 1 && Math.Abs(finalPos[1] - initialPos[1]) > 1)
            {
                int dirX = (finalPos[0] - initialPos[0]) / Math.Abs(finalPos[0] - initialPos[0]);
                int dirY = (finalPos[1] - initialPos[1]) / Math.Abs(finalPos[1] - initialPos[1]);
                var jumpedPos = new int[2] { initialPos[0] + dirX, initialPos[1] + dirY };
                while (jumpedPos[0]!=finalPos[0])
                {
                    if (board.Pieces.Find(x => x.PiecePosition.PosX == jumpedPos[0] && x.PiecePosition.PosY == jumpedPos[1]) != null)
                    {
                        board.RemovePiece(board.Pieces.Find(x => x.PiecePosition.PosX == jumpedPos[0] && x.PiecePosition.PosY == jumpedPos[1]));
                        break;
                    }
                    jumpedPos[0] += dirX;
                    jumpedPos[1] += dirY;
                }
            }
            Console.ResetColor();

            Graphics.DrawBoard(board);
        }



        private void Turn()
        {
            int endedMove;
            do
            {
                Move();
                Console.ForegroundColor = turn;
                Console.Write("Are there subsequent moves?");
                Console.ResetColor();
                string input = Console.ReadLine();
                switch (input.ToLower())
                {
                    case "1":
                    case "yes":
                    case "y":
                        endedMove = 1;
                        break;
                    default:
                        endedMove = 0;
                        break;
                }
            } while (endedMove == 1);
            EndTurn();
        }



        private void EndTurn()
        {
            if (turn == ConsoleColor.DarkBlue)
                turn = ConsoleColor.DarkRed;
            else
                turn = ConsoleColor.DarkBlue;
        }



        public ConsoleColor GamePlay()
        {
            while(board.Pieces.Find(x => x.PieceColor == ConsoleColor.DarkRed) != null
                && board.Pieces.Find(x => x.PieceColor == ConsoleColor.DarkBlue) != null)
            {
                Turn();
            }
            if (board.Pieces.Find(x => x.PieceColor == ConsoleColor.DarkRed) == null)
                return ConsoleColor.DarkBlue;
            else
                return ConsoleColor.DarkRed;
        }
    }
}
