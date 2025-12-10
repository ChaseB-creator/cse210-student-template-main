using System;
using System.Diagnostics;

namespace ConsoleBattleGame
{
    public class TimedKeyChecker
    {
        public bool WaitForKey(char requiredKey, int ms)
        {
            Stopwatch watch = new Stopwatch();
            watch.Start();

            while (watch.ElapsedMilliseconds < ms)
            {
                if (Console.KeyAvailable)
                {
                    ConsoleKeyInfo key = Console.ReadKey(true);

                    if (char.ToUpper(key.KeyChar) == requiredKey)
                        return true;

                    return false;
                }
            }
            return false;
        }
    }
}
