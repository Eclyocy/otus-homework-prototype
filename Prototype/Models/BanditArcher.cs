using Prototype.Interfaces;

namespace Prototype.Models
{
    public class BanditArcher : Bandit, IMyCloneable<BanditArcher>
    {
        public BanditArcher(string name, int maxHealth, int goldCoins = 0)
            : base(name, maxHealth, goldCoins)
        {
        }

        public BanditArcher(string name, Health health, int goldCoins = 0)
            : base(name, health, goldCoins)
        {
        }

        /// <inheritdoc/>
        public override BanditArcher MyClone()
        {
            return new BanditArcher(Name, Health.MyClone(), GoldCoins);
        }

        /// <inheritdoc/>
        public override void Attack()
        {
            Console.WriteLine("Archer stealthily shoots an arrow!");
        }
    }
}
