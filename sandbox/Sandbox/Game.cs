using System;
using System.Collections.Generic;

namespace ConsoleBattleGame
{
    public class Game
    {
        public void StartGame()
        {
            Console.WriteLine("Welcome to Console Battle Game!");

            Character player = ChooseCharacter();

            var enemies = new List<Enemy>
            {
                new Goblin(),
                new Orc(),
                new Demon(),
                new Dragon()
            };

            foreach (var enemy in enemies)
            {
                Console.WriteLine($"\nA wild {enemy.GetName()} appears!");

                while (player.IsAlive() && enemy.IsAlive())
                {
                    ShowStatus(player, enemy);
                    BattleMenu.Show();
                    Console.Write("Choose an action: ");
                    string input = Console.ReadLine();

                    bool extraTurn = false;
                    switch (input)
                    {
                        case "1":
                            player.Attack(enemy);
                            break;
                        case "2":
                            player.Heal();
                            break;
                        case "3":
                            extraTurn = player.Talk();
                            break;
                        case "4":
                            if (player.Run())
                            {
                                Console.WriteLine("You fled from the battle.");
                                goto NextEnemy;
                            }
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }

                    // If the player successfully confused the enemy (extraTurn==true),
                    // the enemy does not attack this turn and the player gets another turn.
                    if (extraTurn)
                    {
                        Console.WriteLine("The enemy is confused and doesn't attack!");
                        // reset extraTurn for next iteration (player still has control)
                        extraTurn = false;
                        // continue to next loop iteration to grant the player another action
                        continue;
                    }

                    if (enemy.IsAlive())
                    {
                        enemy.Attack(player);
                    }

                    if (!player.IsAlive())
                    {
                        Console.WriteLine("You have been defeated...");
                        return;
                    }
                }

                Console.WriteLine($"You defeated the {enemy.GetName()}!");
                NextEnemy: ;
            }

            Console.WriteLine("You defeated all enemies! Victory!");
        }

        private Character ChooseCharacter()
        {
            while (true)
            {
                Console.WriteLine("\nChoose your class:");
                Console.WriteLine("1. Warrior");
                Console.WriteLine("2. Rogue");
                Console.WriteLine("3. Mage");
                Console.WriteLine("4. Paladin");
                Console.Write("Selection: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": return new Warrior();
                    case "2": return new Rogue();
                    case "3": return new Mage();
                    case "4": return new Paladin();
                    default:
                        Console.WriteLine("Invalid selection.");
                        break;
                }
            }
        }

        private void ShowStatus(Character player, Enemy enemy)
        {
            Console.WriteLine($"\n{player.GetName()} HP: {player.GetHealth()}  |  {enemy.GetName()} HP: {enemy.GetHealth()}");
        }
    }
}
