using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheForest
{
    class Shop
    {
        public static void LoadShop(Player player)
        {
            int hPotPrice;
            int mPotPrice;
            int armorPrice;
            int weaponPrice;

            while (true)
            {
                hPotPrice = 15;
                mPotPrice = 15;
                armorPrice = 50+40 * (player.level);
                weaponPrice = 50+40 * (player.level);

                Console.Clear();
                Console.WriteLine("========================");
                Console.WriteLine("          Shop          ");
                Console.WriteLine("========================");
                Console.WriteLine("(W)eapon upgrade: $ " + weaponPrice);
                Console.WriteLine("(A)rmor upgrade: $ " + armorPrice);
                Console.WriteLine("(H)ealth Potions: $ " + hPotPrice);
                Console.WriteLine("(M)ana Potions: $ " + mPotPrice);
                Console.WriteLine("========================");
                Console.WriteLine("(E)xit shop");
                Console.WriteLine("(Q)uit game");


                Console.WriteLine("\n\n       " + player.name + "'s Stats         ");
                Console.WriteLine("============================");
                Console.WriteLine("Level: " + player.level);
                Console.WriteLine("Xp:");
                Console.Write("[");
                UserInterface.ProgressBar("=", "-", ((decimal)player.xp / (decimal)player.GetLevelUpValue()), 25);
                Console.WriteLine("]");
                Console.WriteLine("Gold: " + player.coins);
                Console.WriteLine("Health: " + player.health + "/" + player.maxHealth);
                Console.WriteLine("Mana: " + player.mana + "/" + player.maxMana);
                Console.WriteLine("HP potions:  " + player.hpPotions);
                Console.WriteLine("MP potions:  " + player.mpPotions);
                Console.WriteLine("============================");
                string input = Console.ReadLine().ToLower();

                if (input == "w" || input == "weapon")
                    TryBuy("weapon", weaponPrice, player);
                else if (input == "a" || input == "armor")
                    TryBuy("armor", armorPrice, player);
                else if (input == "h" || input == "health")
                    TryBuy("hPotion", hPotPrice, player);
                else if (input == "m" || input == "mana")
                    TryBuy("mPotion", mPotPrice, player);
                else if (input == "q" || input == "quit")
                    UserInterface.QuitConsole();
                else if (input == "e" || input == "exit")
                    break;
            }
        }

        public static void TryBuy(string item, int cost, Player player)
        {
            if (player.coins >= cost)
            {
                if (item == "weapon")
                {
                    Console.WriteLine("You bought 1 Weapon Upgrade! Damage increase: +10\n");
                    player.weaponValue += 10;
                    UserInterface.WaitForKeyPress();
                }
                else if (item == "armor")
                {
                    Console.WriteLine("You bought 1 Armor Upgrade! Armor increase: +10\n");
                    player.armorValue += 10;
                    UserInterface.WaitForKeyPress();
                }
                else if (item == "hPotion")
                {
                    Console.WriteLine("You bought 1 Health Potion!\n");
                    player.hpPotions++;
                    UserInterface.WaitForKeyPress();
                }
                else if (item == "mPotion")
                {
                    Console.WriteLine("You bought 1 Mana Potion!\n");
                    player.mpPotions++;
                    UserInterface.WaitForKeyPress();
                }

                player.coins -= cost;
            }
            else
            {
                Console.WriteLine("\nYou don't have enough gold!");
                Console.ReadKey();
            }
        }
    }
}
