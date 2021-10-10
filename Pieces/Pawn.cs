using System.Collections.Generic;

namespace Chess.Pieces
{
    class Pawn : ChessPiece
    {
        bool firstMove = true;

        public Pawn(int color, int x, int y) : base(color, x, y)
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
            return base.Color == 0 ? "\u2659 " : "\u265F";
        }

        public override List<Square> PossibaleMoves(List<ChessPiece> chessPieces)
        {
            List<Square> usedSquares = new();

            foreach (ChessPiece chessPiece in chessPieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            List<Square> squares = new();

            if (Color == 0)
            {
                Square square = new(X, Y + 1);
                if (!usedSquares.Contains(square) && square.Y <= 8)
                {
                    squares.Add(square);
                    if (firstMove)
                    {
                        Square firstMoveSquare = new(X, Y + 2);
                        if (!usedSquares.Contains(firstMoveSquare) && firstMoveSquare.Y <= 8)
                        {
                            squares.Add(firstMoveSquare);
                        }
                    }
                }
                square = new(X + 1, Y + 1);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                    }
                }
                square = new(X - 1, Y + 1);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                    }
                }
            }
            else
            {
                Square square = new(X, Y - 1);
                if (!usedSquares.Contains(square) && square.Y > 0)
                {
                    squares.Add(square);
                    if (firstMove)
                    {
                        Square firstMoveSquare = new(X, Y - 2);
                        if (!usedSquares.Contains(firstMoveSquare) && firstMoveSquare.Y > 0)
                        {
                            squares.Add(firstMoveSquare);
                        }
                    }
                }
                square = new(X + 1, Y - 1);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                    }
                }
                square = new(X - 1, Y - 1);
                if (usedSquares.Contains(square))
                {
                    if (chessPieces[usedSquares.IndexOf(square)].Color != base.Color)
                    {
                        squares.Add(square);
                    }
                }
            }

            return squares;
        }
    }
}
