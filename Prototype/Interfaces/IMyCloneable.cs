namespace Prototype.Interfaces
{
    /// <summary>
    /// Supports cloning, which creates a new instance of a class
    /// with the same value as an existing instance.
    /// </summary>
    /// <typeparam name="T">Type of object to be cloneable.</typeparam>
    public interface IMyCloneable<T>
    {
        /// <summary>
        /// Creates a new object that is a deep copy of the current instance.
        /// </summary>
        /// <returns>A new object that is a deep copy of this instance.</returns>
        T MyClone();
    }
}
