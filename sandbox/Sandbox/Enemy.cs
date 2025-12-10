using System;

namespace ConsoleBattleGame
{
    public class Enemy
    {
        protected string _name;
        protected int _health;
        protected int _damage;

        public string GetName() { return _name; }
        public int GetHealth() { return _health; }

        public void TakeDamage(int amount)
        {
            _health -= amount;
        }

        public bool IsAlive()
        {
            return _health > 0;
        }

        public void Attack(Character player)
        {
            Console.WriteLine($"{_name} attacks you for {_damage} damage!");
            player.TakeDamage(_damage);
        }
    }
}
