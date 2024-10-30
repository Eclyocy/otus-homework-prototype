using Prototype.Models;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Bandit"/>.
    /// </summary>
    [TestFixture]
    public class BanditTests
    {
        private const string BanditName = "Bob";
        private const int BanditMaxHealth = 30;
        private const int BanditGoldCoins = 15;

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

        [Test]
        public void Test_Constructor_Throws_WhenGoldCoinsNegative()
        {
            Assert.Throws<ArgumentOutOfRangeException>(
                () => new Bandit(BanditName, BanditMaxHealth, goldCoins: -1));
        }

        [Test]
        public void Test_MyClone_ClonedProperties()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth);

            Bandit clone = bandit.MyClone();

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(bandit));
                Assert.That(clone, Is.EqualTo(bandit));

                Assert.That(clone.Name, Is.EqualTo(bandit.Name));
                Assert.That(clone.GoldCoins, Is.EqualTo(bandit.GoldCoins));

                Assert.That(clone.Health, Is.Not.SameAs(bandit.Health));
                Assert.That(clone.Health, Is.EqualTo(bandit.Health));
            });
        }

        [Test]
        public void Test_MyClone_CopiesTrailingCurrentHealth_WhenOriginalIsChangedBeforeCloning()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth);
            bandit.Health.Current -= 5;

            Bandit clone = bandit.MyClone();

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(bandit));
                Assert.That(clone, Is.EqualTo(bandit));

                Assert.That(clone.Name, Is.EqualTo(bandit.Name));
                Assert.That(clone.GoldCoins, Is.EqualTo(bandit.GoldCoins));

                Assert.That(clone.Health, Is.Not.SameAs(bandit.Health));
                Assert.That(clone.Health, Is.EqualTo(bandit.Health));

                Assert.That(bandit.Health.Current, Is.EqualTo(BanditMaxHealth - 5));
                Assert.That(clone.Health.Current, Is.EqualTo(BanditMaxHealth - 5));
            });
        }

        [Test]
        public void Test_MyClone_CopiesStartingCurrentHealth_WhenOriginalIsChangedAfterCloning()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth);

            Bandit clone = bandit.MyClone();
            bandit.Health.Current -= 5;

            Assert.Multiple(() =>
            {
                Assert.That(clone, Is.Not.SameAs(bandit));
                Assert.That(clone, Is.Not.EqualTo(bandit));

                Assert.That(clone.Name, Is.EqualTo(bandit.Name));
                Assert.That(clone.GoldCoins, Is.EqualTo(bandit.GoldCoins));

                Assert.That(clone.Health, Is.Not.SameAs(bandit.Health));
                Assert.That(clone.Health, Is.Not.EqualTo(bandit.Health));

                Assert.That(bandit.Health.Current, Is.EqualTo(BanditMaxHealth - 5));
                Assert.That(clone.Health.Current, Is.EqualTo(BanditMaxHealth));
            });
        }

        [Test]
        public void Test_Clone_IsEqualToMyClone()
        {
            Bandit bandit = new(BanditName, BanditMaxHealth);

            Bandit clone = bandit.MyClone();
            object cloneObj = bandit.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(cloneObj, Is.Not.SameAs(clone));
                Assert.That(cloneObj, Is.EqualTo(clone));

                Assert.That(cloneObj is Creature);
            });
        }
    }
}
