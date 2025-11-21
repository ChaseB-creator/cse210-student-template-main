public class ChecklistGoal : Goal
{
    private int _target;
    private int _count;
    private int _bonus;

    public ChecklistGoal(string name, string description, int points, int target, int bonus)
        : base(name, description, points)
    {
        _target = target < 1 ? 1 : target;
        _bonus = bonus < 0 ? 0 : bonus;
        _count = 0;
    }

    public ChecklistGoal(string name, string description, int points, int target, int bonus, int count)
        : base(name, description, points)
    {
        _target = target < 1 ? 1 : target;
        _bonus = bonus < 0 ? 0 : bonus;
        _count = count < 0 ? 0 : count;
    }

    public override int RecordEvent()
    {
        if (IsComplete()) return 0;
        _count++;
        int awarded = Points;
        if (_count >= _target) awarded += _bonus;
        return awarded;
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

    public void SetTarget(int newTarget)
    {
        if (newTarget >= 1) _target = newTarget;
    }

    public void SetBonus(int newBonus)
    {
        if (newBonus >= 0) _bonus = newBonus;
    }
}
