using Prototype.Interfaces;

namespace Prototype.Models
{
    public class Elemental : Creature, IMyCloneable<Elemental>
    {
        private const string ElementalName = "Elemental";

        public Elemental(int maxHealth)
            : base(ElementalName, maxHealth)
        {
        }

        public Elemental(Health health)
            : base(ElementalName, health)
        {
        }

        public override Elemental MyClone()
        {
            return new Elemental(Health.MyClone());
        }
    }
}
