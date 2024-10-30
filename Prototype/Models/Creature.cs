using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// A basic creature.
    /// </summary>
    public class Creature : IMyCloneable<Creature>, IEquatable<Creature>, ICloneable, IAttacking
    {
        private string _name;

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.<br/>
        /// Current health is set as <paramref name="maxHealth"/>.
        /// </summary>
        /// <param name="name">Creature name.</param>
        /// <param name="maxHealth">Creature maximum (and current) health points.</param>
        public Creature(string name, int maxHealth)
        {
            Name = name;
            Health = new Health(maximum: maxHealth);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Creature"/> class.
        /// </summary>
        /// <param name="name">Creature name.</param>
        /// <param name="health">Creature health.</param>
        public Creature(string name, Health health)
        {
            Name = name;
            Health = health;
        }

        /// <summary>
        /// Gets or sets the creature name.
        /// </summary>
        public string Name
        {
            get => _name;
            set
            {
                ArgumentException.ThrowIfNullOrWhiteSpace(nameof(value));

                _name = value;
            }
        }

        /// <summary>
        /// Gets or sets the creature health.
        /// </summary>
        public Health Health { get; set; }

        /// <inheritdoc/>
        public virtual Creature MyClone()
        {
            return new Creature(Name, Health.MyClone());
        }

        /// <inheritdoc/>
        public object Clone() => MyClone();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Name}, HP: {Health}";
        }

        /// <inheritdoc/>
        public bool Equals(Creature? other)
        {
            return other != null &&
                other.Name == Name &&
                other.Health.Equals(Health);
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Creature);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Health);
        }

        /// <inheritdoc/>
        public virtual void Attack()
        {
            Console.WriteLine("Producing basic attack.");
        }
    }
}
