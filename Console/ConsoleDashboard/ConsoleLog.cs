using System;
using System.Collections.Generic;
using System.Text;

namespace Bessa.Console.Dashboard
{
    public class ConsoleLog
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _top = 11;
        private readonly int _left = 2;

        private int _lastWrittenLine;
        
        public ConsoleLog()
        {
            _width = System.Console.WindowWidth - 2;
            _height = System.Console.WindowHeight - 12;
        }

        public void Start()
        {
            _lastWrittenLine = 0;
        }

        public void Append(string message)
        {

            //Calculate new height
            var messageHeight = (int) Math.Ceiling((double) message.Length / _width);

            //Break message in lines
            var lines = new List<string>();
            var currentPosition = 0;

            while (currentPosition < message.Length)
            {
                lines.Add(currentPosition + _width < message.Length
                    ? message.Substring(currentPosition, _width - 2)
                    : message.Substring(currentPosition));

                currentPosition += _width - 2;
            }

            //Check if a buffer move is needed
            var shouldMove = _top + _lastWrittenLine > _height;

            //Move buffer to accomodate new message
            if (shouldMove)
            {
                System.Console.MoveBufferArea(_left, _top + messageHeight, _width - 1, _height - messageHeight, _left, _top);
            }

            //Write new content
            for (var i = 0; i < lines.Count; i++)
            {
                if (shouldMove)
                {
                    System.Console.SetCursorPosition(_left, _top + _height - messageHeight + i);
                }
                else
                {
                    System.Console.SetCursorPosition(_left, _top + _lastWrittenLine);
                    _lastWrittenLine++;
                }

                System.Console.Write(lines[i]);
            }
        }
    }
}
