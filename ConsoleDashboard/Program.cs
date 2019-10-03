using System;
using System.Threading;

namespace ConsoleDashboard
{
    class Program
    {
        static void Main(string[] args)
        {
            var waitHandle = new AutoResetEvent(false);
            Console.CancelKeyPress += CancelKeyPress;

            Console.WriteLine("Hello World!");

            ThreadPool.QueueUserWorkItem(Process, waitHandle, false);

            waitHandle.WaitOne();
        }

        private static void CancelKeyPress(object sender, ConsoleCancelEventArgs e)
        {
            e.Cancel = true;
        }

        private static void Process(AutoResetEvent waitHandle)
        {
            while (true)
            {
                var keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.F4 && keyPressed.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    waitHandle.Set();
                }
            }
        }
    }
}
