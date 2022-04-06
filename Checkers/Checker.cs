using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Checker : Piece
    {
        public Position PiecePosition { get; set; }
        public ConsoleColor PieceColor { get; set; }
        public string PieceImage { get { return "\u25cf"; } }

        public Checker(Position position, ConsoleColor color)
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
