using Checkers.GameEnvironment;
using Checkers.Pieces;
using Checkers.UserInterface;
using System;

namespace Checkers.GameEngines
{
    class CheckersEngine
    {
        private Board board;
        private ConsoleColor turn;

        public CheckersEngine(int size)
        {
            board = GenerateCheckerBoard(size);
            turn = ConsoleColor.DarkBlue;
        }



        private void Move()
        {
            Console.ForegroundColor = turn;
            Console.Write("\nPlease input the position of the piece to be moved: ");
            var initialPos = Input.ReadInputs();
            Piece movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            while (movingPiece == null || movingPiece.PieceColor != turn)
            {
                Console.Write("\nInvalid Piece!\nPlease input the position of a valid piece to be moved: ");
                initialPos = Input.ReadInputs();
                movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            }

            Console.Write("\nPlease input the final position: ");
            var finalPos = Input.ReadInputs();

            while(!movingPiece.CanMoveCheckerToPosition(new Position(finalPos[0], finalPos[1])))
            {
                Console.WriteLine("\nInvalid Move!\nPlease input the position of a valid piece to be moved: ");
                initialPos = Input.ReadInputs();
                movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
                while (movingPiece == null || movingPiece.PieceColor != turn)
                {
                    Console.Write("\nInvalid Piece!\nPlease input the position of a valid piece to be moved: ");
                    initialPos = Input.ReadInputs();
                    movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
                }
                Console.Write("\nPlease input the final position: ");
                finalPos = Input.ReadInputs();
            }
            
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
                Console.Write("\nAre there subsequent moves? (y/n): ");
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
            Graphics.DrawBoard(board);
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
            Graphics.DrawBoard(board);
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



        private Board GenerateCheckerBoard(int size)
        {
            int numberOfPieces = (size / 2 - 1) * (size / 2);
            Board CheckerBoard = new Board(size, size);

            int x = 0, y = 0;

            for (int i = 0; i < numberOfPieces; i++)
            {
                CheckerBoard.AddPiece(new Checker(new Position(x, y), ConsoleColor.DarkBlue, CheckerBoard));
                CheckerBoard.AddPiece(new Checker(new Position(size - x - 1, size - y - 1), ConsoleColor.DarkRed, CheckerBoard));
                x += 2;
                if (x >= size)
                {
                    y++;
                    x = 0 + y % 2;
                }
            }
            return CheckerBoard;
        }
    }
}
