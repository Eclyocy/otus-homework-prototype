using Prototype.Models;
using Prototype.Tests.Interfaces;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="BanditArcher"/>.
    /// </summary>
    [TestFixture]
    public class BanditArcherTests : MyCloneableTestBase<BanditArcher>
    {
        /// <inheritdoc/>
        protected override BanditArcher CreateInstance()
        {
            return new("Paul the Archer", 10);
        }

        /// <inheritdoc/>
        protected override void ModifyInstance(BanditArcher instance)
        {
            instance.Health.Current -= 3;
            instance.GoldCoins += 13;
        }
    }
}
