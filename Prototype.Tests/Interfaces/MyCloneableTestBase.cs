using Prototype.Interfaces;

namespace Prototype.Tests.Interfaces
{
    /// <summary>
    /// Base tests for an instance of a class that implements
    /// both <see cref="IMyCloneable{T}"/> and <see cref="ICloneable"/>.
    /// </summary>
    /// <typeparam name="T">Tested instance type.</typeparam>
    public abstract class MyCloneableTestBase<T>
        where T : class, IMyCloneable<T>, IEquatable<T>, ICloneable
    {
        /// <summary>
        /// Test that <see cref="IMyCloneable{T}.MyClone"/> creates
        /// a new instance, not a reference.
        /// </summary>
        [Test]
        public void Test_MyClone_CreatesNewInstance()
        {
            T original = CreateInstance();

            T clone = original.MyClone();

            Assert.That(clone, Is.Not.SameAs(original));
        }

        /// <summary>
        /// Test that <see cref="IMyCloneable{T}.MyClone"/> creates
        /// an instance that is equal to the original one.
        /// </summary>
        [Test]
        public void Test_MyClone_CreatesEqualInstance()
        {
            T original = CreateInstance();

            T clone = original.MyClone();

            Assert.That(clone, Is.EqualTo(original));
        }

        /// <summary>
        /// Test that <see cref="IMyCloneable{T}.MyClone"/> creates
        /// an instance that is not affected by the changes to the original.
        /// </summary>
        [Test]
        public void Test_MyClone_IsNotAffectedByChangesToOriginal()
        {
            T original = CreateInstance();

            T clone = original.MyClone();
            ModifyInstance(original);

            Assert.That(clone, Is.Not.EqualTo(original));
        }

        /// <summary>
        /// Test that <see cref="ICloneable.Clone"/> creates
        /// an object that is convertible to the <typeparamref name="T"/>.
        /// </summary>
        [Test]
        public void Test_Clone_IsEqualToMyClone()
        {
            T original = CreateInstance();

            T myClone = original.MyClone();
            object cloneObj = original.Clone();

            Assert.Multiple(() =>
            {
                Assert.That(cloneObj, Is.Not.SameAs(myClone));
                Assert.That(cloneObj, Is.EqualTo(myClone));

                Assert.That(cloneObj, Is.InstanceOf<T>());
            });
        }

        /// <summary>
        /// Creates an instance of <typeparamref name="T"/>.
        /// </summary>
        /// <returns>Created instance.</returns>
        protected abstract T CreateInstance();

        /// <summary>
        /// Modifies the existing instance.
        /// </summary>
        /// <param name="instance">Instance to be modified.</param>
        protected abstract void ModifyInstance(T instance);
    }
}
