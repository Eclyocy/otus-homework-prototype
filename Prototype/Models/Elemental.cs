using Prototype.Enums;
using Prototype.Interfaces;

namespace Prototype.Models
{
    public class Elemental : Creature, IMyCloneable<Elemental>
    {
        public Element Element { get; protected set; }

        public Elemental(Element element, int maxHealth)
            : base(GetElementalName(element), maxHealth)
        {
            Element = element;
        }

        public Elemental(Element element, Health health)
            : base(GetElementalName(element), health)
        {
            Element = element;
        }

        /// <inheritdoc/>
        public override Elemental MyClone()
        {
            return new Elemental(Element, Health.MyClone());
        }

        /// <inheritdoc/>
        public override void Attack()
        {
            switch (Element)
            {
                case Element.Fire:
                    Console.WriteLine("Scorching!");
                    break;
                case Element.Air:
                    Console.WriteLine("Wailing!");
                    break;
                case Element.Earth:
                    Console.WriteLine("Crushing!");
                    break;
                case Element.Water:
                    Console.WriteLine("Splashing!");
                    break;
                default:
                    base.Attack();
                    break;
            }
        }

        private static string GetElementalName(Element element) => $"{element} Elemental";
    }
}
