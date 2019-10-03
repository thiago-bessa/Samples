using System;
using System.Collections.Generic;
using System.Text;
using Bessa.Console.Menu;

namespace ConsoleSampleApp
{
    class SampleMenu : ISample
    {
        enum SampleResults
        {
            Exit = 0, //Exit is 0 to default to it when pressing ESC in the menu
            White,
            Red,
            Green,
            Blue,
            Yellow,
            Magenta
        }

        public void Start()
        {
            var menuOptions = new Dictionary<string, SampleResults>
            {
                {"White", SampleResults.White},
                {"Red", SampleResults.Red},
                {"Green", SampleResults.Green},
                {"Blue", SampleResults.Blue},
                {"Yellow", SampleResults.Yellow},
                {"Magenta", SampleResults.Magenta},
                {"Exit Sample", SampleResults.Exit},
            };

            var menu = new ConsoleMenu<SampleResults>("Console Menu Sample", "Choose new color:", menuOptions);


            while (true)
            {
                var selectedOption = menu.WaitForOption();

                switch (selectedOption)
                {
                    case SampleResults.White:
                        Console.ForegroundColor = ConsoleColor.White;
                        break;

                    case SampleResults.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        break;

                    case SampleResults.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        break;

                    case SampleResults.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        break;

                    case SampleResults.Yellow:
                        Console.ForegroundColor = ConsoleColor.Yellow;
                        break;

                    case SampleResults.Magenta:
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        break;

                    case SampleResults.Exit:
                        goto exit;
                }
            }

            exit:
            Console.BackgroundColor = ConsoleColor.Black;
            Console.ForegroundColor = ConsoleColor.Gray;
            HelperMethods.WaitForKeyCombination();
        }
    }
}
