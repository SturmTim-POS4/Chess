using System;
using System.Collections.Generic;

namespace Chess
{
    class Game
    {

        List<Pieces.ChessPiece> pieces = new();
        ChessBoard chessBoard = new();

        public void Start()
        {
            fillList();
            chessBoard.BuildBoard(pieces);
            while (true)
            {
                Console.WriteLine("White Turn: ");
                if (Turn(0))
                {
                    Console.Clear();
                    Console.WriteLine("White Won!");
                    break;
                }
                Console.Clear();
                chessBoard.BuildBoard(pieces);
                Console.WriteLine("Black Turn: ");
                if (Turn(1))
                {
                    Console.Clear();
                    Console.WriteLine("Black Won!");
                    break;
                }
                chessBoard.BuildBoard(pieces);
            }
            chessBoard.BuildBoard(pieces);
        }

        public bool Turn(int color)
        {
            bool possible = false;

            while (!possible)
            {
                try
                {
                    string userInput = Console.ReadLine();
                    String[] posistions = userInput.Split("-");

                    int x = (posistions[0].ToUpper().ToCharArray()[0] - 'A') + 1;
                    int y = Int32.Parse(posistions[0].ToCharArray()[1].ToString());
                    Square from = new(x, y);

                    int xTo = (posistions[1].ToUpper().ToCharArray()[0] - 'A') + 1;
                    int yTo = Int32.Parse(posistions[1].ToCharArray()[1].ToString());
                    Square to = new(xTo, yTo);
                    possible = IsMovePossible(color, from, to);
                    if (possible)
                    {
                        return DoMove(from, to);
                    }
                }
                catch (Exception ex)
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid Input");
                    Console.BackgroundColor = ConsoleColor.Black;
                };
            }
            return false;
        }

        private bool DoMove(Square from, Square to)
        {
            List<Square> usedSquares = new();

            foreach (Pieces.ChessPiece chessPiece in pieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            if (usedSquares.Contains(to))
            {
                Pieces.King king = new(0, 1, 1);
                if (pieces[usedSquares.IndexOf(to)].GetType() == king.GetType())
                {
                    pieces[usedSquares.IndexOf(from)].X = to.X;
                    pieces[usedSquares.IndexOf(from)].Y = to.Y;
                    pieces.Remove(pieces[usedSquares.IndexOf(to)]);
                    return true;
                }
                pieces.Remove(pieces[usedSquares.IndexOf(to)]);
            }

            pieces[usedSquares.IndexOf(from)].X = to.X;
            pieces[usedSquares.IndexOf(from)].Y = to.Y;

            return false;

        }

        private bool IsMovePossible(int color, Square from, Square to)
        {
            List<Square> usedSquares = new();

            foreach (Pieces.ChessPiece chessPiece in pieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            if (usedSquares.Contains(from))
            {
                if (pieces[usedSquares.IndexOf(from)].Color == color)
                {
                    if (!pieces[usedSquares.IndexOf(from)].CanMove(to.X, to.Y, pieces))
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        Console.WriteLine("You are not allowed to move to this position!");
                        Console.BackgroundColor = ConsoleColor.Black;
                    }
                    return pieces[usedSquares.IndexOf(from)].CanMove(to.X, to.Y, pieces);
                }
                else
                {
                    Console.BackgroundColor = ConsoleColor.Red;
                    Console.WriteLine("You can't use a diffrent color!");
                    Console.BackgroundColor = ConsoleColor.Black;
                    return false;
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.Red;
                Console.WriteLine("No piece to move!");
                Console.BackgroundColor = ConsoleColor.Black;
                return false;

            }
        }

        public void fillList()
        {
            pieces.Add(new Pieces.Rook(1, 1, 8));
            pieces.Add(new Pieces.Knight(1, 2, 8));
            pieces.Add(new Pieces.Bishop(1, 3, 8));
            pieces.Add(new Pieces.King(1, 4, 8));
            pieces.Add(new Pieces.Queen(1, 5, 8));
            pieces.Add(new Pieces.Bishop(1, 6, 8));
            pieces.Add(new Pieces.Knight(1, 7, 8));
            pieces.Add(new Pieces.Rook(1, 8, 8));

            pieces.Add(new Pieces.Rook(0, 1, 1));
            pieces.Add(new Pieces.Knight(0, 2, 1));
            pieces.Add(new Pieces.Bishop(0, 3, 1));
            pieces.Add(new Pieces.Queen(0, 4, 1));
            pieces.Add(new Pieces.King(0, 5, 1));
            pieces.Add(new Pieces.Bishop(0, 6, 1));
            pieces.Add(new Pieces.Knight(0, 7, 1));
            pieces.Add(new Pieces.Rook(0, 8, 1));


            for (int i = 1; i <= 8; i++)
            {
                pieces.Add(new Pieces.Pawn(1, i, 7));
                pieces.Add(new Pieces.Pawn(0, i, 2));
            }

        }
    }
}
