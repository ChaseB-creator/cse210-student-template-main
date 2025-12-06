namespace ConsoleBattleGame
{
    public class Enemy
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int BaseHealth { get; protected set; }
        public int AttackDamage { get; protected set; }

        public void Attack()
        {
            // Stuff will be added here...
        }

        public bool IsAlive()
        {
           // Stuff will be added here...
            return true;
        }
    }
}
