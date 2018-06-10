using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="DoubleAssertion"/> class.
    /// </summary>
    /// <seealso cref="ObjectAssertionTests{DoubleAssertion}" />
    public class DoubleAssertionTests : ObjectAssertionTests<DoubleAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DoubleAssertionTests"/> class.
        /// </summary>
        public DoubleAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new DoubleAssertion(FailureHandler.Object, 500);
        }

        /// <summary>
        /// Checks that the assertion passes if the value is greater than a certain value.
        /// </summary>
        [Fact]
        public void IsGreaterThanPassTest()
        {
            new DoubleAssertion(FailureHandler.Object, 20).IsGreaterThan(10);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value is not greater than a certain value.
        /// </summary>
        [Fact]
        public void IsGreaterThanFailTest()
        {
            new DoubleAssertion(FailureHandler.Object, 15).IsGreaterThan(15);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is greater than or equal to a certain value.
        /// </summary>
        [Fact]
        public void IsGreaterThanOrEqualPassTest()
        {
            new DoubleAssertion(FailureHandler.Object, 32).IsGreaterThanOrEqual(32);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value is not greater than or equal to a certain value.
        /// </summary>
        [Fact]
        public void IsGreaterThanOrEqualFailTest()
        {
            new DoubleAssertion(FailureHandler.Object, 2).IsGreaterThanOrEqual(23);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is lesser than a certain value.
        /// </summary>
        [Fact]
        public void IsLesserThanPassTest()
        {
            new DoubleAssertion(FailureHandler.Object, 12).IsLesserThan(13);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value is not lesser than a certain value.
        /// </summary>
        [Fact]
        public void IsLesserThanFailTest()
        {
            new DoubleAssertion(FailureHandler.Object, 25).IsLesserThan(10);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is lesser than or equal to a certain value.
        /// </summary>
        [Fact]
        public void IsLesserThanOrEqualPassTest()
        {
            new DoubleAssertion(FailureHandler.Object, 2).IsLesserThanOrEqual(2);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value is not lesser than or equal to a certain value.
        /// </summary>
        [Fact]
        public void IsLesserThanOrEqualFailTest()
        {
            new DoubleAssertion(FailureHandler.Object, 2).IsLesserThanOrEqual(0);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
