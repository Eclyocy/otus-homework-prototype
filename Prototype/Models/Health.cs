namespace Prototype.Models
{
    /// <summary>
    /// Health model.
    /// </summary>
    public class Health
    {
        private byte _current;

        /// <summary>
        /// Maximum health level.
        /// </summary>
        public byte Max { get; set; }

        /// <summary>
        /// Current health level.<br/>
        /// Cannot exceed <see cref="Max"/>.
        /// </summary>
        public byte Current {
            get => _current;
            set
            {
                if (value > Max)
                {
                    _current = Max;
                    return;
                }

                _current = value;
            }
        }

        public Health()
        {
            Max = 10;
            Current = 10;
        }

        public override string ToString()
        {
            return $"{Current}/{Max}";
        }
    }
}
