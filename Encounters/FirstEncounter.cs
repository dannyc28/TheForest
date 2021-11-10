using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class FirstEncounter
    {
        public static void Run()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nAs you move forward through the thick bush, you hear a growling right in front of you!");
            UserInterface.TypeWithAnimation("Your stomach sinks and you feel chills down your spine...");
            Console.ReadKey();
            UserInterface.TypeWithAnimation("\nThe beast jumps out from the bush, growling at you.");
            Console.ForegroundColor = ConsoleColor.Red;
            UserInterface.TypeWithAnimation("\nPrepare yourself!\n");
            Console.ResetColor();
            string wolfArt=@"
                     .
                    / V\
                  / `  /
                 <<   |
                 /    |
               /      |
             /        |
           /    \  \ /
          (      ) | |
  ________|   _/_  | |
<__________\______)\__)
";      
            UserInterface.WaitForKeyPress();
            Combat.Run(wolfArt, "Large Black Wolf", 15, 58);
            Combat.GetRewards("Large Black Wolf");
            SecondChoice.Run();
        }
    }
}
