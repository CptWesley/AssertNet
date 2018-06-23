using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about method invocations.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    public abstract class InvocationAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvocationAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        public InvocationAssertion(Mock<T> target) => Target = target;

        /// <summary>
        /// Gets the mock under test.
        /// </summary>
        /// <value>
        /// The mock under test.
        /// </value>
        public Mock<T> Target { get; }

        /// <summary>
        /// Asserts that the expression was never invoked.
        /// </summary>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> Never();

        /// <summary>
        /// Asserts that the expression was invoked once.
        /// </summary>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> Once();

        /// <summary>
        /// Asserts that the expression was invoked at least once.
        /// </summary>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> AtLeastOnce();

        /// <summary>
        /// Asserts that the expression was invoked at most once.
        /// </summary>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> AtMostOnce();

        /// <summary>
        /// Asserts that the expression was invoked at least the given amount of times.
        /// </summary>
        /// <param name="count">The minimum amount of invocations.</param>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> AtLeast(int count);

        /// <summary>
        /// Asserts that the expression was invoked at most the given amount of times.
        /// </summary>
        /// <param name="count">The maximum amount of invocations.</param>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> AtMost(int count);

        /// <summary>
        /// Asserts that the expression was invoked exactly the given amount of times.
        /// </summary>
        /// <param name="count">The exact amount of invocations.</param>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> Exactly(int count);

        /// <summary>
        /// Asserts that the expression was invoked a number of times in a certain range.
        /// </summary>
        /// <param name="minimum">The minimum amount of invocations.</param>
        /// <param name="maximum">The maximum amount of invocations.</param>
        /// <returns>An assertion on the mock we were making an assertion about.</returns>
        public abstract MockAssertion<T> Between(int minimum, int maximum);
    }
}
