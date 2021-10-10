using System;
using System.Collections.Generic;

namespace Chess
{
    class ChessBoard
    {
        public void BuildBoard(List<Pieces.ChessPiece> pieces)
        {

            List<Square> usedSquares = new();

            foreach (Pieces.ChessPiece chessPiece in pieces)
            {
                usedSquares.Add(new Square(chessPiece.X, chessPiece.Y));
            }

            Console.Write("");

            for (int y = 8; y >= 1; y--)
            {
                PrintCelling();
                Console.Write($"{y}");
                Console.ForegroundColor = ConsoleColor.Black;
                Console.BackgroundColor = ConsoleColor.Gray;
                for (int x = 1; x <= 8; x++)
                {
                    Square square = new(x, y);
                    if (usedSquares.Contains(square))
                    {
                        Console.Write($"| ");
                        if (pieces[usedSquares.IndexOf(new Square(x, y))].Color == 0)
                        {
                            Console.ForegroundColor = ConsoleColor.White;
                            Console.Write($"{pieces[usedSquares.IndexOf(new Square(x, y))].GetColorUnicode()} ");
                        }
                        else
                        {
                            Console.ForegroundColor = ConsoleColor.Black;
                            Console.Write($"{pieces[usedSquares.IndexOf(new Square(x, y))].GetColorUnicode()} ");
                        }
                        Console.ForegroundColor = ConsoleColor.Black;
                    }
                    else
                    {
                        Console.Write("|    ");
                    }
                }
                Console.WriteLine("|");
                Console.BackgroundColor = ConsoleColor.Black;
            }
            PrintCelling();

            Console.BackgroundColor = ConsoleColor.Black;

            Console.Write("   a  ");
            Console.Write("  b  ");
            Console.Write("  c  ");
            Console.Write("  d  ");
            Console.Write("  e  ");
            Console.Write("  f  ");
            Console.Write("  g  ");
            Console.WriteLine("  h   ");

        }



        private void PrintEmptyRow(int number)
        {
            Console.Write($"{number}|");
            for (int i = 0; i < 7; i++)
            {
                Console.Write("    |");
            }
            Console.WriteLine("    |");
            PrintCelling();
        }

        private static void PrintCelling()
        {
            Console.Write(" ");
            Console.ForegroundColor = ConsoleColor.Black;
            Console.BackgroundColor = ConsoleColor.Gray;
            for (int i = 0; i < 40; i++)
            {
                Console.Write("-");
            }
            Console.WriteLine("-");
            Console.ForegroundColor = ConsoleColor.White;
            Console.BackgroundColor = ConsoleColor.Black;
        }
    }
}
