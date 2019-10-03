using System;
using System.Threading;

namespace ConsoleUpdate
{
    class Program
    {
        static void Main(string[] args)
        {
           Console.Beep();
           Write("Welcome to ConsoleUpdate sample!", ConsoleColor.Red);
           Write("This snippet shows some examples of how to simulate some loading in Console Applications.");
           
           SimpleLoading();
           BetterLoading();

           Write("Congratulations, sample completely finished!");
           
        }

        static void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        static void SimpleLoading()
        {
            Console.WriteLine();
            Console.Write("Loading...");

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(500);
                Console.Write(".");
            }

            Console.WriteLine();
            Write("Simple loading finished!");
        }

        static void BetterLoading()
        {
            Console.WriteLine();
            Write("We will now simulate a more complex loading sample, please wait!");

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;

            for (var i = 0; i <= 100; i++)
            {
                Thread.Sleep(100);
                ConsoleProgress.SetProgress(i, Console.WindowWidth);
            }

            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
