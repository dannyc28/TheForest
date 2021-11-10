using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class FirstBossEncounter 
    {
        public static void Run()
        {

            Console.Clear();
            UserInterface.TypeWithAnimation("\nThe wooden cabin seems abandoned and the door is open.");
            UserInterface.TypeWithAnimation("You get inside and swiftly close the door.");
            UserInterface.TypeWithAnimation("You think you are safe here.");
            UserInterface.TypeWithAnimation("You hope to find anything helpful and you walk into the kitchen...");
            string houseArt = @"
                                                 /\
                             _                  /  \  /\
                    ________[_]________      /\/    \/  \
           /\      /\        ______    \    /   /\/\  /\/\
          /  \    //_\       \    /\    \  /\/\/    \/    \
   /\    / /\/\  //___\       \__/  \    \/
  /  \  /\/    \//_____\       \ |[]|     \
 /\/\/\/       //_______\       \|__|      \
/      \      /XXXXXXXXXX\                  \
        \    /_I_II  I__I_\__________________\
               I_I|  I__I_____[]_|_[]_____I
               I_II  I__I_____[]_|_[]_____I
               I II__I  I     XXXXXXX     I
            ~~~~~'   '~~~~~~~~~~~~~~~~~~~~~~~~
";
            Console.WriteLine(houseArt);
 
            Console.WriteLine();
            Console.ReadKey();
            UserInterface.TypeWithAnimation("\nSuddenly... From the darkness, a large silhouette appears!");
            UserInterface.TypeWithAnimation("She's menacingly holding a large butchering knife... She looks haunting!");
            UserInterface.TypeWithAnimation("Right away, you know this will be no ordinary fight!");
            Console.ReadKey();

            string wraithArt = @"
                  ________
                /.--------.\
               //| 0\  /0 |\\
              ||{|   ^^   |}||
               \\ \ /''\ / //
                \\ \\__// //
              =____ |  | ____=
     \\/\    /                \    /\//
    \\/  \  /           .      \  /  \//
     /    \/                    \/    \
      \            .                 /
       \                            /
        \_                        _/
            (         .       )
         ( (   (                ) .
      .   (       .          .     )   )
        (    (        .   .          )
 .  ( (   .     (              )  )        )
     ( .            .        .     .
   (        .              .         )";

            if (OperatingSystem.IsWindows())
                Console.SetWindowSize(120, 41);

            Combat.Run(wraithArt, "Haunting Wraith << BOSS >>", 40, 400);
            Combat.GetBossRewards("Haunting Wraith << BOSS >>");

            Console.WriteLine("\nYou picked up:");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nRare Decapitating Butchering Knife (+30 damage)\n");
            Console.ResetColor();
            Game.currentPlayer.weaponValue += 30;
            UserInterface.WaitForKeyPress();
            SixthChoice.Run();
        }
    }
}
