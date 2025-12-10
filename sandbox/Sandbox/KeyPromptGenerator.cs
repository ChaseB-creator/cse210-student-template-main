using System;

namespace ConsoleBattleGame
{
    public class KeyPromptGenerator
    {
        private static Random _rand = new Random();

        public char GenerateKey()
        {
            int value = _rand.Next(0, 26);
            char letter = (char)('A' + value);

            Console.WriteLine($"Press the letter: {letter}");
            return letter;
        }
    }
}
