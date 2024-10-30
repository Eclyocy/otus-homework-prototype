using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// A bandit archer.
    /// </summary>
    public class BanditArcher : Bandit, IMyCloneable<BanditArcher>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BanditArcher"/> class.<br/>
        /// Current health is set as <paramref name="maxHealth"/>.
        /// </summary>
        /// <param name="name">Bandit archer name.</param>
        /// <param name="maxHealth">Bandit archer maximum (and current) health points.</param>
        /// <param name="goldCoins">The number of gold coins carried by the bandit archer.</param>
        public BanditArcher(string name, int maxHealth, int goldCoins = 0)
            : base(name, maxHealth, goldCoins)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="BanditArcher"/> class.
        /// </summary>
        /// <param name="name">Bandit archer name.</param>
        /// <param name="health">Bandit archer health.</param>
        /// <param name="goldCoins">The number of gold coins carried by the bandit archer.</param>
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
