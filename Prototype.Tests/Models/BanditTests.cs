using Prototype.Models;
using Prototype.Tests.Interfaces;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Bandit"/>.
    /// </summary>
    [TestFixture]
    public class BanditTests : MyCloneableTestBase<Bandit>
    {
        private const string BanditName = "Bob";
        private const int BanditMaxHealth = 30;
        private const int BanditGoldCoins = 15;

        /// <summary>
        /// Test that constructor sets the gold coins to zero
        /// when gold coins number is not specified.
        /// </summary>
        [Test]
        public void Test_Constructor_SetsGoldCoinsToZero_WhenGoldCoinsNotSpecified()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth);

            Assert.Multiple(() =>
            {
                Assert.That(bandit.Name, Is.EqualTo(BanditName));
                Assert.That(bandit.Health.Current, Is.EqualTo(BanditMaxHealth));
                Assert.That(bandit.Health.Max, Is.EqualTo(BanditMaxHealth));
                Assert.That(bandit.GoldCoins, Is.EqualTo(0));
            });
        }

        /// <summary>
        /// Test that constructor sets the gold coins to specified number.
        /// </summary>
        [Test]
        public void Test_Constructor_SetsGoldCoins_WhenGoldCoinsSpecified()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth, goldCoins: BanditGoldCoins);

            Assert.Multiple(() =>
            {
                Assert.That(bandit.Name, Is.EqualTo(BanditName));
                Assert.That(bandit.Health.Current, Is.EqualTo(BanditMaxHealth));
                Assert.That(bandit.Health.Max, Is.EqualTo(BanditMaxHealth));
                Assert.That(bandit.GoldCoins, Is.EqualTo(BanditGoldCoins));
            });
        }

        /// <summary>
        /// Test that constructor requires the number of gold coins to be positive.
        /// </summary>
        [Test]
        public void Test_Constructor_Throws_WhenGoldCoinsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Bandit(BanditName, BanditMaxHealth, goldCoins: -1));
        }

        /// <inheritdoc/>
        protected override Bandit CreateInstance()
        {
            return new(BanditName, BanditMaxHealth);
        }

        /// <inheritdoc/>
        protected override void ModifyInstance(Bandit instance)
        {
            instance.Health.Current -= 5;
            instance.GoldCoins += 50;
        }
    }
}
