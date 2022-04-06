using System;
using System.Collections.Generic;
using System.Text;

namespace Checkers
{
    class Position
    {
        private int PosX { get; set; }
        private int PosY { get; set; }
        public Position(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }



        public void SetPosition(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }



        public void SetMove(int deltaX, int deltaY)
        {
            PosX += deltaX;
            PosY += deltaY;
        }



        public int[] GetPos()
        {
            return new int[2] { PosX, PosY };
        }
    }
}
