using System;
using System.Diagnostics;

namespace ConsoleBattleGame
{
    public static class InputHelper
    {
        public static bool GetTimedKey(int ms)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();

            while (sw.ElapsedMilliseconds < ms)
            {
                if (Console.KeyAvailable)
                {
                    Console.ReadKey(true);
                    return true;
                }
            }

            return false;
        }
    }
}
