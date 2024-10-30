using Prototype.Models;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Creature"/>.
    /// </summary>
    [TestFixture]
    public class CreatureTests
    {
        private const string CreatureName = "Fire Elemental";
        private const int CreatureMaxHealth = 25;

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

        [Test]
        public void Test_MyClone_ClonedProperties()
        {
            Creature creature = new(CreatureName, CreatureMaxHealth);

            Creature clone = creature.MyClone();

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(creature));
                Assert.That(clone, Is.EqualTo(creature));

                Assert.That(clone.Name, Is.EqualTo(creature.Name));

                Assert.That(clone.Health, Is.Not.SameAs(creature.Health));
                Assert.That(clone.Health, Is.EqualTo(creature.Health));
            });
        }

        [Test]
        public void Test_MyClone_CopiesTrailingCurrentHealth_WhenOriginalIsChangedBeforeCloning()
        {
            Creature creature = new(CreatureName, CreatureMaxHealth);
            creature.Health.Current -= 5;

            Creature clone = creature.MyClone();

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(creature));
                Assert.That(clone, Is.EqualTo(creature));

                Assert.That(clone.Name, Is.EqualTo(creature.Name));

                Assert.That(clone.Health, Is.Not.SameAs(creature.Health));
                Assert.That(clone.Health, Is.EqualTo(creature.Health));

                Assert.That(creature.Health.Current, Is.EqualTo(CreatureMaxHealth - 5));
                Assert.That(clone.Health.Current, Is.EqualTo(CreatureMaxHealth - 5));
            });
        }

        [Test]
        public void Test_MyClone_CopiesStartingCurrentHealth_WhenOriginalIsChangedAfterCloning()
        {
            Creature creature = new(CreatureName, CreatureMaxHealth);

            Creature clone = creature.MyClone();
            creature.Health.Current -= 5;

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(creature));
                Assert.That(clone, Is.Not.EqualTo(creature));

                Assert.That(clone.Name, Is.EqualTo(creature.Name));

                Assert.That(clone.Health, Is.Not.SameAs(creature.Health));
                Assert.That(clone.Health, Is.Not.EqualTo(creature.Health));

                Assert.That(creature.Health.Current, Is.EqualTo(CreatureMaxHealth - 5));
                Assert.That(clone.Health.Current, Is.EqualTo(CreatureMaxHealth));
            });
        }

        [Test]
        public void Test_Clone_IsEqualToMyClone()
        {
            Creature creature = new(CreatureName, CreatureMaxHealth);

            Creature clone = creature.MyClone();
            object cloneObj = creature.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(cloneObj, Is.Not.SameAs(clone));
                Assert.That(cloneObj, Is.EqualTo(clone));

                Assert.That(cloneObj is Creature);
            });
        }
    }
}
