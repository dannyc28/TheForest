using System;
using static System.Console;
using System.Threading;
using System.Media;

namespace TheForest
{
    class UserInterface
    {
        public static void LoadingFirstScreen()
        {
            PlayMainMenuMusic();
            if (OperatingSystem.IsWindows())
                Console.SetWindowSize(120, 32);
            string TitleArt = @"
 ___                              _ ,                                              
-   ---___- ,,                  ,- -                           ,                /\ 
   (' ||    ||                 _||_                           ||               ||  
  ((  ||    ||/\\  _-_        ' ||    /'\\ ,._-_  _-_   _-_, =||=        /'\\ =||= 
 ((   ||    || || || \\         ||   || ||  ||   || \\ ||_.   ||        || ||  ||  
  (( //     || || ||/           |,   || ||  ||   ||/    ~ ||  ||        || ||  ||  
    -____-  \\ |/ \\,/        _-/    \\,/   \\,  \\,/  ,-_-   \\,       \\,/   \\, 
              _/                                                                   
                                                        
                       -_____                  ,  ,,    
                         ' | -,          _    ||  ||    
                        /| |  |`  _-_   < \, =||= ||/\\ 
                        || |==|| || \\  /-||  ||  || || 
                       ~|| |  |, ||/   (( ||  ||  || || 
                        ~-____,  \\,/   \/\\  \\, \\ |/ 
                       (                            _/  



";
            WriteLine(TitleArt);
            Thread.Sleep(1800);
            ShowLoadingBar();
            MainMenu.Run();
        }

        public static void PlayMainMenuMusic()
        {
            if (OperatingSystem.IsWindows())
            {
                string filepath = AppDomain.CurrentDomain.BaseDirectory + "Menu_music.wav";
                SoundPlayer soundPlayer = new SoundPlayer(filepath);
                soundPlayer.Load();
                soundPlayer.Play();
            }
        }

        public static void StopMusic()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer soundPlayer = new SoundPlayer();
                soundPlayer.Stop();
            }
        }

        public static void ShowLoadingBar()
        {
            WriteLine("                                   Loading...\n");
            Write("                                 ");
            string newBar = @"
■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■■
";
            
            TypeWithAnimation(newBar,50);

            //Write("                                 ");
            //string loadingBar = "--------------";
            //TypeWithAnimation(loadingBar,250);
            
        }

        public static string ShowTitleMainMenu()
        {
            string TitleArt = @"
 ___                              _ ,                                              
-   ---___- ,,                  ,- -                           ,                /\ 
   (' ||    ||                 _||_                           ||               ||  
  ((  ||    ||/\\  _-_        ' ||    /'\\ ,._-_  _-_   _-_, =||=        /'\\ =||= 
 ((   ||    || || || \\         ||   || ||  ||   || \\ ||_.   ||        || ||  ||  
  (( //     || || ||/           |,   || ||  ||   ||/    ~ ||  ||        || ||  ||  
    -____-  \\ |/ \\,/        _-/    \\,/   \\,  \\,/  ,-_-   \\,       \\,/   \\, 
              _/                                                                   
                                                        
                       -_____                  ,  ,,    
                         ' | -,          _    ||  ||    
                        /| |  |`  _-_   < \, =||= ||/\\ 
                        || |==|| || \\  /-||  ||  || || 
                       ~|| |  |, ||/   (( ||  ||  || || 
                        ~-____,  \\,/   \/\\  \\, \\ |/ 
                       (                            _/  



Welcome to The Forest of Death!                                      v1.0.0 alpha
(Use arrow keys to navigate and press Enter to select)
";
            return TitleArt;
        }

        public static void ShowOptions()
        {
            Clear();
            string prompt = "\nChoose Difficulty Level:\n";
            string[] options = { "Easy", "Medium", "Hard" };
            Menu mainMenu = new Menu(prompt, options);
            int selectedIndex = mainMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    Game.currentPlayer.hpPotions = 7;
                    return;
                case 1:
                    Game.currentPlayer.hpPotions = 1;
                    break;
                case 2:
                    {
                        Game.currentPlayer.hpPotions = 1;
                        Game.currentPlayer.armorValue -= 10;
                        break;
                    }
            }
            ReadKey();
        }

        public static void ShowCreditsGraphics()
        {
            Clear();
            string creditsGraphics = @"
 Thank you for playing this game. 
 If you liked it, let the developer know! He'll appreciate it :-)


 ===== Credits =====


 Created and Directed by             Special Thanks:       
                                     
 George Dan Ciobanu                  Irina Ciobanu       
                                           
                                     
 Lead Game Developer                  

 George Dan Ciobanu


 Lead Gameplay Designer              Music

 George Dan Ciobanu                  Salem's Secret
                                     by Peter Gundry

 Design and Scripting                
                                     
 George Dan Ciobanu
";
            WriteLine(creditsGraphics);
            ReadKey();
            MainMenu.Run();
        }

        public static void ShowTheEnding()
        {
            Clear();
            TypeWithAnimation("\nYou can't believe you made it... you're ALIVE!");
            TypeWithAnimation("As you catch your breath, you notice the spirits of the forest are gathering around you. ");
            TypeWithAnimation("They thank you for eliberating their beloved forest and setting them free!");
            TypeWithAnimation("They say you can ask them for anything in return... any wish you have, they will grant it!");
            ReadKey();
            TypeWithAnimation("\nYou say:   \"I only want to get out of this damn forest!\"");
            ReadKey();
            Clear();
            string theend = @"
 ___                                               
-   ---___- ,,                  ,- _~,        |\   
   (' ||    ||                 (' /| /         \\  
  ((  ||    ||/\\  _-_        ((  ||/= \\/\\  / \\ 
 ((   ||    || || || \\       ((  ||   || || || || 
  (( //     || || ||/          ( / |   || || || || 
    -____-  \\ |/ \\,/          -____- \\ \\  \\/  
              _/                                   
                                                   
";
            WriteLine(theend);
            ReadKey();
        }

        public static void TypeWithAnimation(string text, int delay = 10)
        {
            for (int i = 0; i < text.Length; i++)
            {
                Write(text[i]);
                Thread.Sleep(delay);
                if (KeyAvailable)
                {
                    ConsoleKeyInfo keyInfo = ReadKey(true);
                    if (keyInfo.Key == ConsoleKey.Enter)
                    {
                        Write(text.Substring(i + 1));
                        break;
                    }
                }
            }
            WriteLine();
        }

        public static void ProgressBar(string fillerChar, string backgroundChar, decimal value, int size)
        {
            int dif = (int)(value * size);
            for (int i = 0; i < size; i++)
            {
                if (i < dif)
                    Write(fillerChar);
                else
                    Write(backgroundChar);
            }
        }

        public static void WaitForKeyPress()
        {
            WriteLine("Press <any> key to continue.");
            ReadKey();
        }

        public static void QuitConsole()
        {
            WriteLine("Press any <key> to exit.");
            ReadKey();
            Environment.Exit(0);
        }

        public static void ShowPatchNotes()
        {
            Clear();
            string patchNotes = @"
Version 1.0.0 alpha patch notes:

- added improvements to loading screen, added loading bar
- improved menu interface, now selecting happens without the entire screen flickering
- added music to the main menu
- improved combat User Interface, now action is instant when pressing the specific button
- improved combat User Interface to be more fluid and added small refinements
- improved combat mechanics to be more challenging 
- revamped first boss and added more graphics to the UI
- added improvements to the puzzle description to be more explicit
- improved the Shelter story branch and added choice 
- added small refinements throughout the story, added option to skip text by pressing Enter
- added improvements to the random encounters UI and mechanics
- made adjustements to the encounters to be more challenging 
- added small improvements to the Shop
- nerfed warrior's bonus damage for better balance between classes
- nerfed wizard's skill for better balance between classes
- buffed rogue's skill for better balance between classes
- buffed rewards for elite encounters 
- buffed rewards for boss encounters


Version 0.9.8 alpha patch notes:

- fixed MP potions display on combat interface
- fixed MP potions display proper text when used
- fixed Hard mode mechanics concerning potions and armor 
- fixed player damage calculation mechanics
- fixed random encounters to be more challenging
";
            WriteLine(patchNotes);
            ReadKey();
            MainMenu.Run();
        }
    }
}
