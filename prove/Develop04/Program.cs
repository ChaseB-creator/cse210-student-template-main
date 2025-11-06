using System;
using System.Collections.Generic;
using System.IO;
using System.Threading;

namespace MindfulnessApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Clear();
            Console.WriteLine("Welcome to the Mindfulness App!");
            Thread.Sleep(800);

            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Menu Options:");
                Console.WriteLine("-------------------------");
                Console.WriteLine("1. Breathing Activity");
                Console.WriteLine("2. Reflection Activity");
                Console.WriteLine("3. Listing Activity");
                Console.WriteLine("4. View Activity Log");
                Console.WriteLine("-------------------------");
                Console.WriteLine("5. Quit");
                Console.WriteLine("\n");
                Console.Write("Select an option: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        new BreathingActivity().Run();
                        break;
                    case "2":
                        new ReflectionActivity().Run();
                        break;
                    case "3":
                        new ListingActivity().Run();
                        break;
                    case "4":
                        Activity.ShowLog();
                        break;
                    case "5":
                        running = false;
                        Console.WriteLine("Goodbye!");
                        Thread.Sleep(1000);
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Try again.");
                        Thread.Sleep(1000);
                        break;
                }
            }
        }
    }
}