using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Choices
{
    class FifthChoice
    {
        public static void Run()
        {
            RandomEncounter.Run();
            RandomEncounter.Run();
            
            string prompt = "\nYou stumble upon a small wooden cabin...\nWhat do you want to do?\n";
            string[] options = { "Go ahead", "Go back to your shelter", "Go back to the merchant" };
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
            FirstBossEncounter.Run();
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

            FirstBossEncounter.Run();
        }
        public static void GoMerchant()
        {
            Shop.LoadShop(Game.currentPlayer);
            FirstBossEncounter.Run();
        }
    }
}
