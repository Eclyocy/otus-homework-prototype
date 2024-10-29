using Prototype.Interfaces;

namespace Prototype.Models
{
    public class Creature : IMyCloneable<Creature>, IEquatable<Creature>, ICloneable, IAttacking
    {
        public string Name { get; set; }

        public Health Health { get; set; }

        public Creature(string name, int maxHealth)
        {
            Name = name;
            Health = new Health(maximum: maxHealth);
        }

        public Creature(string name, Health health)
        {
            Name = name;
            Health = health;
        }

        /// <inheritdoc/>
        public virtual Creature MyClone()
        {
            return new Creature(Name, Health.MyClone());
        }

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

        public object Clone() => MyClone();

        public virtual void Attack()
        {
            Console.WriteLine("Producing basic attack.");
        }
    }
}
