using System;

namespace TheForest
{
    class Combat
    {
        static Random rand = new Random();

        public static void Run(string enemyArt, string name, int enemyDmg, int health)
        {
            string enemyName = "";
            int enemyDamage = 0;
            int enemyHealth = 0;
            string enemyArts = "";

            enemyName = name;
            enemyDamage = enemyDmg;
            enemyHealth = health;
            enemyArts = enemyArt;

            ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);

            while (enemyHealth > 0)
            {
                ConsoleKeyInfo cki = Console.ReadKey();
                string input = cki.Key.ToString();

                if (input.ToLower() == "a")
                {
                    //Attack
                    int dmgGiven = Game.currentPlayer.damage + Game.currentPlayer.weaponValue + rand.Next(20, 40) + ((Game.currentPlayer.currentClass == Player.PlayerClass.Warrior) ? 5 : 0);
                    int dmgTaken = enemyDamage - Game.currentPlayer.armorValue;

                    if (dmgTaken < 0)
                        dmgTaken = 0;
                    Game.currentPlayer.health -= dmgTaken;

                    if (enemyHealth < 0)
                        enemyHealth = 0;

                    enemyHealth -= dmgGiven;

                    if (enemyHealth < 0)
                        enemyHealth = 0;

                    ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                    Console.WriteLine("\nYou attack, dealing " + dmgGiven + " damage. The " + enemyName + " also hits you for " + dmgTaken + " damage.");

                }
                else if (input.ToLower() == "s")
                {
                    //Skill Attack
                    if (Game.currentPlayer.mana >= 70)
                    {
                        int skilldmg;

                        if (Game.currentPlayer.currentClass == Player.PlayerClass.Warrior)
                        {
                            skilldmg = 2 * (Game.currentPlayer.damage + Game.currentPlayer.weaponValue + rand.Next(20, 40) + 10);
                            int dmgTaken = enemyDamage - Game.currentPlayer.armorValue;

                            if (dmgTaken < 0)
                                dmgTaken = 0;

                            Game.currentPlayer.health -= dmgTaken;
                            Game.currentPlayer.mana -= 70;

                            enemyHealth -= skilldmg;

                            if (enemyHealth < 0)
                                enemyHealth = 0;

                            ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                            Console.WriteLine("\nYou cast your special skill, Heroic Strike!");
                            Console.WriteLine("Heroic Strike deals " + skilldmg + " damage. The " + enemyName + " also hits you for " + dmgTaken + " damage.");
                        }
                        else if (Game.currentPlayer.currentClass == Player.PlayerClass.Rogue)
                        {

                            skilldmg = Game.currentPlayer.damage + Game.currentPlayer.weaponValue + rand.Next(40, 100);
                            enemyHealth -= skilldmg;
                            if (enemyHealth < 0)
                                enemyHealth = 0;
                            int dmgTaken = enemyDamage - Game.currentPlayer.armorValue;

                            if (dmgTaken < 0)
                                dmgTaken = 0;

                            Game.currentPlayer.health -= dmgTaken;
                            Game.currentPlayer.mana -= 70;
                            ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                            Console.WriteLine("\nYou cast your special skill, Slice and Dice!");
                            Console.WriteLine("Slice and Dice deals " + skilldmg + " damage.");
                            Console.WriteLine("The " + enemyName + " also hits you for " + dmgTaken + " damage.");

                        }
                        else if (Game.currentPlayer.currentClass == Player.PlayerClass.Mage)
                        {

                            skilldmg = 2 * (Game.currentPlayer.damage + Game.currentPlayer.weaponValue + rand.Next(30, 60));
                            int dmgTaken = enemyDamage - Game.currentPlayer.armorValue;

                            if (dmgTaken < 0)
                                dmgTaken = 0;

                            Game.currentPlayer.health -= dmgTaken;
                            Game.currentPlayer.mana -= 70;
                            enemyHealth -= skilldmg;
                            if (enemyHealth < 0)
                                enemyHealth = 0;
                            ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                            Console.WriteLine("\nYou cast a spell, Fireball!");
                            Console.WriteLine("Fireball deals " + skilldmg + " damage. The " + enemyName + " also hits you for " + dmgTaken + " damage.");
                        }
                    }
                    else
                        Console.WriteLine("\nNot enough Mana!");
                }
                else if (input.ToLower() == "d")
                {
                    //Defend
                    int dmgTaken = (enemyDamage / 4) - Game.currentPlayer.armorValue;

                    if (dmgTaken < 0)
                        dmgTaken = 0;

                    int dmgGiven = Game.currentPlayer.weaponValue;
                    Game.currentPlayer.health -= dmgTaken;
                    enemyHealth -= dmgGiven;
                    if (enemyHealth < 0)
                        enemyHealth = 0;
                    ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                    Console.WriteLine("\nAs the " + enemyName + " prepares to strike, you ready your weapon in a defensive stance.");
                    Console.WriteLine("You lose " + dmgTaken + " health and deal " + dmgGiven + " damage.");
                }
                else if (input.ToLower() == "r")
                {
                    //Run
                    if (Game.currentPlayer.currentClass != Player.PlayerClass.Rogue && rand.Next(0, 2) == 0)
                    {
                        int dmgTaken = enemyDamage - Game.currentPlayer.armorValue;

                        if (dmgTaken < 0)
                            dmgTaken = 0;

                        Game.currentPlayer.health -= dmgTaken / 2;
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nAs you try to run away from the " + enemyName + ", it strikes you in the back, sending you sprawling to the ground.");
                        Console.WriteLine("You lose " + dmgTaken + " health and are unable to escape.");
                    }
                    else
                    {
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nFeeling a rush of adrenaline you seize the moment and evade the " + enemyName + ". \nYou successfully escape!\n");
                        UserInterface.WaitForKeyPress();
                        Console.Clear();
                        Console.WriteLine("As you run frantically through the woods you end up in front of a travelling merchant!\n");
                        UserInterface.WaitForKeyPress();
                        Shop.LoadShop(Game.currentPlayer);
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                    }
                }
                else if (input.ToLower() == "h")
                {
                    //HP recover
                    if (Game.currentPlayer.hpPotions == 0)
                    {

                        int dmgTaken = (enemyDamage / 2) - Game.currentPlayer.armorValue; ;

                        if (dmgTaken < 0)
                            dmgTaken = 0;

                        Game.currentPlayer.health -= dmgTaken;
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nAs you desperately grasp for a potion in your bag, you find nothing.");
                        Console.WriteLine("The " + enemyName + " strikes you with a heavy blow, and you lose " + dmgTaken + " health!");
                    }
                    else
                    {
                        int potionValue = 70 + ((Game.currentPlayer.currentClass == Player.PlayerClass.Mage) ? +40 : 0);
                        Game.currentPlayer.health += potionValue;

                        if (Game.currentPlayer.health > Game.currentPlayer.maxHealth)
                            Game.currentPlayer.health = Game.currentPlayer.maxHealth;

                        Game.currentPlayer.hpPotions--;

                        int dmgTaken = (enemyDamage / 2) - Game.currentPlayer.armorValue;

                        if (dmgTaken < 0)
                            dmgTaken = 0;

                        Game.currentPlayer.health -= dmgTaken;
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nYou reach into your bag and pull out a potion. You drink it swiftly.");
                        Console.WriteLine("You gain " + potionValue + " health");
                        Console.WriteLine("As you were occupied, the " + enemyName + " advanced and struck.");
                        Console.WriteLine("You lose " + dmgTaken + " health.");
                    }
                }
                else if (input.ToLower() == "m")
                {
                    //MP recover
                    if (Game.currentPlayer.mpPotions == 0)
                    {
                        int dmgTaken = (enemyDamage / 2) - Game.currentPlayer.armorValue;

                        if (dmgTaken < 0)
                            dmgTaken = 0;

                        Game.currentPlayer.health -= dmgTaken;
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nAs you desperately grasp for a potion in your bag, you find nothing.");
                        Console.WriteLine("The " + enemyName + " strikes you with a heavy blow, and you lose " + dmgTaken + " health!");
                    }
                    else
                    {
                        int potionValue = 70;
                        Game.currentPlayer.mana += potionValue;

                        if (Game.currentPlayer.mana > Game.currentPlayer.maxMana)
                            Game.currentPlayer.mana = Game.currentPlayer.maxMana;

                        Game.currentPlayer.mpPotions--;

                        int dmgTaken = (enemyDamage / 2) - Game.currentPlayer.armorValue;

                        if (dmgTaken < 0)
                            dmgTaken = 0;

                        Game.currentPlayer.health -= dmgTaken;
                        ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                        Console.WriteLine("\nYou reach into your bag and pull out a potion. You drink it swiftly.");
                        Console.WriteLine("You gain " + potionValue + " mana.");
                        Console.WriteLine("As you were occupied, the " + enemyName + " advanced and struck.");
                        Console.WriteLine("You lose " + dmgTaken + " health.");
                    }
                }
                if (Game.currentPlayer.health <= 0)
                {
                    //Death
                    Game.currentPlayer.health = 0;
                    ShowCombatUI(enemyName, enemyDamage, enemyHealth, enemyArts);
                    Console.WriteLine("\nYou have been slain by the " + enemyName + "!");
                    Console.WriteLine("Game over!");
                    UserInterface.WaitForKeyPress();
                    UserInterface.QuitConsole();
                }
            }

        }

