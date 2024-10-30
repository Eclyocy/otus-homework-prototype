using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// A common bandit.
    /// </summary>
    public class Bandit : Creature, IMyCloneable<Bandit>
    {
        private int _goldCoins;

        /// <summary>
        /// Initializes a new instance of the <see cref="Bandit"/> class.<br/>
        /// Current health is set as <paramref name="maxHealth"/>.
        /// </summary>
        /// <param name="name">Bandit name.</param>
        /// <param name="maxHealth">Bandit maximum (and current) health points.</param>
        /// <param name="goldCoins">The number of gold coins carried by the bandit.</param>
        public Bandit(string name, int maxHealth, int goldCoins = 0)
            : base(name, maxHealth)
        {
            GoldCoins = goldCoins;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Bandit"/> class.
        /// </summary>
        /// <param name="name">Bandit name.</param>
        /// <param name="health">Bandit health.</param>
        /// <param name="goldCoins">The number of gold coins carried by the bandit.</param>
        public Bandit(string name, Health health, int goldCoins = 0)
            : base(name, health)
        {
            GoldCoins = goldCoins;
        }

        /// <summary>
        /// Gets or sets the number of gold coins carried by the bandit.
        /// </summary>
        public int GoldCoins
        {
            get => _goldCoins;
            set
            {
                ArgumentOutOfRangeException.ThrowIfNegative(value);

                _goldCoins = value;
            }
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

        /// <inheritdoc/>
        public override void Attack()
        {
            Console.WriteLine("Yarr! Gimme yer gold!");
        }
    }
}
