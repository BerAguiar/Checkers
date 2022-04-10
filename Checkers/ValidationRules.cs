using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class ValidationRules
    {
        public Board Board { get; set; }
        public ConsoleColor MyColor { get; set; }
        public ValidationRules (Board board, ConsoleColor myColor)
        {
            Board = board;
            MyColor = myColor;
        }
        public bool MovePiece(int deltaX, int deltaY, Piece piece)
        {
            if (!IsValidRegularMove(deltaX,deltaY,piece) && !IsValidCaptureMove(deltaX, deltaY, piece))
            {
                return false;
            }
            else
            {
                piece.PiecePosition.SetMove(deltaX, deltaY);
                return true;
            }   
        }
        private bool ExistsPieceInPosition(Position position)
        {
            if (Board.Pieces.Exists(x => x.GetXY()[0] == position.GetPos()[0] && x.GetXY()[1] == position.GetPos()[1]))
                return true;
            return false;
        }
        private bool IsValidRegularMove(int deltaX, int deltaY, Piece piece)
        {
            if (Math.Abs(deltaX) != 1 || deltaY <= -1 || deltaY > 1)
                return false;
            if (ExistsPieceInPosition(new Position(piece.PiecePosition.GetPos()[0]+deltaX, piece.PiecePosition.GetPos()[1] + deltaY)))
                return false;
            return true;
        }
        private bool IsValidCaptureMove(int deltaX, int deltaY, Piece piece)
        {
 
            if (Math.Abs(deltaX) > 2 || Math.Abs(deltaY) > 2)
                return false;
            if (ExistsPieceInPosition(new Position(piece.PiecePosition.GetPos()[0] + deltaX, piece.PiecePosition.GetPos()[1] + deltaY)))
                return false;

            return true;
        }
        private bool MovePieceToCapture(int deltaX, int deltaY, Piece piece)
        {
            if (ExistsPieceInPosition(new Position(piece.PiecePosition.GetPos()[0] + deltaX, piece.PiecePosition.GetPos()[1] + deltaY)) 
                        && piece.PieceColor != Board.Pieces.Find(x => x.PiecePosition.GetPos()[0] == piece.PiecePosition.GetPos()[0] + deltaX 
                            && x.PiecePosition.GetPos()[1] == piece.PiecePosition.GetPos()[1] + deltaY).PieceColor)
                return true;
            return false;
        }

    }
}
