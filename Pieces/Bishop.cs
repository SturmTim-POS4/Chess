using System.Collections.Generic;

namespace Chess.Pieces
{
    class Bishop : ChessPiece
    {
        public Bishop(int color, int x, int y) : base(color, x, y)
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
            return base.Color == 0 ? "\u2657 " : "\u265D ";
        }

        public override List<Square> PossibaleMoves(List<ChessPiece> chessPieces)
        {
            List<Square> usedSquares = new();

            foreach (ChessPiece chessPiece in chessPieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            List<Square> squares = new();

            for (int i = base.X + 1, j = base.Y + 1; i <= 8 && j <= 8; i++, j++)
            {
                Square square = new(i, j);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                        break;
                    };
                    break;
                }
                squares.Add(square);
            }

            for (int i = base.X + 1, j = base.Y - 1; i <= 8 && j > 0; i++, j--)
            {
                Square square = new(i, j);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                        break;
                    };
                    break;
                }
                squares.Add(square);
            }

            for (int i = base.X - 1, j = base.Y + 1; i > 0 && j <= 8; i--, j++)
            {
                Square square = new(i, j);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                        break;
                    };
                    break;
                }
                squares.Add(square);
            }

            for (int i = base.X - 1, j = base.Y - 1; i > 0 && j > 0; i--, j--)
            {
                Square square = new(i, j);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                        break;
                    };
                    break;
                }
                squares.Add(square);
            }

            return squares;
        }
    }
}
