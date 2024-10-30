using Prototype.Models;
using Prototype.Tests.Interfaces;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Health"/>.
    /// </summary>
    [TestFixture]
    public class HealthTests : MyCloneableTestBase<Health>
    {
        private const int HealthMaximim = 10;

        /// <summary>
        /// Test that constructor with unspecified current health
        /// sets current to maximum.
        /// </summary>
        /// <param name="maximumHealth">Maximum health points supplied to the constructor.</param>
        /// <returns>Current health points.</returns>
        [TestCase(0, ExpectedResult = 0)]
        [TestCase(HealthMaximim, ExpectedResult = HealthMaximim)]
        public int Test_Constructor_SetsCurrent_ToMax_WhenCurrentIsNotSpecified(
            int maximumHealth)
        {
            Health health = new(maximumHealth);

            return health.Current;
        }

        /// <summary>
        /// Test that constructor with specified current health
        /// sets current to the specified value,
        /// unless it is out of bounds of the [0; maximum] interval,
        /// in which case it is adjusted to the interval end.
        /// </summary>
        /// <param name="currentHealth">Current health points supplied to the constructor.</param>
        /// <param name="maximumHealth">Maximum health points supplied to the constructor.</param>
        /// <returns>Current health points.</returns>
        [TestCase(-1, 10, ExpectedResult = 0)]
        [TestCase(0, 10, ExpectedResult = 0)]
        [TestCase(5, 10, ExpectedResult = 5)]
        [TestCase(10, 10, ExpectedResult = 10)]
        [TestCase(15, 10, ExpectedResult = 10)]
        public int Test_Constructor_SetsCurrent_WhenCurrentIsSpecified(
            int currentHealth,
            int maximumHealth)
        {
            Health health = new(maximum: maximumHealth, current: currentHealth);

            return health.Current;
        }

        /// <summary>
        /// Test that <see cref="Health.Current"/> retains
        /// in the [0; maximum] interval.
        /// </summary>
        /// <param name="currentHealth">Current health points.</param>
        /// <param name="currentHealthModification">Current health points modification.</param>
        /// <returns>Current health points after modification.</returns>
        [TestCase(1, -10, ExpectedResult = 0)]
        [TestCase(1, -1, ExpectedResult = 0)]
        [TestCase(HealthMaximim, +1, ExpectedResult = HealthMaximim)]
        public int Test_Current_DoesNotAllowOverflow(
            int currentHealth,
            int currentHealthModification)
        {
            Health health = new(maximum: HealthMaximim, current: currentHealth);

            health.Current += currentHealthModification;

            return health.Current;
        }

        /// <inheritdoc/>
        protected override Health CreateInstance()
        {
            return new(maximum: HealthMaximim, current: 5);
        }

        /// <inheritdoc/>
        protected override void ModifyInstance(Health instance)
        {
            instance.Current -= 5;
        }
    }
}
