namespace SnakeMess
{
    public class Point
    {
        public int PosX { get; set; }
        public int PosY { get; set; }

        public Point(int x = 0, int y = 0) {
            PosX = x;
            PosY = y;

        }

        public Point(Point input) {
            PosX = input.PosX;
            PosY = input.PosY;
        }
    }
}