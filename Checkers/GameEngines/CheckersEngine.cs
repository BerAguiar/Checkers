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
        private Piece movingPiece = null;

        public CheckersEngine(int size)
        {
            board = GenerateCheckerBoard(size);
            turn = ConsoleColor.DarkBlue;
        }



        private void Move()
        {
            Console.ForegroundColor = turn;
            int[] initialPos = checkSelected();

            Console.Write("\nPlease input the final position: ");
            var finalPos = Input.ReadInputs();

            while(!movingPiece.CanMoveCheckerToPosition(new Position(finalPos[0], finalPos[1])))
            {
                Console.WriteLine("\nInvalid Move!");
                initialPos = checkSelected();
                Console.Write("\nPlease input the final position: ");
                finalPos = Input.ReadInputs();
            }
            
            bool validMove = movingPiece.MovePiece(new Position(finalPos[0], finalPos[1]));


            //capture logic
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


            //crowning logic
            if ((movingPiece.PieceColor == ConsoleColor.DarkBlue && finalPos[1] == 9) || (movingPiece.PieceColor == ConsoleColor.DarkRed && finalPos[1] == 0))
            {
                board.RemovePiece(movingPiece);
                board.AddPiece(new Queen(new Position(finalPos[0], finalPos[1]), turn, board));
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
            //standard board

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

            //demo boardstate

            //Board CheckerBoard = new Board(size, size);
            //CheckerBoard.AddPiece(new Checker(new Position(2, 0), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(1, 1), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(1, 3), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(3, 1), ConsoleColor.DarkRed, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(0, 2), ConsoleColor.DarkRed, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(0, 4), ConsoleColor.DarkRed, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(3, 3), ConsoleColor.DarkRed, CheckerBoard));


            //CheckerBoard.AddPiece(new Checker(new Position(6, 8), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(9, 5), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(9, 7), ConsoleColor.DarkBlue, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(7, 9), ConsoleColor.DarkRed, CheckerBoard));
            //CheckerBoard.AddPiece(new Checker(new Position(8, 8), ConsoleColor.DarkRed, CheckerBoard));
            

            //output
            return CheckerBoard;
        }



        private int[] checkSelected()
        {
            Console.Write("\nPlease input the position of the piece to be moved: ");
            var initialPos = Input.ReadInputs();
            movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            while (movingPiece == null || movingPiece.PieceColor != turn)
            {
                Console.Write("\nInvalid Piece!\nPlease input the position of a valid piece to be moved: ");
                initialPos = Input.ReadInputs();
                movingPiece = board.Pieces.Find(x => x.PiecePosition.PosX == initialPos[0] && x.PiecePosition.PosY == initialPos[1]);
            }
            return initialPos;
        }
    }
}
