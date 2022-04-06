using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Queen : Piece
    {
        public Position PiecePosition { get; set; }
        public ConsoleColor PieceColor { get; set; }
        public string PieceImage { get { return "\u2660"; } }

        public Queen(Position position, ConsoleColor color)
        {
            PiecePosition = position;
            PieceColor = color;
        }



        public int[] GetXY()
        {
            return PiecePosition.GetPos();
        }
    }
}
