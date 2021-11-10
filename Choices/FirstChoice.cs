using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Choices
{
    class FirstChoice
    {
        public static void Run()
        {
            string prompt = "\nYou realize you are deep in the thick forest and don't know where to go..." + "\n\nWhat do you want to do?\n";
            string[] options = { "Explore the forest", "Search for water", "Craft a wooden spear" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    ExploreForest();
                    break;
                case 1:
                    SearchWater();
                    break;
                case 2:
                    CraftSpear();
                    break;
            }
        }

        public static void ExploreForest()
        {
            FirstEncounter.Run();
        }

        public static void SearchWater()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou eventually find a small river, the water is perfect. As you're drinking...\nyou can see something coming out of the water...\n");
            Console.ReadKey();
            UserInterface.TypeWithAnimation("It's a Large Stone Crab!\n");
            UserInterface.WaitForKeyPress();
            string crabArt = @"
                   __       __
                  / <`     '> \
                 (  / @   @ \  )
                  \(_ _\_/_ _)/
                (\ `-/     \-' /)
                 '===\     /==='
                  .==')___(`==.    
                 ' .='     `=.";
            Combat.Run(crabArt, "Large Stone Crab", 10, 45);
            Combat.GetRewards("Large Stone Crab");

            FirstEncounter.Run();
        }

        public static void CraftSpear()
        {
            Console.Clear();
            Console.WriteLine("\nYou find a large stick and a stone and manage to craft a Wooden Spear!\n");
            // Add spear to inventory
            Console.WriteLine("You picked up:");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("\nWooden Spear (+5 damage)\n");
            Console.ResetColor();
            Game.currentPlayer.weaponValue += 5;
            UserInterface.WaitForKeyPress();
            Console.Clear();
            Console.WriteLine("\nYou end up being thirsty... you start looking for water...\n");
            UserInterface.WaitForKeyPress();
            SearchWater();
        }
    }
}
