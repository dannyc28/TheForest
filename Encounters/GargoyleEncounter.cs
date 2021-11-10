using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class GargoyleEncounter
    {
        public static void Run()
        {
            Console.Clear();
            
            UserInterface.TypeWithAnimation("\nAs you aproach to explore the old ruined house, \na statue from the roof jumps right in front of you!");
            Console.ForegroundColor = ConsoleColor.Red;
            UserInterface.TypeWithAnimation("\nDefend yourself!");
            Console.ResetColor();
            Console.ReadKey();
            string gargoyleArt = @"
                  ,               ,
                 / \             / \
                |/\ \    _,_    / /\|
                || \ |.-'   '-.| / ||
                ||  / -.\\ //.- \  ||
                \\_ |  / o`^'o\  | _//
                 `--|  `'/ \'`  |--`
                    ; |\__'__/| ;
                     \\ \/ ^\/ //
                      \\     //
                       \\-.-//
                        \`'`/
                         `'`";
            
            Combat.Run(gargoyleArt, "Elite Rock Gargoyle", 40, 200);
            Combat.GetEliteRewards("Elite Rock Gargoyle");
            UserInterface.TypeWithAnimation("\nYou picked up:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nGargoyle Reinforced Armor (+20 defense)");
            Console.ResetColor();
            Game.currentPlayer.armorValue += 20;
            Console.WriteLine();
            UserInterface.WaitForKeyPress();
            FifthChoice.Run();
        }
    }
}
