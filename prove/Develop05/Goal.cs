public abstract class Goal
{
    private string _name;
    private string _description;
    private int _points;

    public string Name => _name;
    public string Description => _description;
    public int Points => _points;

    protected Goal(string name, string description, int points)
    {
        _name = name;
        _description = description;
        _points = points;
    }

    public void Rename(string newName)
    {
        if (!string.IsNullOrWhiteSpace(newName))
        {
            _name = newName.Trim();
        }
    }

    public void EditDescription(string newDescription)
    {
        _description = newDescription ?? "";
    }

    public abstract int RecordEvent();
    public abstract bool IsComplete();
    public abstract string GetStatusText();
    public abstract string GetSaveString();
}
