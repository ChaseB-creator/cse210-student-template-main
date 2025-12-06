namespace ConsoleBattleGame
{
    public class Character
    {
        public string Name { get; protected set; }
        public int Health { get; protected set; }
        public int BaseHealth { get; protected set; }
        public int AttackDamage { get; protected set; }

        public void Attack()
        {
            // Stuff will be added here...
        }

        public void Heal()
        {
            // Stuff will be added here...
        }

        public void Talk()
        {
            // Stuff will be added here...
        }

        public void Run()
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
