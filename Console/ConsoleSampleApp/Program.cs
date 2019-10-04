using System;
using System.Linq;
using System.Reflection;
using Bessa.Console.Menu;
using Bessa.Reflection;

namespace ConsoleSampleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            var samples = ReflectionHelper.GetAllClassesWithInterface<ISample>().ToDictionary(t => t.Name, t => t);
            var menu = new ConsoleMenu<Type>("Welcome to Console Samples", "Choose an option (ESC to exit):", samples);
            
            var selectedOption = menu.WaitForOption();

            while (selectedOption != null)
            {
                Console.Clear();

                var sample = (ISample)Activator.CreateInstance(selectedOption);
                sample.Start();

                selectedOption = menu.WaitForOption();
            }

            Console.Clear();
            Console.ResetColor();
        }
    }
}
