using System;

public static class GoalDisplay
{
    public static void PrintGoalLine(int index, Goal goal)
    {
        string color = DetermineColor(goal);
        Console.Write(color);
        Console.Write($"{index}. {goal.GetStatusText()} {goal.Name} - {goal.Description}");
        Console.Write(ConsoleColors.Reset);
        Console.WriteLine();
    }

    private static string DetermineColor(Goal goal)
    {
        if (goal is EternalGoal) return ConsoleColors.Yellow;
        return goal.IsComplete() ? ConsoleColors.Green : ConsoleColors.Red;
    }
}
