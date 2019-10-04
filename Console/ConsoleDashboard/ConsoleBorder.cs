using System;
using System.Collections.Generic;
using System.Text;

namespace Bessa.Console.Dashboard
{
    class ConsoleBorder
    {
        internal void Render()
        {
            var headerTitle = "My Awesome App";
            var height = System.Console.WindowHeight;
            var width = System.Console.WindowWidth;
            var horizontalBorder = new string(SpecialCharacters.HorizontalBar, width - 2);

            System.Console.Clear();

            //Top Border
            System.Console.SetCursorPosition(0, 0);
            System.Console.Write(SpecialCharacters.TopLeftCorner);
            System.Console.Write(horizontalBorder);
            System.Console.Write(SpecialCharacters.TopRightCorner);

            //Header
            System.Console.SetCursorPosition(0, 1);
            System.Console.Write(SpecialCharacters.VerticalBar);
            System.Console.SetCursorPosition((width / 2) - (headerTitle.Length / 2), 1);
            System.Console.Write(headerTitle.ToUpperInvariant());
            System.Console.SetCursorPosition(width - 1, 1);
            System.Console.Write(SpecialCharacters.VerticalBar);

            //Header/MainPanel Separator
            System.Console.SetCursorPosition(0, 2);
            System.Console.Write(SpecialCharacters.VerticalRight);
            System.Console.Write(horizontalBorder);
            System.Console.Write(SpecialCharacters.VerticalLeft);
            
            //MainPanel
            for (var i = 3; i < 10; i++)
            {
                System.Console.SetCursorPosition(0, i);
                System.Console.Write(SpecialCharacters.VerticalBar);

                System.Console.SetCursorPosition(width - 1, i);
                System.Console.Write(SpecialCharacters.VerticalBar);
            }

            //MainPanel/LogPanel Separator
            System.Console.Write(SpecialCharacters.VerticalRight);
            System.Console.Write(horizontalBorder);
            System.Console.Write(SpecialCharacters.VerticalLeft);

            //LogPanel
            for (var i = 10; i < height - 1; i++)
            {
                System.Console.SetCursorPosition(0, i);
                System.Console.Write(SpecialCharacters.VerticalBar);

                System.Console.SetCursorPosition(width - 1, i);
                System.Console.Write(SpecialCharacters.VerticalBar);
            }

            //Bottom Border
            System.Console.Write(SpecialCharacters.BottomLeftCorner);
            System.Console.Write(horizontalBorder);
            System.Console.Write(SpecialCharacters.BottomRightCorner);
        }
    }
}
