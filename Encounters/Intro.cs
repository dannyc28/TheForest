using System;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class Intro 
    {

        public static void Run()
        {
            UserInterface.StopMusic();
            Console.Clear();

            while (true)
            {
                Console.Write("\nEnter your Name: ");
                Game.currentPlayer.name = Console.ReadLine();
                if (Game.currentPlayer.name.Length > 25)
                    Game.currentPlayer.name = Game.currentPlayer.name.Substring(0, 25);
                if (Game.currentPlayer.name != "" && Game.currentPlayer.name != null && Game.currentPlayer.name !=" ")
                    break;
            }
            Console.Clear();
            string prompt = "\nChoose your Class:\n";
            string[] options = { "Warrior", "Rogue", "Mage" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Game.currentPlayer.currentClass = Player.PlayerClass.Warrior;
                    break;
                case 1:
                    Game.currentPlayer.currentClass = Player.PlayerClass.Rogue;
                    break;
                case 2:
                    Game.currentPlayer.currentClass = Player.PlayerClass.Mage;
                    break;
            }

            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou awake in the cold, wet grass. It looks like you are in a forest. ");
            UserInterface.TypeWithAnimation("You feel dazed and are having trouble remembering anything...");
            UserInterface.TypeWithAnimation("\nYou only know your name is " + Game.currentPlayer.name + ".\n");

            UserInterface.WaitForKeyPress();
            Console.Clear();

            FirstChoice.Run();
        }
    }
}
