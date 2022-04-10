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
        public bool MovePiece(Position newPosition, Piece piece)
        {
            if (!IsValidRegularMove(newPosition,piece))
            {
                if (IsValidCaptureMove(newPosition, piece))
                {
                    piece.PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
                    return true;
                }
                return false;
            }       
            piece.PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
            return true;
        }
        private bool ExistsPieceInPosition(Position position)
        {
            if (Board.Pieces.Exists(x => x.PiecePosition.PosX == position.PosX && x.PiecePosition.PosY == position.PosY))
                return true;
            return false;
        }
        private bool IsValidRegularMove(Position newPosition, Piece piece)
        {
            if (Math.Abs(piece.PiecePosition.PosX - newPosition.PosX) != 1 || piece.PiecePosition.PosY <= -1 || newPosition.PosY > 1)
                return false;
            if (ExistsPieceInPosition(newPosition))
                return false;
            return true;
        }
        private bool IsValidCaptureMove(Position newPosition, Piece piece)
        {
            if(ExistsPieceInPosition(new Position(piece.PiecePosition.PosX+1, piece.PiecePosition.PosY + 1)))

            if (Math.Abs(piece.PiecePosition.PosX - newPosition.PosX) > 2 || Math.Abs(piece.PiecePosition.PosY - newPosition.PosY) > 2)
                return false;
            if (ExistsPieceInPosition(newPosition))
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
