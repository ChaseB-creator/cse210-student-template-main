using System;

namespace ConsoleBattleGame
{
    public class Character
    {
        protected string _name;
        protected int _health;
        protected int _baseHealth;
        protected int _damage;
        protected int _healAmount;

        public string GetName() { return _name; }
        public int GetHealth() { return _health; }
        public int GetDamage() { return _damage; }

        public bool Attack(Enemy enemy)
        {
            KeyPromptGenerator generator = new KeyPromptGenerator();
            TimedKeyChecker checker = new TimedKeyChecker();

            char key = generator.GenerateKey();
            Console.WriteLine("Attacking! You have 2 seconds!");

            bool success = checker.WaitForKey(key, 2000);

            if (!success)
            {
                Console.WriteLine("Attack missed!");
                return false;
            }

            enemy.TakeDamage(_damage);
            Console.WriteLine($"You hit the enemy for {_damage} damage!");
            return true;
        }

        public bool Heal()
        {
            KeyPromptGenerator generator = new KeyPromptGenerator();
            TimedKeyChecker checker = new TimedKeyChecker();

            char key = generator.GenerateKey();
            Console.WriteLine("Healing! You have 2 seconds!");

            bool success = checker.WaitForKey(key, 2000);

            if (!success)
            {
                Console.WriteLine("Heal failed!");
                return false;
            }

            _health += _healAmount;

            if (_health > _baseHealth)
                _health = _baseHealth;

            Console.WriteLine($"You restored {_healAmount} health!");
            return true;
        }

        public bool Talk()
        {
            Random r = new Random();
            bool lucky = r.Next(0, 4) == 0;

            if (lucky)
            {
                Console.WriteLine("Your words confused the enemy! It won't attack this turn.");
                return true;
            }

            Console.WriteLine("The enemy ignores you.");
            return false;
        }

        public bool Run()
        {
            Random r = new Random();
            bool run = r.Next(1, 11) == 1;

            if (run)
            {
                Console.WriteLine("You ran away successfully!");
                return true;
            }

            Console.WriteLine("Failed to escape!");
            return false;
        }

        public void TakeDamage(int amount)
        {
            _health -= amount;
        }

        public bool IsAlive()
        {
            return _health > 0;
        }
    }
}
