using System;

public static class GoalFactory
{
    public static Goal CreateFromString(string line)
    {
        if (string.IsNullOrWhiteSpace(line)) return null;
        var parts = line.Split('|');
        if (parts.Length == 0) return null;
        var type = parts[0];
        try
        {
            switch (type)
            {
                case "SimpleGoal":
                    if (parts.Length >= 5)
                        return new SimpleGoal(parts[1], parts[2], int.Parse(parts[3]), bool.Parse(parts[4]));
                    break;
                case "EternalGoal":
                    if (parts.Length >= 5)
                        return new EternalGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]));
                    break;
                case "ChecklistGoal":
                    if (parts.Length >= 7)
                        return new ChecklistGoal(parts[1], parts[2], int.Parse(parts[3]), int.Parse(parts[4]), int.Parse(parts[5]), int.Parse(parts[6]));
                    break;
            }
        }
        catch
        {
            return null;
        }
        return null;
    }
}
