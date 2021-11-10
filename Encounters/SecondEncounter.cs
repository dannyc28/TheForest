using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;
using TheForest.Choices;

namespace TheForest.Encounters
{
    class SecondEncounter
    {
        public static void Run()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("\nYou find a small river to drink water and try to do some fishing.\nAs you aproach the water, you can see something coming out...");
            Console.ReadKey();
            
            UserInterface.TypeWithAnimation("\nThe huge beast growls fiercely at you...\nYou try to back away but it is furious and it starts charging!\n");
            string bearArt = @"
    .--.              .--.
   : (\ '. _......_ .' /) :
    '.    `        `    .'
     /'   \        /   `\
    /      O      O      \
   |       /      \       |
   |     /'        `\     |
    \   | .  .--.  . |   /
     '._ \.' \__/ './ _.'
     /  ``'._-''-_.'``  \
";
            UserInterface.WaitForKeyPress();
            Combat.Run(bearArt, "Enraged Brown Bear", 20, 75);
            Combat.GetRewards("Enraged Brown Bear");
            ThirdChoice.Run();
        }
    }
}
