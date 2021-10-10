using System.Collections.Generic;

namespace Chess.Pieces
{
    public abstract class ChessPiece
    {
        private int y;
        private int x;
        private int color;

        public abstract bool CanMove(int xTo, int yTo, List<ChessPiece> chessPieces);

        public abstract List<Square> PossibaleMoves(List<ChessPiece> chessPieces);

        public abstract string GetColorUnicode();

        public int Color { get => color; set => color = value; }
        public int X { get => x; set => x = value; }
        public int Y { get => y; set => y = value; }

        protected ChessPiece(int color, int x, int y)
        {
            Color = color;
            this.X = x;
            this.Y = y;
        }
    }
}
