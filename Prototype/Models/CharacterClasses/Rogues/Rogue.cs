namespace Prototype.Models.CharacterClasses.Rogues
{
    public class Rogue : BaseCharacterClass
    {
        public Rogue()
            : base(name: nameof(Rogue))
        {
        }

        public Rogue(string name)
            : base(name: name)
        {
        }
    }
}
