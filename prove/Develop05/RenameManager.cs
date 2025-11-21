using System;

public class RenameManager
{
    public void RenameGoal(Goal goal)
    {
        Console.Write("New title (leave empty to keep current): ");
        string newTitle = Console.ReadLine();
        if (!string.IsNullOrWhiteSpace(newTitle)) goal.Rename(newTitle);

        Console.Write("New description (leave empty to keep current): ");
        string newDesc = Console.ReadLine();
        if (!string.IsNullOrEmpty(newDesc)) goal.EditDescription(newDesc);

        if (goal is ChecklistGoal checklist)
        {
            Console.Write("Enter new target times (leave empty to keep current): ");
            string t = Console.ReadLine();
            if (int.TryParse(t, out int nt) && nt >= 1) checklist.SetTarget(nt);

            Console.Write("Enter new bonus points (leave empty to keep current): ");
            string b = Console.ReadLine();
            if (int.TryParse(b, out int nb) && nb >= 0) checklist.SetBonus(nb);
        }

        Console.WriteLine("Goal updated.");
    }
}
