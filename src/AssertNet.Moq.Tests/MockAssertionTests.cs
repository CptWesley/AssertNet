using System;
using Moq;

namespace AssertNet.Moq.Tests
{
    /// <summary>
    /// Test class for the <see cref="MockAssertion{T}"/> class.
    /// </summary>
    public class MockAssertionTests
    {
        private readonly MockAssertion<Exception> _assertion;
        private readonly Mock<Exception> _target;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertionTests"/> class.
        /// </summary>
        public MockAssertionTests()
        {
            _target = new Mock<Exception>();
            _assertion = new MockAssertion<Exception>(_target);
        }
    }
}
