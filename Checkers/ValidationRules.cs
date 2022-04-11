﻿using System;
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
        public bool CanMoveCheckerToPosition(Position newPosition, Piece piece)
        {
            if (!IsValidPosition(newPosition))
                return false;
            
            if (!IsValidRegularMove(newPosition,piece))
            {
                if (IsValidCaptureMove(newPosition, piece))
                {
                    //piece.PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
                    return true;
                }
                return false;
            }       
            //piece.PiecePosition.SetMove(newPosition.PosX, newPosition.PosY);
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
            if (!Board.Pieces.Exists(x => Math.Abs(piece.PiecePosition.PosX - x.PiecePosition.PosX) == 1 
                    && Math.Abs(piece.PiecePosition.PosY - x.PiecePosition.PosY) == 1 && x.PieceColor != MyColor)) 
                    return false;

            if (Math.Abs(piece.PiecePosition.PosX - newPosition.PosX) > 2 || Math.Abs(piece.PiecePosition.PosY - newPosition.PosY) > 2)
                return false;

            if (ExistsPieceInPosition(newPosition))
                return false;

            return true;
        }

        private bool IsValidPosition(Position position)
        {
            if (position.PosX > Board.HorizontalLenght && position.PosX >= 0 || position.PosY > Board.VerticalLenght && position.PosY >= 0)
                return false;
            return true;
        }

    }
}
