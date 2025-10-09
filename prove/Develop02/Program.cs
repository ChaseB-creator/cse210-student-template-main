using System;

namespace JournalApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Journal myJournal = new Journal();
            PromptGenerator promptGenerator = new PromptGenerator();
            bool running = true;

            do {
                Console.Clear();
                Console.WriteLine(" ___________________________________________");
                Console.WriteLine("|                                           |");
                Console.WriteLine("|              JOURNAL PROGRAM              |");
                Console.WriteLine("|___________________________________________|");
                Console.WriteLine("|                                           |");
                Console.WriteLine("|  1. Write a New Entry                     |");
                Console.WriteLine("|  2. Display the Journal                   |");
                Console.WriteLine("|  3. Save the Journal to a File            |");
                Console.WriteLine("|  4. Load the Journal from a File          |");
                Console.WriteLine("|  5. Exit                                  |");
                Console.WriteLine("|___________________________________________|");
                Console.Write("\nEnter your choice (1-5): ");

                string choice = Console.ReadLine();
                Console.Clear();

                switch (choice) {
                    case "1":
                        string prompt = promptGenerator.GetRandomPrompt();
                        Console.WriteLine($"Prompt: {prompt}");
                        Console.Write("Your response: ");
                        string response = Console.ReadLine();

                        Entry newEntry = new Entry(DateTime.Now.ToString("yyyy-MM-dd"), prompt, response);
                        myJournal.AddEntry(newEntry);

                        Console.WriteLine("\nEntry saved! Press Enter to return to menu.");
                        Console.ReadLine();
                        break;

                    case "2":
                        myJournal.DisplayAllEntries();
                        Console.WriteLine("\nPress Enter to return to menu.");
                        Console.ReadLine();
                        break;

                    case "3":
                        Console.Write("Enter filename to save journal (e.g. journal.txt): ");
                        string saveFile = Console.ReadLine();
                        myJournal.SaveToFile(saveFile);
                        Console.WriteLine("\nJournal saved successfully! Press Enter to return.");
                        Console.ReadLine();
                        break;

                    case "4":
                        Console.Write("Enter filename to load journal (e.g. journal.txt): ");
                        string loadFile = Console.ReadLine();
                        myJournal.LoadFromFile(loadFile);
                        Console.WriteLine("\nJournal loaded successfully! Press Enter to return.");
                        Console.ReadLine();
                        break;

                    case "5":
                        running = false;
                        Console.WriteLine("Exiting program... Goodbye!");
                        break;

                    default:
                        Console.WriteLine("Invalid choice. Please select a valid option (1-5).");
                        Console.ReadLine();
                        break;
                }

            } while (running);
        }
    }
}

/*
 * EXCEEDING REQUIREMENTS NOTE:
 * - This version uses a clear ASCII-styled bordered menu.
 * - Prompts are dynamically generated via the PromptGenerator class.
 * - The Journal saves and loads entries from a text file with structured formatting.
 * - Demonstrates abstraction via Entry, Journal, and PromptGenerator classes.
 */
