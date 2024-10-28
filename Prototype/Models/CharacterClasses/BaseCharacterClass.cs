namespace Prototype.Models.CharacterClasses
{
    public abstract class BaseCharacterClass
    {
        public string Name { get; protected set; }

        public byte Level { get; protected set; }

        public BaseCharacterClass(
            string name,
            byte level = 1)
        {
            Name = name;
            Level = level;
        }

        public virtual void Attack()
        {
            Console.WriteLine($"{Name} attacks!");
        }

        public override string ToString()
        {
            return $"{Name} ({Level})";
        }
    }
}
