using System;
using AssertNet.Core.Assertions.Void;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Void
{
    /// <summary>
    /// Test class for the <see cref="VoidAssertion"/> class.
    /// </summary>
    public class VoidAssertionTests
    {
        private readonly Mock<IFailureHandler> _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoidAssertionTests"/> class.
        /// </summary>
        public VoidAssertionTests()
        {
            _handler = new Mock<IFailureHandler>();
        }

        /// <summary>
        /// Checks that the constructor functions properly.
        /// </summary>
        [Fact]
        public void ConstructorTest()
        {
            Action action = new Mock<Action>().Object;
            VoidAssertion assertion = new VoidAssertion(_handler.Object, action);
            Assert.Same(_handler.Object, assertion.FailureHandler);
        }

        /// <summary>
        /// Checks that whenever a method does not throw an exception the condition passes.
        /// </summary>
        [Fact]
        public void DoesNotThrowExceptionPassTest()
        {
            new VoidAssertion(_handler.Object, DoNothing).DoesNotThrowException();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that whenever a method throws an exception the condition fails.
        /// </summary>
        [Fact]
        public void DoesNotThrowExceptionFailTest()
        {
            new VoidAssertion(_handler.Object, () => throw new Exception()).DoesNotThrowException();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that whenever a method does not throw an exception the condition passes.
        /// </summary>
        [Fact]
        public void DoesNotThrowExceptionTypedAnyPassTest()
        {
            new VoidAssertion(_handler.Object, DoNothing).DoesNotThrowException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that whenever a method does not throw the specific exception the condition passes.
        /// </summary>
        [Fact]
        public void DoesNotThrowExceptionTypedPassTest()
        {
            new VoidAssertion(_handler.Object, () => throw new Exception()).DoesNotThrowException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that whenever a method throws the specific exception the condition fails.
        /// </summary>
        [Fact]
        public void DoesNotThrowExceptionTypedFailTest()
        {
            new VoidAssertion(
                _handler.Object,
                () => throw new ArgumentException(string.Empty)).DoesNotThrowException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the condition passes whenever an exception is thrown.
        /// </summary>
        [Fact]
        public void ThrowsAnyExceptionPassTest()
        {
            ExceptionAssertion result = new VoidAssertion(_handler.Object, () => throw new Exception()).ThrowsException();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
            Assert.NotNull(result);
        }

        /// <summary>
        /// Checks that the condition fails whenever no exception is thrown.
        /// </summary>
        [Fact]
        public void ThrowsAnyExceptionFailTest()
        {
            ExceptionAssertion result = new VoidAssertion(_handler.Object, DoNothing).ThrowsException();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(result);
        }

        /// <summary>
        /// Checks that the condition passes whenever the specific exception is thrown.
        /// </summary>
        [Fact]
        public void ThrowsSpecificExceptionPassTest()
        {
            ExceptionAssertion result = new VoidAssertion(
                _handler.Object,
                () => throw new ArgumentException(string.Empty)).ThrowsException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
            Assert.NotNull(result);
        }

        /// <summary>
        /// Checks that the condition fails whenever no exception is thrown.
        /// </summary>
        [Fact]
        public void ThrowsSpecificExceptionWrongFailTest()
        {
            ExceptionAssertion result = new VoidAssertion(
                _handler.Object,
                () => throw new Exception()).ThrowsException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(result);
        }

        /// <summary>
        /// Checks that the condition fails whenever no exception is thrown.
        /// </summary>
        [Fact]
        public void ThrowsSpecificExceptionFailTest()
        {
            ExceptionAssertion result = new VoidAssertion(_handler.Object, DoNothing).ThrowsException<ArgumentException>();
            _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
            Assert.Null(result);
        }

        /// <summary>
        /// Do Nothing.
        /// </summary>
        private static void DoNothing()
        {
        }
    }
}
