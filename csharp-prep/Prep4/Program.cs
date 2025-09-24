using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    static void Main()
    {
        //Console.WriteLine("Hello Prep4 World!");
        
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        while (true)
        {
            Console.Write("Enter number: ");
            string? input = Console.ReadLine();

            if (!int.TryParse(input, out int value))
            {
                Console.WriteLine("Invalid input. Please enter an integer.");
                continue;
            }

            if (value == 0)
            {
                break; 
            }

            numbers.Add(value);
        }

        
        if (numbers.Count == 0)
        {
            Console.WriteLine("No numbers were entered.");
            return;
        }

       
        int sum = numbers.Sum();
        double average = numbers.Average(); 
        int largest = numbers.Max();

        Console.WriteLine($"The sum is: {sum}");
        Console.WriteLine($"The average is: {average:G17}"); 
        Console.WriteLine($"The largest number is: {largest}");

        var positiveNumbers = numbers.Where(n => n > 0);
        if (positiveNumbers.Any())
        {
            int smallestPositive = positiveNumbers.Min();
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }
        else
        {
            Console.WriteLine("There are no positive numbers in the list.");
        }

        var sorted = numbers.OrderBy(n => n).ToList();
        Console.WriteLine("The sorted list is: " + string.Join(", ", sorted));
    }
}
