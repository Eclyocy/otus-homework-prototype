using Prototype.Enums;
using Prototype.Interfaces;
using Prototype.Models;

namespace Prototype
{
    public class Program
    {
        public static void Main(string[] args)
        {
            /* Cloning a previously damaged creature. */

            WriteHeader("Cloning a previously damaged creature");

            Creature creature = new("Creature", 20);
            creature.Health.Current -= 5;

            Creature clone = DemonstrateMyClone(creature);
            DemonstrateMyCloneUnchanged(creature, clone);

            WriteSubHeader("Demonstrating clone attacks...");
            creature.Attack();
            clone.Attack();

            /* Cloning a Bandit. */

            WriteHeader("Cloning a Bandit");

            Bandit bob = new("Bandit Bob", 30);

            Bandit bobClone = DemonstrateMyClone(bob);
            DemonstrateMyCloneUnchanged(bob, bobClone);

            /* Cloning a Bandit Archer: including ICloneable. */

            WriteHeader("Cloning a Bandit Archer: including ICloneable");

            BanditArcher paul = new("Archer Paul", 20, 10);

            BanditArcher paulClone = DemonstrateMyClone(paul);
            object paulCloneObj = paul.Clone();

            WriteSubHeader("Demonstrating clone attacks...");
            paulClone.Attack();
            ((Creature)paulCloneObj).Attack();

            /* Cloning an Elemental. */

            WriteHeader("Cloning an Elemental");

            Elemental fireElemental = new(Element.Fire, 25);
            Elemental earthElemental = new(Element.Earth, 60);

            Elemental earthElementalClone = DemonstrateMyClone(earthElemental);
            object fireElementalCloneObj = fireElemental.Clone();

            WriteSubHeader("Demonstrating clone attacks...");
            earthElementalClone.Attack();
            ((Elemental)fireElementalCloneObj).Attack();
        }

        private static T DemonstrateMyClone<T>(T original)
            where T : IMyCloneable<T>
        {
            WriteSubHeader($"Cloning {original.GetType().Name}...");

            T clone = original.MyClone();

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {clone}");

            return clone;
        }

        private static void DemonstrateMyCloneUnchanged<T>(T original, T clone)
            where T : Creature
        {
            WriteSubHeader($"Changing original {original.GetType().Name}...");

            original.Health.Current -= 5;

            Console.WriteLine($"Original: {original}");
            Console.WriteLine($"Cloned: {clone}");
        }

        private static void WriteColoredLine(string message, ConsoleColor backgroundColor)
        {
            Console.BackgroundColor = backgroundColor;
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine(message);

            Console.ResetColor();
        }

        private static void WriteHeader(string message)
        {
            Console.WriteLine();
            WriteColoredLine(message, ConsoleColor.DarkMagenta);
            Console.WriteLine();
        }

        private static void WriteSubHeader(string message)
        {
            WriteColoredLine(message, ConsoleColor.Green);
        }
    }
}
