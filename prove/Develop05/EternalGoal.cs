public class EternalGoal : Goal
{
    private int _times;

    public EternalGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _times = 0;
    }

    public EternalGoal(string name, string description, int points, int times)
        : base(name, description, points)
    {
        _times = times;
    }

    public override int RecordEvent()
    {
        _times++;
        return Points;
    }

    public override bool IsComplete()
    {
        return false;
    }

    public override string GetStatusText()
    {
        return $"[∞] ({_times}x)";
    }

    public override string GetSaveString()
    {
        return $"EternalGoal|{Name}|{Description}|{Points}|{_times}";
    }
}
