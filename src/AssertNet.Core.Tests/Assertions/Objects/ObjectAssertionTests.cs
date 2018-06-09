using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="ObjectAssertion{T}"/> class.
    /// </summary>
    /// <typeparam name="T">Type of the assertion.</typeparam>
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


        /// <summary>
        /// Checks that there are no failures if the objects are not equal.
        /// </summary>
        [Fact]
        public void IsNotEqualToTrueTest()
        {
            Assertion.IsNotEqualTo(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are equal.
        /// </summary>
        [Fact]
        public void IsNotEqualToFalseTest()
        {
            Assertion.IsNotEqualTo(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the objects are the same.
        /// </summary>
        [Fact]
        public void IsSameAsTrueTest()
        {
            Assertion.IsSameAs(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are not the same.
        /// </summary>
        [Fact]
        public void IsSameAsFalseTest()
        {
            Assertion.IsSameAs(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the objects are not the same.
        /// </summary>
        [Fact]
        public void IsNotSameAsTrueTest()
        {
            Assertion.IsNotSameAs(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are the same.
        /// </summary>
        [Fact]
        public void IsNotSameAsFalseTest()
        {
            Assertion.IsNotSameAs(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the object is correctly not null.
        /// </summary>
        [Fact]
        public void IsNotNullPassTest()
        {
            Assertion.IsNotNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the object is incorrectly not null.
        /// </summary>
        [Fact]
        public void IsNullFailTest()
        {
            Assertion.IsNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
