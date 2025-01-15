using AssertNet.Core.Helpers;

namespace AssertNet.Core.Tests.Helpers;

/// <summary>
/// Dummy class holder for testing purposes.
/// </summary>
internal static class DummyClasses
{
    /// <summary>
    /// Class containing circular reference for testing purposes.
    /// </summary>
    internal class CircularClass
    {
        /// <summary>
        /// Gets or sets the reference.
        /// </summary>
        /// <value>
        /// The reference.
        /// </value>
        public CircularClass? Reference { get; set; }
    }

    /// <summary>
    /// Class allowing inheritance.
    /// </summary>
    internal class FatherClass
    {
        /// <summary>
        /// Gets or sets the public value.
        /// </summary>
        [SuppressMessage("Design", "CA1051", Justification = "Needed for testing.")]
        [SuppressMessage("MaintainabilityRules", "SA1401", Justification = "Needed for testing.")]
        public int PublicValue;

        /// <summary>
        /// Gets or sets the private value.
        /// </summary>
        private int privateValue;

        /// <summary>
        /// Sets the private value.
        /// </summary>
        /// <param name="value">The value.</param>
        public void SetPrivateValue(int value)
            => privateValue = value;

        /// <summary>
        /// Gets the private value.
        /// </summary>
        /// <returns>The private value.</returns>
        [SuppressMessage("Design", "CA1024", Justification = "Needed for testing.")]
        public int GetPrivateValue()
            => privateValue;
    }

    /// <summary>
    /// Class inheriting from something else.
    /// </summary>
    internal class SonClass : FatherClass
    {
        /// <summary>
        /// Gets or sets the son value.
        /// </summary>
        public int SonValue { get; set; }
    }

    /// <summary>
    /// Some struct.
    /// </summary>
    [SuppressMessage("Performance", "CA1815", Justification = "Not needed for testing.")]
    [SuppressMessage("OrderingRules", "SA1201", Justification = "Not needed for testing.")]
    internal struct SomeStruct
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Gets or sets the random.
        /// </summary>
        public Random Random { get; set; }
    }

    /// <summary>
    /// Class which overrides equals and hashcode with internal stuff.
    /// </summary>
    internal class OverriddenClass
    {
        /// <summary>
        /// Gets or sets the value.
        /// </summary>
        public int Value { get; set; }

        /// <summary>
        /// Determines whether the specified <see cref="object" />, is equal to this instance.
        /// </summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.
        /// </returns>
        public override bool Equals(object obj)
            => EquivalencyHelper.AreEquivalent(this, obj);

        /// <summary>
        /// Returns a hash code for this instance.
        /// </summary>
        /// <returns>
        /// A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.
        /// </returns>
        public override int GetHashCode()
            => base.GetHashCode();
    }
}
