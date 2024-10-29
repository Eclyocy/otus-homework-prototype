using Prototype.Models;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Health"/>.
    /// </summary>
    [TestFixture]
    public class HealthTests
    {
        private const int HealthCurrent = 5;
        private const int HealthMaximim = 10;

        [Test]
        public void Test_Constructor_SetsCurrentToMax_WhenCurrentNotSpecified()
        {
            Health health = new(HealthMaximim);

            Assert.Multiple(() =>
            {
                Assert.That(health.Current, Is.EqualTo(HealthMaximim));
                Assert.That(health.Max, Is.EqualTo(HealthMaximim));
            });
        }

        [Test]
        public void Test_Constructor_SetsCurrent_WhenCurrentSpecified()
        {
            Health health = new(maximum: HealthMaximim, current: HealthCurrent);

            Assert.Multiple(() =>
            {
                Assert.That(health.Current, Is.EqualTo(HealthCurrent));
                Assert.That(health.Max, Is.EqualTo(HealthMaximim));
            });
        }

        [Test]
        public void Test_Constructor_SetsCurrentToMax_WhenCurrentOverflowsMax()
        {
            Health health = new(maximum: HealthMaximim, current: HealthMaximim * 2);

            Assert.Multiple(() =>
            {
                Assert.That(health.Current, Is.EqualTo(HealthMaximim));
                Assert.That(health.Max, Is.EqualTo(HealthMaximim));
            });
        }

        [Test]
        public void Test_Current_DoesNotAllowOverflow()
        {
            Health health = new(HealthMaximim);

            health.Current += 10;

            Assert.That(health.Current, Is.EqualTo(HealthMaximim));
        }

        [Test]
        public void Test_Current_DoesNotDropBelowZero()
        {
            Health health = new(maximum: HealthMaximim, current: 1);

            health.Current -= 10;

            Assert.That(health.Current, Is.EqualTo(0));
        }

        [Test]
        public void Test_MyClone_ClonedProperties()
        {
            Health health = new(maximum: HealthMaximim, current: HealthCurrent);

            Health clone = health.MyClone();

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(health));
                Assert.That(clone, Is.EqualTo(health));

                Assert.That(clone.Current, Is.EqualTo(HealthCurrent));
                Assert.That(clone.Max, Is.EqualTo(HealthMaximim));
            });
        }

        [Test]
        public void Test_MyClone_IsNotAffectedByChangesToOriginal()
        {
            Health health = new(maximum: HealthMaximim);

            Health clone = health.MyClone();
            health.Current -= 5;

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(health));
                Assert.That(clone, Is.Not.EqualTo(health));

                Assert.That(health.Current, Is.EqualTo(HealthMaximim - 5));
                Assert.That(clone.Current, Is.EqualTo(HealthMaximim));
            });
        }

        [Test]
        public void Test_Clone_IsEqualToMyClone()
        {
            Health health = new(maximum: HealthMaximim, current: HealthCurrent);

            Health clone = health.MyClone();
            object cloneObj = health.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(cloneObj, Is.Not.SameAs(clone));
                Assert.That(cloneObj, Is.EqualTo(clone));

                Assert.That(cloneObj is Health);
            });
        }
    }
}
