using System;

public class SimpleGoal : Goal
{
    private bool _isComplete;

    public SimpleGoal(string name, string description, int points)
        : base(name, description, points)
    {
        _isComplete = false;
    }

    public SimpleGoal(string name, string description, int points, bool complete)
        : base(name, description, points)
    {
        _isComplete = complete;
    }

    public override int RecordEvent()
    {
        _isComplete = true;
        return Points;
    }

    public override bool IsComplete()
    {
        return _isComplete;
    }

    public override string GetStatusText()
    {
        return IsComplete() ? "[X]" : "[ ]";
    }

    public override string GetSaveString()
    {
        return $"SimpleGoal|{Name}|{Description}|{Points}|{IsComplete()}";
    }
}
