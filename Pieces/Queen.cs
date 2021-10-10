using System.Collections.Generic;

namespace Chess.Pieces
{
    class Queen : ChessPiece
    {
        public Queen(int color, int x, int y) : base(color, x, y)
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
            return base.Color == 0 ? "\u2655 " : "\u265B ";
        }

        public override List<Square> PossibaleMoves(List<ChessPiece> chessPieces)
        {
            List<Square> squares = new();
            squares.AddRange(VertikalMoves(chessPieces));
            squares.AddRange(DiagonalMoves(chessPieces));
            return squares;
        }

        private List<Square> VertikalMoves(List<ChessPiece> chessPieces)
        {
            List<Square> usedSquares = new();

            foreach (ChessPiece chessPiece in chessPieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            List<Square> squares = new();

            for (int i = base.X + 1; i <= 8; i++)
            {
                Square square = new(i, base.Y);
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

            for (int i = base.X - 1; i > 0; i--)
            {
                Square square = new(i, base.Y);
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


            for (int i = base.Y + 1; i <= 8; i++)
            {
                Square square = new(base.X, i);
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

            for (int i = base.Y - 1; i > 0; i--)
            {
                Square square = new(base.X, i);
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

        private List<Square> DiagonalMoves(List<ChessPiece> chessPieces)
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
