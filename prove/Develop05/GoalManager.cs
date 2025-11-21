using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;

    public void Run()
    {
        int choice = 0;
        while (choice != 6)
        {
            ShowMenu();
            choice = int.Parse(Console.ReadLine());

            switch (choice)
            {
                case 1: CreateGoal(); break;
                case 2: ListGoals(); break;
                case 3: RecordEvent(); break;
                case 4: SaveGoals(); break;
                case 5: LoadGoals(); break;
                case 6: Console.WriteLine("Goodbye!"); break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine("\n=== Eternal Quest ===");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine("1. Create New Goal");
        Console.WriteLine("2. List Goals");
        Console.WriteLine("3. Record Event");
        Console.WriteLine("4. Save Goals");
        Console.WriteLine("5. Load Goals");
        Console.WriteLine("6. Quit");
        Console.Write("Choose an option: ");
    }

    private void CreateGoal()
    {
        Console.WriteLine("\nChoose Goal Type:");
        Console.WriteLine("1. Simple Goal");
        Console.WriteLine("2. Eternal Goal");
        Console.WriteLine("3. Checklist Goal");
        Console.Write("Your choice: ");
        int type = int.Parse(Console.ReadLine());

        Console.Write("Name: ");
        string name = Console.ReadLine();

        Console.Write("Description: ");
        string desc = Console.ReadLine();

        Console.Write("Points: ");
        int points = int.Parse(Console.ReadLine());

        if (type == 1)
        {
            _goals.Add(new SimpleGoal(name, desc, points));
        }
        else if (type == 2)
        {
            _goals.Add(new EternalGoal(name, desc, points));
        }
        else if (type == 3)
        {
            Console.Write("Times required: ");
            int target = int.Parse(Console.ReadLine());

            Console.Write("Bonus points: ");
            int bonus = int.Parse(Console.ReadLine());

            _goals.Add(new ChecklistGoal(name, desc, points, target, bonus));
        }

        Console.WriteLine("Goal created!");
    }

    private void ListGoals()
    {
        Console.WriteLine("\n=== Goals ===");
        int index = 1;

        foreach (var goal in _goals)
        {
            Console.WriteLine($"{index}. {goal.GetStatusText()} {goal.Name} - {goal.Description}");
            index++;
        }
    }

    private void RecordEvent()
    {
        ListGoals();

        Console.Write("\nWhich goal did you accomplish? ");
        int choice = int.Parse(Console.ReadLine());
        int pointsEarned = _goals[choice - 1].RecordEvent();

        _score += pointsEarned;
        Console.WriteLine($"You earned {pointsEarned} points!");
    }

    private void SaveGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        using (StreamWriter writer = new StreamWriter(filename))
        {
            writer.WriteLine(_score);
            foreach (var goal in _goals)
            {
                writer.WriteLine(goal.GetSaveString());
            }
        }

        Console.WriteLine("Goals saved!");
    }

    private void LoadGoals()
    {
        Console.Write("Filename: ");
        string filename = Console.ReadLine();

        if (!File.Exists(filename))
        {
            Console.WriteLine("File not found.");
            return;
        }

        _goals.Clear();

        string[] lines = File.ReadAllLines(filename);

        _score = int.Parse(lines[0]);

        for (int i = 1; i < lines.Length; i++)
        {
            string[] parts = lines[i].Split("|");
            string type = parts[0];

            if (type == "SimpleGoal")
            {
                _goals.Add(new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4])));
            }
            else if (type == "EternalGoal")
            {
                _goals.Add(new EternalGoal(parts[1], parts[2], int.Parse(parts[3])));
            }
            else if (type == "ChecklistGoal")
            {
                _goals.Add(new ChecklistGoal(
                    parts[1],
                    parts[2],
                    int.Parse(parts[3]),
                    int.Parse(parts[4]),
                    int.Parse(parts[5]),
                    int.Parse(parts[6])
                ));
            }
        }

        Console.WriteLine("Goals loaded!");
    }
}
