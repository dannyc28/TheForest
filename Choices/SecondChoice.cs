using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Choices
{
    class SecondChoice
    {
        public static void Run()
        {
            string prompt = "\nWhat do you want to do?\n";
            string[] options = { "Take a seat on the stump next to you", "Search for water", "Build shelter and start a fire" };
            Menu menu = new Menu(prompt, options);
            int selectedIndex = menu.Run();

            switch (selectedIndex)
            {
                case 0:
                    TakeABreak();
                    break;
                case 1:
                    SearchWater();
                    break;
                case 2:
                    BuildShelter();
                    break;
            }
        }
        public static void TakeABreak()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nAfter walking for a while, you need some rest... you stop for a moment...\nyou can see the bush next to you moving!");
            Console.ReadKey();
            
            UserInterface.TypeWithAnimation("\nIt's a Large Venomous Lizard!\n");
            UserInterface.WaitForKeyPress();
            string lizArt = @"
              ____...---...___
___.....---'''        .       ''--..____
     .                  .            .
 .             _.--._       /|
        .    .'()..()`.    / /
            ( `-.__.-' )  ( (    .
   .         \        /    \ \
       .      \      /      ) )        .
            .' -.__.- `.-.-'_.'
 .        .'  /-____-\  `.-'       .
          \  /-.____.-\  /-.
           \ \`-.__.-'/ /\|\|           .
          .'  `.    .'  `.
          |/\/\|    |/\/\|
";
            Combat.Run(lizArt, "Large Venomous Lizard", 15, 55);
            Combat.GetRewards("Large Venomous Lizard");

            Console.Clear();
            Console.WriteLine("\nYou end up being thirsty... you start looking for water...\n");
            UserInterface.WaitForKeyPress();
            SearchWater();
        }

        public static void SearchWater()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou find a small pond! The water doesn't look drinkable...\nYou get close to the water to see if you can catch something to eat...");
            UserInterface.TypeWithAnimation("\nWatch yourself!\n");
            UserInterface.WaitForKeyPress();
            string aligArt = @"
           .-._   _ _ _ _ _ _ _ _
.-''-.__.-'00  '-' ' ' ' ' ' ' ' '-.
'.___ '    .   .--_'-' '-' '-' _'-' '._
 V: V 'vv-'   '_   '.       .'  _..' '.'.
   '=.____.=_.--'   :_.__.__:_   '.   : :
           (((____.-'        '-.  /   : :
                             (((-'\ .' /
                           _____..'  .'
                          '-._____.-'";
            Combat.Run(aligArt, "Large Alligator", 15, 65);
            Combat.GetRewards("Large Alligator");
            Console.Clear();
            if (Game.currentPlayer.buildShelter == false)
            {
                Console.WriteLine("\nYou realize it's getting dark and you are very tired...");
                Console.WriteLine("You need to rest!");
                Console.ReadKey();
                string prompt = "\nWhat do you want to do?\n";
                string[] options = { "Keep going ", "Build a small shelter" };
                Menu menu = new Menu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou keep going although you are very tired...");
                            Console.WriteLine("You notice the night is upon you and you can see almost nothing in front of you.");
                            UserInterface.TypeWithAnimation("\nYou never seen darkness like this... It starts raining... You trip on a rock and fall into a ravine.\n");
                            UserInterface.TypeWithAnimation("You pass out...\n");
                            Console.ReadKey();

                            UserInterface.TypeWithAnimation("You wake up the next day, you broke your arm and a few ribs...");
                            UserInterface.TypeWithAnimation("But you can stand up and keep going!\n");
                            Game.currentPlayer.health = 25;
                            UserInterface.WaitForKeyPress();
                            SecondEncounter.Run();
                            break;
                        }
                    case 1:
                        {
                            Console.Clear();
                            Console.WriteLine("\nYou gather a few sticks and leafs and improvise a small Shelter!\n");
                            Console.WriteLine("It starts raining... the rain is getting in but its better than nothing.");
                            Console.WriteLine("You eventually get a bit of shuteye until next morning...");
                            string shelterArt = @"
        ______
       /     /\
      /     /  \
     /_____/----\_      
    '     '        
";
                            Console.WriteLine(shelterArt);
                            UserInterface.WaitForKeyPress();
                            SecondEncounter.Run();
                            break;
                        }
                }
            }
            else
            {
                SecondEncounter.Run();
            }


        }

        public static void BuildShelter()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou gather large sticks and large leafs and manage to build a Shelter and start a fire!");
            UserInterface.TypeWithAnimation("You can now rest and replenish your Health and Mana over night!");
            string tentArt = @"
        ______
       /     /\
      /     /  \
     /_____/----\_    (  
    '     '          ).  
   _ ___          o (:') o   
  (@))_))        o ~/~~\~ o   
                  o  o  o";
            Console.WriteLine(tentArt);
            Game.currentPlayer.health = Game.currentPlayer.maxHealth;
            Game.currentPlayer.mana = Game.currentPlayer.maxMana;
            Console.WriteLine();
            Console.ReadKey();

            UserInterface.TypeWithAnimation("\nYou wake up fully rested but hungry and thirsty. You start looking for water...\n");
            Game.currentPlayer.buildShelter = true;
            UserInterface.WaitForKeyPress();
            TakeABreak();
        }
    }
}
