using System;
using TheForest.Encounters;

namespace TheForest
{
    class MainMenu 
    {
        public static void Run()
        {
            Console.Clear();

            while (true)
            {
                string prompt = UserInterface.ShowTitleMainMenu();
                string[] options = { "Play", "Options", "Credits", "Patch Notes", "Exit" };
                Menu menu = new Menu(prompt, options);
                int selectedIndex = menu.Run();

                switch (selectedIndex)
                {
                    case 0:
                        Intro.Run();
                        break;
                    case 1:
                        UserInterface.ShowOptions();
                        break;
                    case 2:
                        UserInterface.ShowCreditsGraphics();
                        break;
                    case 3:
                        UserInterface.ShowPatchNotes();
                        break;
                    case 4:
                        System.Environment.Exit(0);
                        break;
                }
            }
        }
     
    }
}
