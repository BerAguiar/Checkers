

using System;

namespace Checkers
{
    interface Piece
    {
        Position PiecePosition { get; set; }
        ConsoleColor PieceColor { get; set; }
        public string PieceImage { get; }

        public int[] GetXY();

    }
}
