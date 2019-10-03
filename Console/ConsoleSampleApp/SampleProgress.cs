using System;
using System.Threading;
using Bessa.Console.Progress;

namespace ConsoleSampleApp
{
    class SampleProgress : ISample
    {
        public void Start()
        {
            Write("Welcome to ConsoleProgress sample!", ConsoleColor.Red);
            Write("This snippet shows some examples of how to simulate some loading in Console Applications.");

            SimpleLoading();
            BetterLoading();

            Console.WriteLine();
            Console.WriteLine("Congratulations, sample completely finished!");
            
            HelperMethods.WaitForKeyCombination();
        }


        void Write(string message, ConsoleColor color = ConsoleColor.White)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Thread.Sleep(1000);
        }

        void SimpleLoading()
        {
            Console.WriteLine();
            Console.Write("Loading...");

            for (var i = 0; i < 10; i++)
            {
                Thread.Sleep(200);
                Console.Write(".");
            }

            Console.WriteLine();
            Write("Simple loading finished!");
        }

        void BetterLoading()
        {
            Console.WriteLine();
            Write("We will now simulate a more complex loading sample, please wait!");

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Green;

            for (var i = 0; i <= 100; i++)
            {
                Thread.Sleep(20);
                ConsoleProgress.SetProgress(i, Console.WindowWidth);
            }

            Console.CursorVisible = true;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
        }
    }
}
