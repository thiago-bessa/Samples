using System.Threading;

namespace Bessa.Console.Dashboard
{
    public class ConsoleDashboard
    {
        private ConsoleBorder Border { get; }
        
        public ConsoleLog Log { get; }

        public ConsoleDashboard()
        {
            Border = new ConsoleBorder();
            Log = new ConsoleLog();
        }

        public void Start()
        {
            System.Console.CursorVisible = false;
            System.Console.Clear();
            
            Border.Render();
            Log.Start();

            var a = "Lorem ipsum dolor sit amet, consectetur adipiscing elit. Maecenas at pulvinar tellus, ac eleifend ex. Pellentesque congue non risus id suscipit. Suspendisse imperdiet placerat felis et maximus.";
            var b = "Etiam nulla diam, dignissim non nisi et, hendrerit eleifend erat.";
            var c = "Sed a ligula mattis, euismod ligula nec, faucibus erat. Integer quam neque, consequat a bibendum nec, pellentesque in diam. Sed nisi diam, bibendum vel libero eu, volutpat hendrerit velit. Nunc tincidunt interdum sem, efficitur gravida ex posuere nec. Donec venenatis, elit vel eleifend dictum, massa lectus volutpat odio, sit amet mollis arcu dolor id eros. ";

            while (true)
            {
                Log.Append(a);
                Thread.Sleep(500);

                Log.Append(b);
                Thread.Sleep(500);

                Log.Append(c);
                Thread.Sleep(500);
            }
        }
    }
}
