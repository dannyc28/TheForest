using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class OgreEncounter
    {
        public static void Run()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou end up on a nice sunny meadow. It feels nice to be out of the dark woods...  ");
            UserInterface.TypeWithAnimation("As you are resting for a bit, you hear some intense cracks coming from the bushes. The trees are shaking and its getting closer...");
            UserInterface.TypeWithAnimation("The ground is shaking under the rapidly increasing heavy steps!");
            UserInterface.TypeWithAnimation("You are petrified and try to hide but it's too late...");
            Console.ReadKey();
            string ogreArt = @"
      __.-=-._
    ,''\_    _/''\
   -__o.-'  '-._0/
 _ |    .'  \    \  _
( \|  / |  | `   (_/ )
 )/  / /   \\_     ,(
 \|(___    ___) .(\_/
 /     \'_|       \
 \-'''.____.''''--/
  `.-.__,__.__.-'/
    `-._______.-'
";
            Combat.Run(ogreArt, "Elite Ogre ", 30, 140);
            Combat.GetEliteRewards("Elite Ogre");
            UserInterface.TypeWithAnimation("\nYou picked up:");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nMassive Iron Axe (+20 damage)");
            Console.ResetColor();
            Game.currentPlayer.weaponValue += 20;
            Console.WriteLine();
            UserInterface.WaitForKeyPress();
            FourthChoice.Run();
        }
    }
}
