﻿using Prototype.Interfaces;

namespace Prototype.Models
{
    /// <summary>
    /// Health model.
    /// </summary>
    public class Health : IMyCloneable<Health>, IEquatable<Health>, ICloneable
    {
        private int _maximum;
        private int _current;

        /// <summary>
        /// Initializes a new instance of the <see cref="Health"/> class.<br/>
        /// Current health is set as <paramref name="maximum"/>.
        /// </summary>
        /// <param name="maximum">Both maximum and current health points.</param>
        public Health(int maximum)
        {
            Max = maximum;
            Current = maximum;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Health"/> class.
        /// </summary>
        /// <param name="maximum">Maximum health points.</param>
        /// <param name="current">Current health points.</param>
        public Health(int maximum, int current)
        {
            Max = maximum;
            Current = current;
        }

        /// <summary>
        /// Gets or sets the maximum health level.
        /// </summary>
        /// <remarks>
        /// Must be at least 1.
        /// </remarks>
        public int Max
        {
            get => _maximum;
            protected set
            {
                ArgumentOutOfRangeException.ThrowIfLessThan(value, 1, nameof(Max));

                _maximum = value;
            }
        }

        /// <summary>
        /// Gets or sets the current health level.
        /// </summary>
        /// <remarks>
        /// Cannot exceed <see cref="Max"/>. Autocapped.
        /// </remarks>
        public int Current
        {
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

        /// <inheritdoc/>
        public Health MyClone()
        {
            return new Health(Max, Current);
        }

        /// <inheritdoc/>
        public object Clone() => MyClone();

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{Current}/{Max}";
        }

        /// <inheritdoc/>
        public bool Equals(Health? other)
        {
            return other != null &&
                other.Max == Max &&
                other.Current == Current;
        }

        /// <inheritdoc/>
        public override bool Equals(object? obj)
        {
            return Equals(obj as Health);
        }

        /// <inheritdoc/>
        public override int GetHashCode()
        {
            return HashCode.Combine(Max, Current);
        }
    }
}
