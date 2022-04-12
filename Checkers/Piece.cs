

using System;

namespace Checkers
{
    abstract class Piece
    {
        public Position PiecePosition { get; }
        public ConsoleColor PieceColor { get; }
        
        public string PieceImage { get; }

        public Board Board { get; }
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
