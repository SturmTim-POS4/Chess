using System;

namespace Chess
{
    public class Square
    {
        private int x;

        private int y;

        public Square(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        public override bool Equals(object obj)
        {
            return obj is Square square &&
                   x == square.x &&
                   y == square.y;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(x, y);
        }
    }
}
