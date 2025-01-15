﻿using System;
using AssertNet.Core.Failures;

namespace AssertNet.Core.AssertionTypes.Objects
{
    /// <summary>
    /// Class representing assertions made about doubles (and other numeric values).
    /// </summary>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    public class DoubleAssertion : ObjectAssertion<DoubleAssertion, double>
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
        /// Asserts if a double is greater than a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be greater than.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsGreaterThan(double other, string message = null)
        {
            if (Target <= other)
            {
                Fail(new FailureBuilder("IsGreaterThan()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than or equal to a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be greater than or equal to.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsGreaterThanOrEqualTo(double other, string message = null)
        {
            if (Target < other)
            {
                Fail(new FailureBuilder("IsGreaterThanOrEqualTo()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than or equal to", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is lesser than a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be lesser than.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsLesserThan(double other, string message = null)
        {
            if (Target >= other)
            {
                Fail(new FailureBuilder("IsLesserThan()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is lesser than or equal to a certain value.
        /// </summary>
        /// <param name="other">Value which the double should be lesser than or equal to.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsLesserThanOrEqualTo(double other, string message = null)
        {
            if (Target > other)
            {
                Fail(new FailureBuilder("IsLesserThanOrEqualTo()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than or equal to", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is equal to zero.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsZero(string message = null)
        {
            if (Target != 0)
            {
                Fail(new FailureBuilder("IsZero()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be equal to", 0)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than zero.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsPositive(string message = null)
        {
            if (Target <= 0)
            {
                Fail(new FailureBuilder("IsPositive()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than", 0)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than or equal to zero.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsPositiveOrZero(string message = null)
        {
            if (Target < 0)
            {
                Fail(new FailureBuilder("IsPositiveOrZero()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than or equal to", 0)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than zero.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNegative(string message = null)
        {
            if (Target >= 0)
            {
                Fail(new FailureBuilder("IsNegative()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than", 0)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is greater than or equal to zero.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNegativeOrZero(string message = null)
        {
            if (Target > 0)
            {
                Fail(new FailureBuilder("IsNegativeOrZero()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than or equal to", 0)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is within a certain range.
        /// </summary>
        /// <param name="minimum">Lower bound of the range the value should be in.</param>
        /// <param name="maximum">Upper bound of the range the value should be in.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        /// <exception cref="ArgumentException">Thrown if the maximum is larger or equal to the minimum.</exception>
        public DoubleAssertion IsInRange(double minimum, double maximum, string message = null)
        {
            if (maximum <= minimum)
            {
                throw new ArgumentException($"Value for 'minimum' ({minimum}) should be lower than the value for 'maximum' ({maximum}).");
            }

            if (Target < minimum || Target > maximum)
            {
                Fail(new FailureBuilder("IsInRange()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than or equal to", minimum)
                    .Append("And lesser than or equal to", maximum)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a double is outside a certain range.
        /// </summary>
        /// <param name="minimum">Lower bound of the range the value may not be in.</param>
        /// <param name="maximum">Upper bound of the range the value may not be in.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        /// <exception cref="ArgumentException">Thrown if the maximum is larger or equal to the minimum.</exception>
        public DoubleAssertion IsNotInRange(double minimum, double maximum, string message = null)
        {
            if (maximum <= minimum)
            {
                throw new ArgumentException($"Value for 'minimum' ({minimum}) should be lower than the value for 'maximum' ({maximum}).");
            }

            if (Target >= minimum && Target <= maximum)
            {
                Fail(new FailureBuilder("IsNotInRange()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than", minimum)
                    .Append("Or greater than", maximum)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks whether the double under test is equal to another double.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsEqualTo(double other, string message = null) => base.IsEqualTo(other, message);

        /// <summary>
        /// Checks whether the double under test is equal to another double within a certain margin.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <param name="margin">The margin to still identify another double as equal.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsEqualTo(double other, double margin, string message = null)
        {
            if (Target < other - margin || Target > other + margin)
            {
                Fail(new FailureBuilder("IsEqualTo()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be greater than or equal to", other - margin)
                    .Append("And lesser than or equal to", other + margin)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks whether the double under test is not equal to another double.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNotEqualTo(double other, string message = null) => base.IsNotEqualTo(other, message);

        /// <summary>
        /// Checks whether the double under test is not equal to another double within a certain margin.
        /// </summary>
        /// <param name="other">The other double to compare with.</param>
        /// <param name="margin">The margin to still identify another double as equal.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public DoubleAssertion IsNotEqualTo(double other, double margin, string message = null)
        {
            if (Target >= other - margin && Target <= other + margin)
            {
                Fail(new FailureBuilder("IsNotEqualTo()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be lesser than", other - margin)
                    .Append("Or greater than", other + margin)
                    .Finish());
            }

            return this;
        }
    }
}
