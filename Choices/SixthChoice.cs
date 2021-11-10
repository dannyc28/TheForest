using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Choices
{
    class SixthChoice
    {
        public static void Run()
        {
            RandomEncounter.Run();
            RandomEncounter.Run();
            RandomEncounter.Run();

            string prompt = "\nYou find a larger path through the forest and start to follow it hoping it will lead you out..." +
                "\nAfter you walk the path for a while, you reach a crossroad...\nbut something feels off... What do you want to do?\n";
            string[] options = { "Go ahead", "Go back to your shelter", "Go back to the merchant"};
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    Inspect();
                    break;
                case 1:
                    GoShelter();
                    break;
                case 2:
                    GoMerchant();
                    break;
            }
        }
        public static void Inspect()
        {
            SecondBossEncounter.Run();
        }
        public static void GoShelter()
        {
            Console.Clear();
            Console.WriteLine("\nYou safely get back to your Shelter!");
            Console.WriteLine("You can now rest and replenish your Health and Mana over night!");
            Game.currentPlayer.health = Game.currentPlayer.maxHealth;
            Game.currentPlayer.mana = Game.currentPlayer.maxMana;
            UserInterface.WaitForKeyPress();
            Console.Clear();
            Console.WriteLine("\nThe next morning you go back...\n");
            UserInterface.WaitForKeyPress();

            SecondBossEncounter.Run();
        }
        public static void GoMerchant()
        {
            Shop.LoadShop(Game.currentPlayer);
            SecondBossEncounter.Run();
        }
    }
}
