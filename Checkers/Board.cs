using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Board
    {
        public int VerticalLenght { get; }
        public int HorizontalLenght { get; }
        public List<Piece> Pieces { get; }

        public Board(int verticalLenght, int horizontalLenght)
        {
            VerticalLenght = verticalLenght;
            HorizontalLenght = horizontalLenght;
            Pieces = new List<Piece>();
        }

        public void AddPiece(Piece piece)
        {
            Pieces.Add(piece);
        }
    }
}
