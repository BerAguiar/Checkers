using Checkers.GameEnvironment;
using System;

namespace Checkers.Pieces
{
    class Checker : Piece
    {
        public bool IsCaptureMove { get; private set; }
        public Checker(Position position, ConsoleColor color, Board board) : base(position, color, board, "•")
        {

        }

        public override int[] GetXY()
        {
            return PiecePosition.GetPos();
        }
        public override bool MovePiece(Position newPosition)
        {
            if (CanMoveCheckerToPosition(newPosition))
            {
                PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
                return true;
            }
            return false;
        }

        public override bool CanMoveCheckerToPosition(Position newPosition)
        {
            if (!IsValidPosition(newPosition))
                return false;

            if (!IsValidRegularMove(newPosition))
            {
                if (IsValidCaptureMove(newPosition))
                {
                    IsCaptureMove = true;
                    return true;
                }
                return false;
            }
            IsCaptureMove = false;
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
            if (Math.Abs(PiecePosition.PosX - newPosition.PosX) != 1 || Math.Abs(PiecePosition.PosY - newPosition.PosY) != 1)
                return false;

            //avoid going backwards
            if ((!(newPosition.PosY > PiecePosition.PosY) && PieceColor == ConsoleColor.DarkBlue) || (PieceColor == ConsoleColor.DarkRed && (newPosition.PosY > PiecePosition.PosY)))
                return false;

            if (ExistsPieceInPosition(newPosition))
                return false;

            return true;
        }
        private bool IsValidCaptureMove(Position newPosition)
        {
            //check if the moving piece is next to an enemy piece
            if (!Board.Pieces.Exists(x => Math.Abs(PiecePosition.PosX - x.PiecePosition.PosX) == 1
                    && Math.Abs(PiecePosition.PosY - x.PiecePosition.PosY) == 1 && x.PieceColor != PieceColor))
                return false;

            //after the jump, is there an enemy piece "behind"?
            if (!Board.Pieces.Exists(x => (((newPosition.PosX - PiecePosition.PosX) / 2) + PiecePosition.PosX == x.PiecePosition.PosX) && ((((newPosition.PosY-PiecePosition.PosY)/2)) + PiecePosition.PosY == x.PiecePosition.PosY) && x.PieceColor != PieceColor))
                return false;

            //avoid jumping too far
            if (Math.Abs(PiecePosition.PosX - newPosition.PosX) > 2 && Math.Abs(PiecePosition.PosY - newPosition.PosY) > 2)
                return false;

            //destination is not empty
            if (ExistsPieceInPosition(newPosition))
                return false;

            return true;
        }

        private bool IsValidPosition(Position position)
        {
            //avoid moving a piece "out of bounds"
            if (position.PosX > Board.HorizontalLenght && position.PosX <= 0 || position.PosY > Board.VerticalLenght && position.PosY <= 0)
                return false;
            return true;
        }
    }
}
