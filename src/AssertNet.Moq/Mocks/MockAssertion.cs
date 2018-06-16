using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about mocks.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    public class MockAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        public MockAssertion(Mock<T> target)
        {
            Target = target;
        }

        /// <summary>
        /// Gets the mock under test.
        /// </summary>
        /// <value>
        /// The mock under test.
        /// </value>
        public Mock<T> Target { get; }
    }
}
