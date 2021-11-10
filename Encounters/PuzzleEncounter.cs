using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheForest.Encounters;

namespace TheForest.Encounters
{
    class PuzzleEncounter
    {
        static Random rand = new Random();
        public static void Run()
        {
            Console.Clear();
            Console.WriteLine("\nYou notice something is following you and try to pickup the pace...");
            Console.WriteLine("You end up in a place with alot of large rocks around. You see that the floor is covered in runes.\n");
            List<char> chars = new char[] { '0', '1', '2', '3', '4', '5', '6', '7', '8', '9' }.ToList();
            List<int> positions = new List<int>();
            char c = chars[rand.Next(0, 10)];
            chars.Remove(c);
            for (int y = 0; y < 4; y++)
            {
                int pos = rand.Next(0, 4);
                positions.Add(pos);
                for (int x = 0; x < 4; x++)
                {
                    if (x == pos)
                        Console.Write(c);
                    else
                        Console.Write(chars[rand.Next(0, 8)]);
                }
                Console.Write("\n");
            }
            Console.WriteLine("\nIt looks like a trap and to move forward you have to choose on which rune to step");
            Console.WriteLine("There are 4 lines of numbers, each line containing 4 numbers...");
            Console.WriteLine("They don't make any sense so you try to find a pattern, a number that repeats itself in all of the lines.");
            Console.WriteLine("\nIf you find it, choose the position (1 to 4, from left to right) in each line, pressing enter after each number!");

            for (int i = 0; i < 4; i++)
            {
                while (true)
                {
                    if (int.TryParse(Console.ReadLine(), out int input) && input < 5 && input > 0)
                    {
                        if (positions[i] == input - 1)
                            break;
                        else
                        {
                            Console.WriteLine("Darts fly out towards you! You take 5 damage.");
                            Game.currentPlayer.health -= 5;
                            if (Game.currentPlayer.health <= 0)
                            {
                                Console.WriteLine("You start to feel sick. The poison from the darts is strong and you fall to the ground.");
                                Console.WriteLine("You died!");
                                Console.ReadKey();
                                System.Environment.Exit(0);
                            }
                            break;
                        }
                    }
                    else
                        Console.WriteLine("Invalid input... only numbers from 1 to 4!");
                }
            }
            Console.WriteLine("You have succesfully crossed!");
            Console.WriteLine("You gained 100 XP!");
            Game.currentPlayer.xp += 100;
            if (Game.currentPlayer.CanLevelUp())
                Game.currentPlayer.LevelUp();
            Console.ReadKey();
        }
    }
}
