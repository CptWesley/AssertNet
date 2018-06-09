using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="BooleanAssertion"/> class.
    /// </summary>
    /// <seealso cref="ObjectAssertionTests{BooleanAssertion}" />
    public class BooleanAssertionTests : ObjectAssertionTests<BooleanAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanAssertionTests"/> class.
        /// </summary>
        public BooleanAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new BooleanAssertion(FailureHandler.Object, true);
        }

        /// <summary>
        /// Checks that the assertion passes if the value is correctly true.
        /// </summary>
        [Fact]
        public void IsTruePassTest()
        {
            new BooleanAssertion(FailureHandler.Object, true).IsTrue();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is incorrectly false.
        /// </summary>
        [Fact]
        public void IsTrueFailTest()
        {
            new BooleanAssertion(FailureHandler.Object, false).IsTrue();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is correctly false.
        /// </summary>
        [Fact]
        public void IsFalsePassTest()
        {
            new BooleanAssertion(FailureHandler.Object, false).IsFalse();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion passes if the value is incorrectly true.
        /// </summary>
        [Fact]
        public void IsFalseFailTest()
        {
            new BooleanAssertion(FailureHandler.Object, true).IsFalse();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
