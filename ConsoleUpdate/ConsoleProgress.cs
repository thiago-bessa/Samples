using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleUpdate
{
    public class ConsoleProgress
    {
        private const char _lightShade = '░';
        private const char _fullBlock = '█';

        public static void SetProgress(int percentage, int totalWidth = 50)
        {
            var buffer = new StringBuilder();
            var width = totalWidth - 6;

            var progress = percentage * width / 100;

            for (var i = 0; i < width; i++)
            {
                buffer.Append(i <= progress ? _fullBlock : _lightShade);
            }

            buffer.Append($" {percentage}%");
            
            Console.SetCursorPosition(0, Console.CursorTop);
            Console.Write(buffer);
        }
    }
}
