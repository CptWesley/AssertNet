using Moq;
using Xunit;

namespace AssertNet.Core.Tests
{
    /// <summary>
    /// Test class for the <see cref="ObjectAssertion{T}"/> class.
    /// </summary>
    public abstract class ObjectAssertionTests<T>
        where T : ObjectAssertion<T>
    {
        /// <summary>
        /// Gets or sets the assertion under test.
        /// </summary>
        /// <value>
        /// The assertion under test.
        /// </value>
        protected ObjectAssertion<T> Assertion { get; set; }

        /// <summary>
        /// Gets or sets the failure handler.
        /// </summary>
        /// <value>
        /// The failure handler.
        /// </value>
        protected Mock<IFailureHandler> FailureHandler { get; set; }

        /// <summary>
        /// Checks that there are no failures if the objects are equal.
        /// </summary>
        [Fact]
        public void IsEqualToTrueTest()
        {
            Assertion.IsEqualTo(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are not equal.
        /// </summary>
        [Fact]
        public void IsEqualToFalseTest()
        {
            Assertion.IsEqualTo(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
