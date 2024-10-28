namespace Prototype.Models.CharacterClasses.Fighters
{
    public class Fighter : BaseCharacterClass
    {
        public Fighter()
            : base(name: nameof(Fighter))
        {
        }

        public Fighter(string name)
            : base(name: name)
        {
        }
    }
}
