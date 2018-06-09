using System;
using AssertNet.Core.Assertions.Void;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Void
{
    /// <summary>
    /// Test class for the <see cref="ExceptionAssertion"/> class.
    /// </summary>
    public class ExceptionAssertionTests
    {
        private readonly Mock<IFailureHandler> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertionTests"/> class.
        /// </summary>
        public ExceptionAssertionTests()
        {
            _handler = new Mock<IFailureHandler>();
        }

        /// <summary>
        /// Checks that the constructor functions properly.
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Exception e = new Mock<Exception>().Object;
            ExceptionAssertion assertion = new ExceptionAssertion(_handler.Object, e);
            Assert.Same(_handler.Object, assertion.FailureHandler);
            Assert.Same(e, assertion.Exception);
        }

        /// <summary>
        /// Checks that the assertion passes if the exception has the correct message.
        /// </summary>
        [Fact]
        public void WithMessagePassTest()
        {
            string msg = "t2fdres4";
            new ExceptionAssertion(_handler.Object, new Exception(msg)).WithMessage(msg);
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the exception has the wrong message.
        /// </summary>
        [Fact]
        public void WithMessageFailTest()
        {
            string msg = "4356543rf";
            new ExceptionAssertion(_handler.Object, new Exception()).WithMessage(msg);
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the exception contains the message.
        /// </summary>
        [Fact]
        public void WithMessageContainingPassTest()
        {
            new ExceptionAssertion(_handler.Object, new Exception("abcd")).WithMessageContaining("c");
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the exception does not contain the message.
        /// </summary>
        [Fact]
        public void WithMessageContainingFailTest()
        {
            new ExceptionAssertion(_handler.Object, new Exception("b")).WithMessageContaining("a");
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
