using System;

namespace Checkers
{
    abstract class Piece
    {
        public Position PiecePosition;
        public ConsoleColor PieceColor;
        public string PieceImage;

        public Board Board;
        public Piece(Position piecePosition, ConsoleColor pieceColor, Board board, string pieceImage)
        {
            PiecePosition = piecePosition;
            PieceColor = pieceColor;
            Board = board;
            PieceImage = pieceImage;
        }
        public abstract int[] GetXY();

        public abstract void MovePiece(Position position);
    }
}
