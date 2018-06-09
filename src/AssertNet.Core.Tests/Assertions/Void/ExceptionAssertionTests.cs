using System;
using AssertNet.Core.Assertions.Void;
using AssertNet.Core.FailureHandlers;
using AssertNet.Core.Tests.Assertions.Objects;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Void
{
    /// <summary>
    /// Test class for the <see cref="ExceptionAssertion"/> class.
    /// </summary>
    public class ExceptionAssertionTests : ObjectAssertionTests<ExceptionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertionTests"/> class.
        /// </summary>
        public ExceptionAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new ExceptionAssertion(FailureHandler.Object, new Exception());
        }

        /// <summary>
        /// Checks that the constructor functions properly.
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Exception e = new Mock<Exception>().Object;
            ExceptionAssertion assertion = new ExceptionAssertion(FailureHandler.Object, e);
            Assert.Same(FailureHandler.Object, assertion.FailureHandler);
            Assert.Same(e, assertion.Exception);
        }

        /// <summary>
        /// Checks that the assertion passes if the exception has the correct message.
        /// </summary>
        [Fact]
        public void WithMessagePassTest()
        {
            string msg = "t2fdres4";
            new ExceptionAssertion(FailureHandler.Object, new Exception(msg)).WithMessage(msg);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the exception has the wrong message.
        /// </summary>
        [Fact]
        public void WithMessageFailTest()
        {
            string msg = "4356543rf";
            new ExceptionAssertion(FailureHandler.Object, new Exception()).WithMessage(msg);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the exception contains the message.
        /// </summary>
        [Fact]
        public void WithMessageContainingPassTest()
        {
            new ExceptionAssertion(FailureHandler.Object, new Exception("abcd")).WithMessageContaining("c");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the exception does not contain the message.
        /// </summary>
        [Fact]
        public void WithMessageContainingFailTest()
        {
            new ExceptionAssertion(FailureHandler.Object, new Exception("b")).WithMessageContaining("a");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
