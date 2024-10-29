using Prototype.Interfaces;
using Prototype.Models;

namespace Prototype
{
    public class Program
    {
        public const string FireElemental = "Fire Elemental";
        public const string BanditBobName = "Bandit Bob";
        public const string BanditPaulName = "Bandit Paul";

        public static void Main(string[] args)
        {
            /* Cloning a previously damaged creature. */

            Creature creature = new(FireElemental, 20);
            creature.Health.Current -= 5;

            Creature clone = DemonstrateMyClone(creature);
            DemonstrateMyCloneUnchanged(creature, clone);

            creature.Attack();
            clone.Attack();
            Console.WriteLine();

            /* Cloning a Bandit. */

            Bandit bob = new(BanditBobName, 30);

            Bandit bobClone = DemonstrateMyClone(bob);
            DemonstrateMyCloneUnchanged(bob, bobClone);

            /* Cloning a Bandit Archer: including ICloneable. */

            BanditArcher paul = new(BanditPaulName, 20, 10);

            BanditArcher paulClone = DemonstrateMyClone(paul);
            object paulCloneObj = paul.Clone();

            paulClone.Attack();
            ((Creature)paulCloneObj).Attack();
        }

        private static T DemonstrateMyClone<T>(T original)
            where T : IMyCloneable<T>
        {
            Console.WriteLine($"Cloning {original.GetType().Name}...");

            T clone = original.MyClone();

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {clone}");
            Console.WriteLine();

            return clone;
        }

        private static void DemonstrateMyCloneUnchanged<T>(T original, T clone)
            where T : Creature
        {
            Console.WriteLine($"Changing original {original.GetType().Name}...");

            original.Health.Current -= 5;

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {clone}");
            Console.WriteLine();
        }
    }
}
