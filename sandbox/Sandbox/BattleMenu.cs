using System;

namespace ConsoleBattleGame
{
    public class BattleMenu
    {
        public static void Show()
        {
            Console.WriteLine("\n--- Battle Menu ---");
            Console.WriteLine("1. Attack");
            Console.WriteLine("2. Heal");
            Console.WriteLine("3. Talk");
            Console.WriteLine("4. Run");
        }
    }
}
