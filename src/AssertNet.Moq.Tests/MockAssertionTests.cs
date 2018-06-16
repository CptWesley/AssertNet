using System;
using AssertNet.Core.Failures;
using Moq;

namespace AssertNet.Moq.Tests
{
    /// <summary>
    /// Test class for the <see cref="MockAssertion{T}"/> class.
    /// </summary>
    public class MockAssertionTests
    {
        private readonly MockAssertion<Exception> _assertion;
        private readonly Mock<IFailureHandler> _failureHandler;
        private readonly Mock<Exception> _target;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertionTests"/> class.
        /// </summary>
        public MockAssertionTests()
        {
            _target = new Mock<Exception>();
            _failureHandler = new Mock<IFailureHandler>();
            _assertion = new MockAssertion<Exception>(_failureHandler.Object, _target);
        }
    }
}
