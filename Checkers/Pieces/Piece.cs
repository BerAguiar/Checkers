using Checkers.GameEnvironment;
using System;

namespace Checkers.Pieces
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

        public abstract bool MovePiece(Position position);

        public abstract bool CanMoveCheckerToPosition(Position position);
    }
}
