using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

namespace Bessa.Console.Menu
{
    public class ConsoleMenu<T>
    {
        private const int HeaderLeft = 5;
        private const int HeaderTop = 2;
        private const int MenuLeft = 7;
        private const int MenuTop = 5;
        
        private readonly string _header;
        private readonly string _message;
        private readonly Dictionary<string, T> _menuOptions;
        private readonly string[] _menuItems;

        private T _selectedOption;

        public ConsoleMenu(string header, string message, Dictionary<string, T> menuOptions)
        {
            _header = header;
            _message = message;
            _menuOptions = menuOptions;
            _menuItems = _menuOptions.Keys.ToArray();
        }

        public T WaitForOption()
        {
            using var waitHandle = new AutoResetEvent(false);

            System.Console.CursorVisible = false;
            Render();

            ThreadPool.QueueUserWorkItem(MenuLoop, waitHandle, true);
            waitHandle.WaitOne();

            return _selectedOption;
        }

        private void Render()
        {
            System.Console.Clear();

            System.Console.SetCursorPosition(HeaderLeft, HeaderTop);
            System.Console.Write(_header);

            System.Console.SetCursorPosition(MenuLeft, MenuTop - 1);
            System.Console.Write(_message);
            
            SwitchColor();

            for (var i = 0; i < _menuItems.Length; i++)
            {
                System.Console.SetCursorPosition(MenuLeft, MenuTop + i);
                System.Console.Write(_menuItems[i]);

                if (i == 0)
                {
                    SwitchColor();
                }
            }
        }

        private void MenuLoop(AutoResetEvent waitHandle)
        {
            var selectedItem = 0;

            while (true)
            {
                var oldItem = selectedItem;

                switch (System.Console.ReadKey(true).Key)
                {
                    case ConsoleKey.UpArrow:
                        selectedItem--;
                        break;

                    case ConsoleKey.DownArrow:
                        selectedItem++;
                        break;

                    case ConsoleKey.Enter:
                        var key = _menuItems[selectedItem];
                        _selectedOption = _menuOptions[key];
                        waitHandle.Set();
                        return;

                    case ConsoleKey.Escape:
                        _selectedOption = default;
                        waitHandle.Set();
                        return;
                }

                if (selectedItem == _menuItems.Length)
                {
                    selectedItem = 0;
                }
                else if (selectedItem < 0)
                {
                    selectedItem = _menuItems.Length - 1;
                }
                
                System.Console.SetCursorPosition(MenuLeft, MenuTop + oldItem);
                System.Console.Write(_menuItems[oldItem]);

                SwitchColor();

                System.Console.SetCursorPosition(MenuLeft, MenuTop + selectedItem);
                System.Console.Write(_menuItems[selectedItem]);

                SwitchColor();
            }
        }

        private static void SwitchColor()
        {
            var oldForegroundColor = System.Console.ForegroundColor;
            System.Console.ForegroundColor = System.Console.BackgroundColor;
            System.Console.BackgroundColor = oldForegroundColor;
        }
    }

}
