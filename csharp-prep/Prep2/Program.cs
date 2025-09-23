using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter your grade (Numerical): ");
        int Grade_Num = int.Parse(Console.ReadLine());

        string letter = "";

        
        if (Grade_Num >= 90)
        {
            letter = "A";
        }
        else if (Grade_Num >= 80)
        {
            letter = "B";
        }
        else if (Grade_Num >= 70)
        {
            letter = "C";
        }
        else if (Grade_Num >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        
        if (letter != "A" && letter != "F") 
        {
            int lastDigit = Grade_Num % 10;
            if (lastDigit >= 7)
            {
                letter += "+";
            }
            else if (lastDigit <= 2)
            {
                letter += "-";
            }
        }

        
        Console.WriteLine($"Your current grade is: {letter}.");

        if (Grade_Num >= 70)
        {
            Console.WriteLine("Congratulations! You passed the class.");
        }
        else
        {
            Console.WriteLine("Keep trying, you'll do better next time!");
        }
    }
}
