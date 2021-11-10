using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class SecondBossEncounter
    {
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("\n...as you aproach the crossroad you realize it's full of berries in the bushes nearby and you are famished!" +
                "\nSuddenly you hear footsteps, you turn and see this hulking, massive cyclops staring at you! \n");
            UserInterface.TypeWithAnimation("He seems very mad!");
            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Red;
            UserInterface.TypeWithAnimation("\nPrepare yourself!");
            Console.ResetColor();
            Console.ReadKey();
            string cyclopsArt = @"
           _......._
       .-'.'.'.'.'.'.`-.
     .'.'.'.'.'.'.'.'.'.`.
    /.'.'               '.\
    |.'    _.--...--._     |
    \    `._.-.....-._.'   /
    |     _..- .-. -.._   |
 .-.'    `.   ((@))  .'   '.-.
( ^ \      `--.   .-'     / ^ )
 \  /         .   .       \  /
 /          .'     '.  .-    \
( _.\    \ (_`-._.-'_)    /._\)
 `-' \   ' .--.          / `-'
     |  / /|_| `-._.'\   |
     |   |       |_| |   /-.._
 _..-\   `.--.______.'  |
      \       .....     |
       `.  .'      `.  /
         \           .'
          `-..___..-`";
            Combat.Run(cyclopsArt, "Enraged Cyclops << BOSS >>", 60, 700);
            Combat.GetBossRewards("Enraged Cyclops << BOSS >>");
            UserInterface.TypeWithAnimation("\nYou picked up:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nRare Cyclops Armor (+30 defense)\n");
            Console.ResetColor();
            Game.currentPlayer.armorValue += 30;
            UserInterface.WaitForKeyPress();
            SeventhChoice.Run();
        }
    }
}
