using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Choices
{
    class ThirdChoice
    {
        public static void Run()
        {
            string prompt = "\nYou continue your journey... \nWhat do you want to do?\n";
            string[] options = { "Explore forest", "Take a break", "Go back to your shelter", "Go back to the merchant" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ExploreForest();
                    break;
                case 1:
                    DoNothing();
                    break;
                case 2:
                    GoShelter();
                    break;
                case 3:
                    GoMerchant();
                    break;
            }
        }

        public static void ExploreForest()
        {
            RandomEncounter.Run();
            RandomEncounter.Run();

            string prompt = "\nYou eventually find a path in the forest! \nWhat do you want to do?\n";
            string[] options = { "Go left", "Go right" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou find a small bag on the ground, someone must've left in a hurry...");
                        Console.WriteLine("\nRewards:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n+ 15 Gold coins!\n");
                        Console.ResetColor();
                        Game.currentPlayer.coins += 15;
                        UserInterface.WaitForKeyPress();
                        OgreEncounter.Run();
                        break;
                    }
                case 1:
                    {
                        Console.Clear();
                        Console.WriteLine("\nYou find a pretty large bag on the ground, someone must've left in a hurry...");
                        Console.WriteLine("\nRewards:");
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine("\n+ 50 Gold coins!\n");
                        Console.ResetColor();
                        Game.currentPlayer.coins += 50;
                        UserInterface.WaitForKeyPress();
                        RandomEncounter.Run();
                        OgreEncounter.Run();
                        break;
                    }

            }
        }
        public static void DoNothing()
        {
            Console.Clear();
            Console.WriteLine("\nYou take a break for a while... you soon realize it is full of mosquitos that keep biting you... you must go!");
            UserInterface.WaitForKeyPress();
            ExploreForest();
        }
        public static void GoShelter()
        {
            Console.Clear();
            Console.WriteLine("\nYou safely get back to your Shelter!");
            Console.WriteLine("You can now rest and replenish your Health and Mana over night!");
            Game.currentPlayer.health = Game.currentPlayer.maxHealth;
            Game.currentPlayer.mana = Game.currentPlayer.maxMana;
            Console.ReadKey();
            Console.WriteLine("\nThe next morning you go back...\n");
            UserInterface.WaitForKeyPress();
            ExploreForest();
        }
        public static void GoMerchant()
        {
            Shop.LoadShop(Game.currentPlayer);
            ExploreForest();
        }

    }
}
