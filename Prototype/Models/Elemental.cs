using Prototype.Enums;
using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// An elemental creature.
    /// </summary>
    public class Elemental : Creature, IMyCloneable<Elemental>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Elemental"/> class.<br/>
        /// Current health is set as <paramref name="maxHealth"/>.
        /// </summary>
        /// <param name="element">Value indicating the element of the elemental.</param>
        /// <param name="maxHealth">Elemental maximum (and current) health points.</param>
        public Elemental(Element element, int maxHealth)
            : base(GetElementalName(element), maxHealth)
        {
            Element = element;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Elemental"/> class.
        /// </summary>
        /// <param name="element">Value indicating the element of the elemental.</param>
        /// <param name="health">Elemental health.</param>
        public Elemental(Element element, Health health)
            : base(GetElementalName(element), health)
        {
            Element = element;
        }

        /// <summary>
        /// Gets or sets the element of the elemental.
        /// </summary>
        public Element Element { get; protected set; }

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

        /// <summary>
        /// Get the elemental creature name based on its element.
        /// </summary>
        private static string GetElementalName(Element element) => $"{element} Elemental";
    }
}
