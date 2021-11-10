using TheForest.Encounters;
using TheForest.Choices;

namespace TheForest
{
    class Game
    {
        public static Player currentPlayer;

        public Game()
        {
            currentPlayer = new Player();
            
        }
        public void Start()
        {
            UserInterface.LoadingFirstScreen();
        }
    }
}
