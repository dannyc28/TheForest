using static System.Console;

namespace TheForest
{
    class Program
    {
        static void Main(string[] args)
        {
            CursorVisible = false;

            Game myGame = new Game();
            myGame.Start();
        }
    }
}
