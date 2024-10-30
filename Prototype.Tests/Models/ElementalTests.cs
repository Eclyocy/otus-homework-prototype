using Prototype.Enums;
using Prototype.Models;
using Prototype.Tests.Interfaces;

namespace Prototype.Tests.Models
{
    /// <summary>
    /// Tests for <see cref="Elemental"/>.
    /// </summary>
    public class ElementalTests : MyCloneableTestBase<Elemental>
    {
        /// <inheritdoc/>
        protected override Elemental CreateInstance()
        {
            return new(Element.Water, 35);
        }

        /// <inheritdoc/>
        protected override void ModifyInstance(Elemental instance)
        {
            instance.Health.Current -= 14;
        }
    }
}
