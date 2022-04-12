using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Checker : Piece
    {
        public Checker(Position position, ConsoleColor color, Board board) : base(position, color, board, "\u25cf")
        {

        }

        public override int[] GetXY()
        {
            return PiecePosition.GetPos();
        }
        public override void MovePiece(Position newPosition)
        {
            if (CanMoveCheckerToPosition(newPosition))
                PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
            else
                Console.WriteLine("Invalid move!");
        }

        private bool CanMoveCheckerToPosition(Position newPosition)
        {
            if (!IsValidPosition(newPosition))
                return false;

            if (!IsValidRegularMove(newPosition))
            {
                if (IsValidCaptureMove(newPosition))
                {
                    return true;
                }
                return false;
            }
            return true;
        }
        private bool ExistsPieceInPosition(Position position)
        {
            if (Board.Pieces.Exists(x => x.PiecePosition.PosX == position.PosX && x.PiecePosition.PosY == position.PosY))
                return true;

            return false;
        }
        private bool IsValidRegularMove(Position newPosition)
        {
            if (Math.Abs(PiecePosition.PosX - newPosition.PosX) != 1 || Math.Abs(PiecePosition.PosY - newPosition.PosY) != 1 && newPosition.PosY > PiecePosition.PosY)
                return false;

            if (ExistsPieceInPosition(newPosition))
                return false;

            return true;
        }
        private bool IsValidCaptureMove(Position newPosition)
        {
            if (!Board.Pieces.Exists(x => Math.Abs(PiecePosition.PosX - x.PiecePosition.PosX) == 1
                    && Math.Abs(PiecePosition.PosY - x.PiecePosition.PosY) == 1 && x.PieceColor != PieceColor))
                return false;

            if (Math.Abs(PiecePosition.PosX - newPosition.PosX) > 2 || Math.Abs(PiecePosition.PosY - newPosition.PosY) > 2)
                return false;

            if (ExistsPieceInPosition(newPosition))
                return false;

            return true;
        }

        private bool IsValidPosition(Position position)
        {
            if (position.PosX > Board.HorizontalLenght && position.PosX <= 0 || position.PosY > Board.VerticalLenght && position.PosY <= 0)
                return false;
            return true;
        }
    }
}
