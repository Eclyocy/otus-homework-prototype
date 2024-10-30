using Prototype.Models;
using Prototype.Tests.Interfaces;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Creature"/>.
    /// </summary>
    [TestFixture]
    public class CreatureTests : MyCloneableTestBase<Creature>
    {
        private const string CreatureName = "Rat Swarm";
        private const int CreatureMaxHealth = 5;

        /// <summary>
        /// Test that constructor initializes all the properties.
        /// </summary>
        [Test]
        public void Test_Constructor()
        {
            Creature creature = new(CreatureName, CreatureMaxHealth);

            Assert.Multiple(() =>
            {
                Assert.That(creature.Name, Is.EqualTo(CreatureName));
                Assert.That(creature.Health.Current, Is.EqualTo(CreatureMaxHealth));
                Assert.That(creature.Health.Max, Is.EqualTo(CreatureMaxHealth));
            });
        }

        /// <inheritdoc/>
        protected override Creature CreateInstance()
        {
            return new(CreatureName, CreatureMaxHealth);
        }

        /// <inheritdoc/>
        protected override void ModifyInstance(Creature instance)
        {
            instance.Health.Current -= 5;
        }
    }
}
