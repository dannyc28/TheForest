using System;

namespace TheForest
{
    class Player
    {
        public string name;
        public int coins = 0;
        public int level = 1;
        public int xp = 0;
        public int health = 100;
        public int mana = 100;
        public int maxHealth = 100;
        public int maxMana = 100;
        public int damage = 1;
        public int armorValue = 0;
        public int weaponValue = 0;
        public int hpPotions = 1;
        public int mpPotions = 0;
        public bool buildShelter = false;
        

        public enum PlayerClass { Warrior, Rogue, Mage }
        public PlayerClass currentClass = PlayerClass.Warrior;

        public Player()
        {

        }

        Random rand = new Random();



        public int GetCoins()
        {
            int upper = 59;
            int lower = 25;
            return rand.Next(lower, upper);
        }

        public int GetXP()
        {
            int upper =  400;
            int lower =  200;
            return rand.Next(lower, upper);
        }

        public int GetLevelUpValue()
        {
            return 100 * level + 400;
        }

        public bool CanLevelUp()
        {
            if (xp >= GetLevelUpValue())
                return true;
            else
                return false;
        }

        public void LevelUp()
        {
            while (CanLevelUp())
            {
                xp -= GetLevelUpValue();
                level++;
            }

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            UserInterface.TypeWithAnimation("\n      >>  LEVEL UP!  <<");
            UserInterface.TypeWithAnimation("\nCongratulations! You are now level " + level + "!");
            Console.WriteLine();
            Console.ResetColor();
            Game.currentPlayer.maxHealth = Game.currentPlayer.maxHealth + 30;
            Game.currentPlayer.maxMana = Game.currentPlayer.maxMana+10;
            Game.currentPlayer.damage += 1;
        }

    }
}
