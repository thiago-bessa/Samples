using System;
using System.Threading;

namespace ConsoleSampleApp
{
    class HelperMethods
    {
        internal static void WaitForKeyCombination()
        {
            Console.SetCursorPosition(0, Console.WindowHeight);
            Console.WriteLine("Press CTRL + F4 to exit sample...");

            using var waitHandle = new AutoResetEvent(false);
            ThreadPool.QueueUserWorkItem(WaitLoop, waitHandle, true);
            waitHandle.WaitOne();
        }

        private static void WaitLoop(AutoResetEvent waitHandle)
        {
            while (true)
            {
                var keyPressed = Console.ReadKey(true);

                if (keyPressed.Key == ConsoleKey.F4 && keyPressed.Modifiers.HasFlag(ConsoleModifiers.Control))
                {
                    waitHandle.Set();
                    return;
                }
            }
        }
    }
}
