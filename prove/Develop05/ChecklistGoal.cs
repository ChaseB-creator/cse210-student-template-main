using System;

public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _count = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int count)
        : base(name, description, points)
    {
        _target = target;
        _bonus = bonus;
        _count = count;
    }

    public override int RecordEvent()
    {
        _count++;

        if (_count == _target)
        {
            return Points + _bonus;
        }

        return Points;
    }

    public override bool IsComplete()
    {
        return _count >= _target;
    }

    public override string GetStatusText()
    {
        return $"[{_count}/{_target}] {(IsComplete() ? "[X]" : "[ ]")}";
    }

    public override string GetSaveString()
    {
        return $"ChecklistGoal|{Name}|{Description}|{Points}|{_target}|{_bonus}|{_count}";
    }
}
