using AssertNet.Moq.Mocks;
using Moq;

namespace AssertNet.Moq.Tests.Mocks
{
    /// <summary>
    /// Test class for the <see cref="MockAssertion{T}"/> class.
    /// </summary>
    public class MockAssertionTests
    {
        private readonly MockAssertion<object> _assertion;
        private readonly Mock<object> _target;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertionTests"/> class.
        /// </summary>
        public MockAssertionTests()
        {
            _target = new Mock<object>();
            _assertion = new MockAssertion<object>(_target);
        }
    }
}
