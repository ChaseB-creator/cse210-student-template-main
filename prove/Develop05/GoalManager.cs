using System;
using System.Collections.Generic;
using System.IO;

public class GoalManager
{
    private List<Goal> _goals = new List<Goal>();
    private int _score = 0;
    private RenameManager _renamer = new RenameManager();

    public void Run()
    {
        while (true)
        {
            ShowMenu();
            var input = Console.ReadLine();
            if (input == null) continue;
            switch (input.Trim())
            {
                case "1": CreateGoal(); break;
                case "2": ListGoals(); break;
                case "3": RecordEvent(); break;
                case "4": SaveGoals(); break;
                case "5": LoadGoals(); break;
                case "6": RenameFlow(); break;
                case "7": ShowScore(); break;
                case "0": Console.WriteLine("Goodbye!"); return;
                default: Console.WriteLine("Invalid option."); break;
            }
        }
    }

    private void ShowMenu()
    {
        Console.WriteLine();
        Console.WriteLine($"{ConsoleColors.Cyan}=== Eternal Quest ==={ConsoleColors.Reset}");
        Console.WriteLine($"Score: {_score}");
        Console.WriteLine("1) Create New Goal");
        Console.WriteLine("2) Show All Goals");
        Console.WriteLine("3) Record an Event (complete/gain points)");
        Console.WriteLine("4) Save Goals to File");
        Console.WriteLine("5) Load Goals from File");
        Console.WriteLine("6) Rename / Edit a Goal (backtrack)");
        Console.WriteLine("7) Show Score/Level Info");
        Console.WriteLine("0) Quit");
        Console.Write("Choose an option: ");
    }

    private void CreateGoal()
    {
        Console.WriteLine("Choose type: 1) Simple 2) Eternal 3) Checklist");
        var t = Console.ReadLine();
        Console.Write("Title: ");
        string title = Console.ReadLine() ?? "";
        Console.Write("Description: ");
        string desc = Console.ReadLine() ?? "";
        Console.Write("Points: ");
        int points = ReadIntFallback(0);
        if (t == "1")
        {
            _goals.Add(new SimpleGoal(title, desc, points));
        }
        else if (t == "2")
        {
            _goals.Add(new EternalGoal(title, desc, points));
        }
        else if (t == "3")
        {
            Console.Write("Times required: ");
            int target = ReadIntFallback(1);
            Console.Write("Bonus points: ");
            int bonus = ReadIntFallback(0);
            _goals.Add(new ChecklistGoal(title, desc, points, target, bonus));
        }
        Console.WriteLine("Goal created.");
    }

    private void ListGoals()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals yet.");
            return;
        }
        for (int i = 0; i < _goals.Count; i++)
        {
            GoalDisplay.PrintGoalLine(i + 1, _goals[i]);
        }
    }

    private void RecordEvent()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to record.");
            return;
        }
        ListGoals();
        Console.Write("Which goal number did you progress? ");
        int idx = ReadIntInRange(1, _goals.Count) - 1;
        int earned = _goals[idx].RecordEvent();
        if (earned <= 0)
        {
            Console.WriteLine("No points awarded (maybe already complete).");
            return;
        }
        _score += earned;
        Console.WriteLine($"You earned {earned} points. Total: {_score}");
        ShowLevelProgress();
    }

    private void SaveGoals()
    {
        Console.Write("Filename to save: ");
        var fn = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fn)) fn = "quests.txt";
        try
        {
            using (var w = new StreamWriter(fn))
            {
                w.WriteLine($"Score:{_score}");
                foreach (var g in _goals) w.WriteLine(g.GetSaveString());
            }
            Console.WriteLine("Saved.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving: {ex.Message}");
        }
    }

    private void LoadGoals()
    {
        Console.Write("Filename to load: ");
        var fn = Console.ReadLine();
        if (string.IsNullOrWhiteSpace(fn) || !File.Exists(fn))
        {
            Console.WriteLine("File not found.");
            return;
        }
        try
        {
            var lines = File.ReadAllLines(fn);
            var loaded = new List<Goal>();
            int loadedScore = 0;
            foreach (var line in lines)
            {
                if (line.StartsWith("Score:"))
                {
                    int.TryParse(line.Substring(6), out loadedScore);
                    continue;
                }
                var g = GoalFactory.CreateFromString(line);
                if (g != null) loaded.Add(g);
            }
            _goals = loaded;
            _score = loadedScore;
            Console.WriteLine("Loaded.");
            ShowLevelProgress();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading: {ex.Message}");
        }
    }

    private void RenameFlow()
    {
        if (_goals.Count == 0)
        {
            Console.WriteLine("No goals to rename.");
            return;
        }
        ListGoals();
        Console.Write("Which goal number to edit? ");
        int idx = ReadIntInRange(1, _goals.Count) - 1;
        _renamer.RenameGoal(_goals[idx]);
    }

    private void ShowScore()
    {
        Console.WriteLine($"Score: {_score}");
        ShowLevelProgress();
    }

    private void ShowLevelProgress()
    {
        int level = (_score / 1000) + 1;
        int progress = _score % 1000;
        Console.WriteLine($"Level {level} — {progress}/1000 to next level.");
    }

    private int ReadIntFallback(int fallback)
    {
        var s = Console.ReadLine();
        if (int.TryParse(s, out int v)) return v;
        return fallback;
    }

    private int ReadIntInRange(int min, int max)
    {
        while (true)
        {
            var s = Console.ReadLine();
            if (int.TryParse(s, out int v) && v >= min && v <= max) return v;
            Console.Write($"Enter a number between {min} and {max}: ");
        }
    }
}
