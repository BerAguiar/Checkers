namespace Checkers
{
    class Position
    {
        public int PosX { get; private set; }
        public int PosY { get; private set; }
        public Position(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public void SetMove(int posX, int posY)
        {
            PosX = posX;
            PosY = posY;
        }

        public int[] GetPos()
        {
            return new int[2] { PosX, PosY };
        }
    }
}
