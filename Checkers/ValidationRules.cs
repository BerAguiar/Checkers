using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class ValidationRules
    {
        public Board Board { get; set; }
        public ValidationRules (Board board)
        {
            Board = board;
        }
        public void MovePiece(int deltaX, int deltaY, Piece piece)
        {
            if (!IsValidMove(deltaX,deltaY,piece) || ExistsPieceInPosition(new Position(piece.PiecePosition.GetPos()[0] + deltaX, piece.PiecePosition.GetPos()[1] + deltaY)))
                throw new ArgumentException("Can't make that move");
            else
                piece.PiecePosition.SetMove(deltaX, deltaY);
        }

        private bool ExistsPieceInPosition(Position position)
        {
            if (Board.Pieces.Exists(x => x.GetXY()[0] == position.GetPos()[0] && x.GetXY()[1] == position.GetPos()[1]))
                return true;
            return false;
        }
        private bool IsValidMove(int deltaX, int deltaY, Piece piece)
        {
            if (Math.Abs(deltaX) != 1 || deltaY <= -1 || deltaY > 1)
                return false;
            if (ExistsPieceInPosition(new Position(piece.PiecePosition.GetPos()[0]+deltaX, piece.PiecePosition.GetPos()[1] + deltaY)))
                return false;
            return true;
        }
    }
}
