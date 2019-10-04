using Bessa.Console.Dashboard;

namespace ConsoleSampleApp
{
    class SampleDashboard : ISample
    {
        public void Start()
        {
            var dashBoard = new ConsoleDashboard();
            dashBoard.Start();

            HelperMethods.WaitForKeyCombination(false);
        }
    }
}
