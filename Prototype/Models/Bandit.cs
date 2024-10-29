using Prototype.Interfaces;

namespace Prototype.Models
{
    public class Bandit : Creature, IMyCloneable<Bandit>
    {
        private int _goldCoins;

        public int GoldCoins
        {
            get => _goldCoins;
            set {
                ArgumentOutOfRangeException.ThrowIfNegative(value);

                _goldCoins = value;
            }
        }

        public Bandit(string name, int maxHealth, int goldCoins = 0)
            : base(name, maxHealth)
        {
            GoldCoins = goldCoins;
        }

        public Bandit(string name, Health health, int goldCoins = 0)
            : base(name, health)
        {
            GoldCoins = goldCoins;
        }

        /// <inheritdoc/>
        public override Bandit MyClone()
        {
            return new Bandit(Name, Health.MyClone(), GoldCoins);
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return base.ToString() + $" with {GoldCoins} gold coins";
        }

        public override void Attack()
        {
            Console.WriteLine("Yarr! Gimme yer gold!");
        }
    }
}
