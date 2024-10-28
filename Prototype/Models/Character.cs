using Prototype.Models.CharacterClasses;
using Prototype.Models.CharacterClasses.Fighters;

namespace Prototype.Models
{
    /// <summary>
    /// Character model.
    /// </summary>
    public class Character
    {
        /// <summary>
        /// Character name.
        /// </summary>
        public string Name { get; protected set; } = "The Nameless One";

        /// <summary>
        /// Character classes.
        /// </summary>
        /// <remarks>
        /// Characters with multiple classes are called "multiclass characters".
        /// </remarks>
        public List<BaseCharacterClass> CharacterClasses { get; protected set; } = [new Fighter()];

        /// <summary>
        /// Character health.
        /// </summary>
        public Health Health { get; protected set; } = new();

        /// <inheritdoc/>
        public override string ToString()
        {
            return string.Format(
                "Character: {0}, {1}, HP {2}",
                Name,
                string.Join(", ", CharacterClasses),
                Health);
        }
    }
}
