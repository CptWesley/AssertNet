using AssertNet.Core.FailureHandlers;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made about doubles (and other numeric values).
    /// </summary>
    /// <seealso cref="ObjectAssertion{DoubleAssertion}" />
    public class DoubleAssertion : ObjectAssertion<DoubleAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public DoubleAssertion(IFailureHandler failureHandler, double target)
            : base(failureHandler, target)
        {
        }

        /// <summary>
        /// Gets the double under test.
        /// </summary>
        /// <value>
        /// The double under test.
        /// </value>
        public double Value => (double)Target;

        /// <summary>
        /// Asserts if a double is greater than a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be greater than.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsGreaterThan(double other)
        {
            if (Value <= other)
            {
                Fail($"Expected '{Value}' to be greater than '{other}'.");
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than or equal to a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be greater than or equal to.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsGreaterThanOrEqual(double other)
        {
            if (Value < other)
            {
                Fail($"Expected '{Value}' to be greater than or equal to '{other}'.");
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is lesser than a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be lesser than.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsLesserThan(double other)
        {
            if (Value >= other)
            {
                Fail($"Expected '{Value}' to be lesser than '{other}'.");
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is lesser than or equal to a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be lesser than or equal to.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsLesserThanOrEqual(double other)
        {
            if (Value > other)
            {
                Fail($"Expected '{Value}' to be lesser than or equal to '{other}'.");
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is equal to zero.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsZero() => IsEqualTo(0);

        /// <summary>
        /// Asserts if a double is greater than zero.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsPositive() => IsGreaterThan(0);

        /// <summary>
        /// Asserts if a double is greater than or equal to zero.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsPositiveOrZero() => IsGreaterThanOrEqual(0);

        /// <summary>
        /// Asserts if a double is greater than zero.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNegative() => IsLesserThan(0);

        /// <summary>
        /// Asserts if a double is greater than or equal to zero.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNegativeOrZero() => IsLesserThanOrEqual(0);

        /// <summary>
        /// Checks whether the double under test is equal to another double.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <returns>
        /// The current assertion.
        /// </returns>
        public DoubleAssertion IsEqualTo(double other) => base.IsEqualTo(other);

        /// <summary>
        /// Checks whether the double under test is not equal to another double.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNotEqualTo(double other) => base.IsNotEqualTo(other);
    }
}
