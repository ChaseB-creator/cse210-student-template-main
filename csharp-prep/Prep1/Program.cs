using System;

class Program
{
    static void Main(string[] args)
    {
        // Console.WriteLine("Hello Prep1 World!");
        Console.WriteLine("Please enter your first name: ");
        string Name = Console.ReadLine();
        Console.WriteLine("Please enter your last name: ");
        string L_Name = Console.ReadLine();

        Console.WriteLine("Your name is "+ L_Name + ", " + Name + " " + L_Name + ".");

    }
}