using System;
using Script_Memorizor;
namespace Script_Memorizor{
    class Program {
        static void Main(string[] args) {

            /* EXCEEDING REQUIREMENTS:
             * - Includes a small scripture library, randomly chosen each run.
             * - Avoids hiding already-hidden words.
             * - Proper encapsulation with four classes: Scripture, Reference, Word, Script_Obscurer.
             * - Clean and reusable design.
             */

            Console.Clear();
            Console.WriteLine("Welcome to the Scripture Memorior!\n");

            Scripture scripture = new Scripture();
            scripture.Display();

            while (true) {
                Console.WriteLine("\nPress Enter to begin hiding words.");
                Console.WriteLine("type 'quit' in oder to exit the program.");
                string user_Response = Console.ReadLine().Trim().ToLower();

                if (user_Response == "quit") {

                    Console.WriteLine("\nEnding Program...");
                    break;
                }

                Console.Clear();

                scripture.HideWords();
                scripture.Display();

                if (scripture.AllWordsHidden()) {
                    Console.WriteLine("\nAll words are now hidden.");
                    Console.WriteLine("Great job studying!");
                }
            }
        }
    }
}