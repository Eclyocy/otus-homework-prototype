using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// Health model.
    /// </summary>
    public class Health : IMyCloneable<Health>, IEquatable<Health>, ICloneable
    {
        private int _current;

        /// <summary>
        /// Maximum health level.
        /// </summary>
        public int Max { get; protected set; }

        /// <summary>
        /// Current health level.<br/>
        /// Cannot exceed <see cref="Max"/>.
        /// </summary>
        public int Current {
            get => _current;
            set
            {
                if (value > Max)
                {
                    _current = Max;
                    return;
                }

                if (value < 0)
                {
                    _current = 0;
                    return;
                }

                _current = value;
            }
        }

        public Health(int maximum)
        {
            Max = maximum;
            Current = maximum;
        }

        public Health(int maximum, int current)
        {
            Max = maximum;
            Current = current;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Current}/{Max}";
        }

        /// <inheritdoc/>
        public Health MyClone()
        {
            return new Health(Max, Current);
        }

        /// <inheritdoc/>
        public object Clone() => MyClone();

        /// <inheritdoc/>
        public bool Equals(Health? other)
        {
            return other != null &&
                other.Max == Max &&
                other.Current == Current;
        }
    }
}
