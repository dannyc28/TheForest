using System;

namespace TheForest.Encounters
{
    class RandomEncounter
    {
        static Random rand = new Random();
        public static void Run()
        {
            switch (rand.Next(0, 7))
            {
                case 0:
                    RunBasicEncounter();
                    break;
                case 1:
                    RunBasicEncounter();
                    break;
                case 2:
                    RunBasicEncounter();
                    break;
                case 3:
                    RunBasicEncounter();
                    break;
                case 4:
                    RunBasicEncounter();
                    break;
                case 5:
                    RunBasicEncounter();
                    break;
                case 6:
                    PuzzleEncounter.Run();
                    break;
            }
        }

        public static void RunBasicEncounter()
        {
            string enemyName = GetName();
            int enemyDamage = GetPower();
            int enemyHealth = GetHealth();
            Console.Clear();
            UserInterface.TypeWithAnimation("\nAs you walk through the forest, you are attacked...");
            Console.ForegroundColor = ConsoleColor.Red;
            UserInterface.TypeWithAnimation("\nPrepare yourself!");
            Console.ResetColor();
            Console.ReadKey();
            string combatArt = @"

      O                                     O
{o)xxx|===============-  *  -===============|xxx(o}
      O                                     O

";
            Combat.Run(combatArt, enemyName, enemyDamage, enemyHealth);
            Combat.GetRewards(enemyName);
        }

        public static string GetName()
        {
            switch (rand.Next(0, 8))
            {
                case 0:
                    return "Large Grey Wolf";
                case 1:
                    return "Large Black Bear";
                case 2:
                    return "Dark Cultist";
                case 3:
                    return "Grave Robber";
                case 4:
                    return "Wood Elf Thief";
                case 5:
                    return "Goblin Thief";
                case 6:
                    return "Skeleton Soldier";
                case 7:
                    return "Human Rogue";
            }
            return "Lonely Wolf";
        }

        public static int GetHealth()
        {
            int upper = 99;
            int lower = 75;
            return rand.Next(lower, upper);
        }

        public static int GetPower()
        {
            int upper = 30;
            int lower = 20;
            return rand.Next(lower, upper);
        }
    }
}
