using System.Text;

namespace Bessa.Console.Progress
{
    public class ConsoleProgress
    {
        private const char LightShade = '░';
        private const char FullBlock = '█';

        public static void SetProgress(int percentage, int totalWidth = 50)
        {
            var buffer = new StringBuilder();
            var width = totalWidth - 6;

            var progress = percentage * width / 100;

            for (var i = 0; i < width; i++)
            {
                buffer.Append(i <= progress ? FullBlock : LightShade);
            }

            buffer.Append($" {percentage}%");
            
            System.Console.SetCursorPosition(0, System.Console.CursorTop);
            System.Console.Write(buffer);
        }
    }
}
