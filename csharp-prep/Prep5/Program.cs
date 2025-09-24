using System;

class Program
{
    static void Main(string[] args)
    {

        //Console.WriteLine("Hello Prep5 World!");

        
        DisplayWelcome();

    
        string userName = PromptUserName();

       
        int favoriteNumber = PromptUserNumber();

        int birthYear;
        PromptUserBirthYear(out birthYear);

   
        int squaredNumber = SquareNumber(favoriteNumber);

       
        DisplayResult(userName, squaredNumber, birthYear);
    }

    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to the program!");
    }

    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();
        return name;
    }

    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        string input = Console.ReadLine();
        int number = int.Parse(input);
        return number;
    }

    static void PromptUserBirthYear(out int birthYear)
    {
        Console.Write("Please enter the year you were born: ");
        string input = Console.ReadLine();
        birthYear = int.Parse(input);
    }

    static int SquareNumber(int number)
    {
        return number * number;
    }

    static void DisplayResult(string name, int squaredNumber, int birthYear)
    {
        Console.WriteLine($"{name}, the square of your number is {squaredNumber}");

        int currentYear = DateTime.Now.Year;
        int age = currentYear - birthYear;

        Console.WriteLine($"{name}, you will turn {age} this year.");
    }
}
