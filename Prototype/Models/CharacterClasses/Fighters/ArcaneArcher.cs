namespace Prototype.Models.CharacterClasses.Fighters
{
    public class ArcaneArcher : Fighter
    {
        private bool ArrowEnchanted;

        public ArcaneArcher()
            : base(name: nameof(ArcaneArcher))
        {
            ArrowEnchanted = false;
        }

        public override void Attack()
        {
            base.Attack();

            if (!ArrowEnchanted)
            {
                Console.WriteLine($"Shoots an arrow.");

                return;
            }

            Console.WriteLine($"Shoots an enchanted arrow!");
            ArrowEnchanted = false;
        }

        public void CastSpell()
        {
            Console.WriteLine($"Enchants their arrow...");
            ArrowEnchanted = true;
        }
    }
}
