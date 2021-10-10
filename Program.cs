using System;

namespace Chess
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Game game;
            while (true)
            {
                game = new Game();
                game.Start();
            }

        }
    }
}
