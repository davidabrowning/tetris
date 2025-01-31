namespace Tetris
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Choose to run tests or launch game by commenting one out:
            RunTests();
            //LaunchGame();
        }
        private static void RunTests()
        {
            TestRunner testRunner = new TestRunner();
            testRunner.Go();
        }
        private static void LaunchGame()
        {
            GameLauncher gameLauncher = new GameLauncher();
            gameLauncher.Go();
            return;
        }
    }
}
