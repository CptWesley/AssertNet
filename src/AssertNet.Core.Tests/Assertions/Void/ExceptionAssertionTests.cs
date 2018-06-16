using System;
using AssertNet.Core.Assertions.Void;
using AssertNet.Core.Failures;
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

        /// <summary>
        /// Checks that the assertion passes if the exception does not have an inner exception.
        /// </summary>
        [Fact]
        public void WithNoInnerExceptionPassTest()
        {
            new ExceptionAssertion(FailureHandler.Object, new Exception()).WithNoInnerException();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the exception has an inner exception.
        /// </summary>
        [Fact]
        public void WithNoInnerExceptionFailTest()
        {
            new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty, new Exception())).WithNoInnerException();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the exception does have an inner exception.
        /// </summary>
        [Fact]
        public void WithInnerExceptionPassTest()
        {
            Exception inner = new Exception();
            ExceptionAssertion assertion = new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty, inner)).WithInnerException();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
            Assert.Same(inner, assertion.Exception);
        }

        /// <summary>
        /// Checks that the assertion fails if the exception does not have an inner exception.
        /// </summary>
        [Fact]
        public void WithInnerExceptionFailTest()
        {
            ExceptionAssertion assertion = new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty)).WithInnerException();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(assertion);
        }

        /// <summary>
        /// Checks that the assertion passes if the exception does have an inner exception
        /// of the correct type.
        /// </summary>
        [Fact]
        public void WithInnerExceptionSpecificPassTest()
        {
            ArgumentException inner = new ArgumentException(string.Empty);
            ExceptionAssertion assertion = new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty, inner)).WithInnerException<ArgumentException>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
            Assert.Same(inner, assertion.Exception);
        }

        /// <summary>
        /// Checks that the assertion fails if the exception does not have an inner exception
        /// at all.
        /// </summary>
        [Fact]
        public void WithInnerExceptionSpecificNoneFailTest()
        {
            ExceptionAssertion assertion = new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty)).WithInnerException<ArgumentException>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(assertion);
        }

        /// <summary>
        /// Checks that the assertion fails if the exception does not have an inner exception
        /// of the correct type.
        /// </summary>
        [Fact]
        public void WithInnerExceptionSpecificWrongFailTest()
        {
            Exception inner = new Exception();
            ExceptionAssertion assertion = new ExceptionAssertion(
                FailureHandler.Object,
                new Exception(string.Empty, inner)).WithInnerException<ArgumentException>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(assertion);
        }
    }
}
