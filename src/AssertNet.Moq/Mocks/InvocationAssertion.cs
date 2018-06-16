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
        public abstract void Never();

        /// <summary>
        /// Asserts that the expression was invoked once.
        /// </summary>
        public abstract void Once();

        /// <summary>
        /// Asserts that the expression was invoked at least once.
        /// </summary>
        public abstract void AtLeastOnce();

        /// <summary>
        /// Asserts that the expression was invoked at most once.
        /// </summary>
        public abstract void AtMostOnce();

        /// <summary>
        /// Asserts that the expression was invoked at least the given amount of times.
        /// </summary>
        /// <param name="count">The minimum amount of invocations.</param>
        public abstract void AtLeast(int count);

        /// <summary>
        /// Asserts that the expression was invoked at most the given amount of times.
        /// </summary>
        /// <param name="count">The maximum amount of invocations.</param>
        public abstract void AtMost(int count);

        /// <summary>
        /// Asserts that the expression was invoked exactly the given amount of times.
        /// </summary>
        /// <param name="count">The exact amount of invocations.</param>
        public abstract void Exactly(int count);

        /// <summary>
        /// Asserts that the expression was invoked a number of times in a certain range.
        /// </summary>
        /// <param name="minimum">The minimum amount of invocations.</param>
        /// <param name="maximum">The maximum amount of invocations.</param>
        public abstract void Between(int minimum, int maximum);
    }
}
