using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="CollectionAssertion"/> class.
    /// </summary>
    public class CollectionAssertionTests : ObjectAssertionTests<CollectionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertionTests"/> class.
        /// </summary>
        public CollectionAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            CollectionAssertion = new CollectionAssertion(FailureHandler.Object, new int[] { 1, 2, 3 });
            Assertion = CollectionAssertion;
        }

        /// <summary>
        /// Gets the assertion under test.
        /// </summary>
        private CollectionAssertion CollectionAssertion { get; }

        /// <summary>
        /// Checks that the assertion does not fail if the object is correctly contained.
        /// </summary>
        [Fact]
        public void ContainsPassTest()
        {
            CollectionAssertion.Contains(3, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly not contained.
        /// </summary>
        [Fact]
        public void ContainsFailTest()
        {
            CollectionAssertion.Contains(1, 2, 4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object is correctly not contained.
        /// </summary>
        [Fact]
        public void DoesNotContainPassTest()
        {
            CollectionAssertion.DoesNotContain(4, 5, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly contained.
        /// </summary>
        [Fact]
        public void DoesNotContainFailTest()
        {
            CollectionAssertion.DoesNotContain(4, 5, 1, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
