using System;
using System.Collections.Generic;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.Assertions.Void;

namespace AssertNet.NUnit
{
    /// <summary>
    /// Static assertion class for the NUnit framework.
    /// </summary>
    public static class Assertions
    {
        /// <summary>
        /// Makes an assertion about a void action.
        /// </summary>
        /// <param name="action">Void action under test.</param>
        /// <returns>Assertion about a void action.</returns>
        public static VoidAssertion AssertThat(Action action)
        {
            return new VoidAssertion(new NUnitFailureHandler(), action);
        }

        /// <summary>
        /// Makes an assertion about an exception.
        /// </summary>
        /// <param name="exception">Exception under test.</param>
        /// <returns>Assertion about an exception.</returns>
        public static ExceptionAssertion AssertThat(Exception exception)
        {
            return new ExceptionAssertion(new NUnitFailureHandler(), exception);
        }

        /// <summary>
        /// Makes an assertion about a boolean value.
        /// </summary>
        /// <param name="value">Boolean value under test.</param>
        /// <returns>Assertion about a boolean value.</returns>
        public static BooleanAssertion AssertThat(bool value)
        {
            return new BooleanAssertion(new NUnitFailureHandler(), value);
        }

        /// <summary>
        /// Makes an assertion about a numeric value.
        /// </summary>
        /// <param name="value">Numeric value under test.</param>
        /// <returns>Assertion about a numeric value.</returns>
        public static DoubleAssertion AssertThat(double value)
        {
            return new DoubleAssertion(new NUnitFailureHandler(), value);
        }

        /// <summary>
        /// Makes an assertion about a string.
        /// </summary>
        /// <param name="value">String under test.</param>
        /// <returns>Assertion about a string.</returns>
        public static StringAssertion AssertThat(string value)
        {
            return new StringAssertion(new NUnitFailureHandler(), value);
        }

        /// <summary>
        /// Makes an assertion about an enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <param name="enumerable">Enumerable under test.</param>
        /// <returns>Assertion about an enumerable.</returns>
        public static EnumerableAssertion<T> AssertThat<T>(params T[] enumerable) => AssertThat((IEnumerable<T>)enumerable);

        /// <summary>
        /// Makes an assertion about an enumerable.
        /// </summary>
        /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
        /// <param name="enumerable">Enumerable under test.</param>
        /// <returns>Assertion about an enumerable.</returns>
        public static EnumerableAssertion<T> AssertThat<T>(IEnumerable<T> enumerable)
        {
            return new EnumerableAssertion<T>(new NUnitFailureHandler(), enumerable);
        }

        /// <summary>
        /// Makes an assertion about an object.
        /// </summary>
        /// <param name="value">Object under test.</param>
        /// <returns>Assertion about an object.</returns>
        public static SingleAssertion AssertThat(object value)
        {
            return new SingleAssertion(new NUnitFailureHandler(), value);
        }
    }
}