        public static void GetRewards(string enemyName)
        {
            Console.WriteLine("\nYou have slain the " + enemyName + "! \n\nRewards:");
            int coins = Game.currentPlayer.GetCoins();
            int Xp = Game.currentPlayer.GetXP();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n+ " + coins + " Gold!");
            Console.ResetColor();
            Console.WriteLine("+ " + Xp + " XP!");
            Game.currentPlayer.coins += coins;
            Game.currentPlayer.xp += Xp;
            if (Game.currentPlayer.CanLevelUp())
                Game.currentPlayer.LevelUp();
            Console.ReadKey();
        }

        public static void GetEliteRewards(string enemyName)
        {
            Console.WriteLine("\nYou have slain the " + enemyName + "! \n\nRewards:");
            int coins = 2* Game.currentPlayer.GetCoins();
            int Xp = 2 * Game.currentPlayer.GetXP();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n+ " + coins + " Gold!");
            Console.ResetColor();
            Console.WriteLine("+ " + Xp + " XP!");
            Game.currentPlayer.coins += coins;
            Game.currentPlayer.xp += Xp;
            if (Game.currentPlayer.CanLevelUp())
                Game.currentPlayer.LevelUp();
            Console.ReadKey();
        }

        public static void GetBossRewards(string enemyName)
        {
            Console.WriteLine("\nYou have slain the " + enemyName + "! \n\nRewards:");
            int coins = 3 * Game.currentPlayer.GetCoins();
            int Xp = 3 * Game.currentPlayer.GetXP();
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("\n+ " + coins + " Gold!");
            Console.ResetColor();
            Console.WriteLine("+ " + Xp + " XP!");
            Game.currentPlayer.coins += coins;
            Game.currentPlayer.xp += Xp;
            if (Game.currentPlayer.CanLevelUp())
                Game.currentPlayer.LevelUp();
            Console.ReadKey();
        }

        private static void ShowCombatUI(string enemyName, int enemyDamage, int enemyHealth, string enemyArts)
        {
            Console.Clear();
            Console.WriteLine("======================================================================");
            Console.WriteLine("{0,-30}{1,-30}{2,-22}", $"HP {Game.currentPlayer.health}/{Game.currentPlayer.maxHealth}", $"{Game.currentPlayer.name}", $"HP Pots {Game.currentPlayer.hpPotions}");
            Console.WriteLine("{0,-30}{1,-30}{2,-22}", $"MP {Game.currentPlayer.mana}/{Game.currentPlayer.maxMana}", $"Lvl {Game.currentPlayer.level}", $"MP Pots {Game.currentPlayer.mpPotions}");
            Console.WriteLine("======================================================================");

            Console.WriteLine("\n" + enemyName);
            Console.WriteLine("Health " + enemyHealth + "  Power " + enemyDamage);
            Console.WriteLine(enemyArts);
            Console.WriteLine();
            Console.WriteLine("========================================================================");
            Console.WriteLine("| (A)ttack | (S)kill attack | (D)efend |  (R)un  | (H)P pot | (M)P pot |");
            Console.WriteLine("========================================================================");
        }
    }
}
