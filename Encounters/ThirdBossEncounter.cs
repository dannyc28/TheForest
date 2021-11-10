using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheForest.Encounters
{
    class ThirdBossEncounter
    {
        public static void Run()
        {
            Console.Clear();
            UserInterface.TypeWithAnimation("...");

            Console.ReadKey();
            Console.ForegroundColor = ConsoleColor.Red;
            UserInterface.TypeWithAnimation("\nAfter all the commotion you made, something big is heading your way.");
            UserInterface.TypeWithAnimation("\nYou can hear thundering giant steps aproaching slowly, crushing everything around.");
            UserInterface.TypeWithAnimation("\nTrees are falling down...");
            UserInterface.TypeWithAnimation("\nIt's a giant troll! And it's wielding the trunk of a tree as a weapon!");
            UserInterface.TypeWithAnimation("\n****");
            UserInterface.TypeWithAnimation("\nYou probably won't survive this...");
            Console.ResetColor();
            Console.ReadKey();
            string trollArt = @"
|                           ,,'``````````````',,                            |
X                        ,'`                   `',                          X
|                      ,'                         ',                        |
X                    ,'          ;       ;          ',                      X
|       (           ;             ;     ;             ;     (               |
X        )         ;              ;     ;              ;     )              X
|       (         ;                ;   ;                ;   (               |
X        )    ;   ;    ,,'```',,,   ; ;   ,,,'```',,    ;   ;               X
|       (    ; ',;   '`          `',   ,'`          `'   ;,' ;              |
X        )  ; ;`,`',  _--~~~~--__   ' '   __--~~~~--_  ,'`,'; ;     )       X
|       (    ; `,' ; :  /       \~~-___-~~/       \  : ; ',' ;     (        |
X  )     )   )',  ;   -_\  o    /  '   '  \    o  /_-   ;  ,'       )   (   X
| (     (   (   `;      ~-____--~'       '~--____-~      ;'  )     (     )  |
X  )     )   )   ;            ,`;,,,   ,,,;',            ;  (       )   (   X
| (     (   (  .  ;        ,'`  (__ '_' __)  `',        ;  . )     (     )  |
X  )     \/ ,'.). ';    ,'`        ~~ ~~        `',    ;  .(.', \/  )   (   X
| (   , ,'|// / (/ ,;  '        _--~~-~~--_        '  ;, \)    \|', ,    )  |
X ,)  , \/ \|  \\,/  ;;       ,; |_| | |_| ;,       ;;  \,//  |/ \/ ,   ,   X
|',   .| \_ |\/ |#\_/;       ;_| : `~'~' : |_;       ;\_/#| \/| _/ |.   ,'  |
X#(,'  )  \\\#\ \##/)#;     :  `\/       \/   :     ;#(\##/ /#///  (  ',)# ,X
|| ) | \ |/ /#/ |#( \; ;     :               ;     ; ;/ )#| \#\ \| / | ( |) |
X\ |.\\ |\_/#| /#),,`   ;     ;./\_     _/\.;     ;   `,,(#\ |#\_/| //.| / ,X
| \\_/# |#\##/,,'`       ;     ~~--|~|~|--~~     ;       `',,\##/#| #\_// \/|
X  ##/#  #,,'`            ;        ~~~~~        ;            `',,#  #\##  //X
|####@,,'`                 `',               ,'`                 `',,@####| |
X#,,'`                        `',         ,'`                        `',,###X
|'                               ~~-----~~                               `' |";
            if (OperatingSystem.IsWindows())
                Console.SetWindowSize(120, 45);
            Combat.Run(trollArt, "Giant Forest Troll << BOSS >>", 80, 1000);
            Combat.GetBossRewards("Giant Forest Troll << BOSS >>");
            UserInterface.TypeWithAnimation("\nYou picked up:");
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            Console.WriteLine("\nEpic Two Handed Silver Sword (+50 damage)");
            Console.WriteLine("Epic Silver Armor (+50 armor)\n");
            Console.ResetColor();
            Game.currentPlayer.weaponValue += 50;
            Game.currentPlayer.armorValue += 50;
            UserInterface.WaitForKeyPress();
            UserInterface.ShowTheEnding();
        }
    }
}
