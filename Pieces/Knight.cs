using System.Collections.Generic;

namespace Chess.Pieces
{
    class Knight : ChessPiece
    {
        public Knight(int color, int x, int y) : base(color, x, y)
        {
        }

        public override bool CanMove(int xTo, int yTo, List<ChessPiece> chessPieces)
        {
            Square square = new(xTo, yTo);
            var squares = PossibaleMoves(chessPieces);
            return squares.Contains(square);
        }

        public override string GetColorUnicode()
        {
            return base.Color == 0 ? "\u2658 " : "\u265E ";
        }

        public override List<Square> PossibaleMoves(List<ChessPiece> chessPieces)
        {
            List<Square> usedSquares = new();

            foreach (ChessPiece chessPiece in chessPieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            List<Square> squares = new();

            squares.Add(new Square(base.X + 2, base.Y + 1));
            squares.Add(new Square(base.X + 2, base.Y - 1));
            squares.Add(new Square(base.X - 2, base.Y + 1));
            squares.Add(new Square(base.X - 2, base.Y - 1));
            squares.Add(new Square(base.X + 1, base.Y + 2));
            squares.Add(new Square(base.X - 1, base.Y + 2));
            squares.Add(new Square(base.X + 1, base.Y - 2));
            squares.Add(new Square(base.X - 1, base.Y - 2));

            List<Square> tempSquares = new();
            tempSquares.AddRange(squares);

            foreach (Square square in tempSquares)
            {
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color == base.Color)
                    {
                        squares.Remove(square);
                    };
                }
                else if (square.X > 8 || square.Y > 8 || square.X < 1 || square.Y < 1)
                {
                    squares.Remove(square);
                }
            }
            return squares;
        }
    }
}
