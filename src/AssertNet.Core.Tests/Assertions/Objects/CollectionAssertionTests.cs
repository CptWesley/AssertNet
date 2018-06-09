using System;
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

        /// <summary>
        /// Checks that the assertion does not fail if the object is correctly empty.
        /// </summary>
        [Fact]
        public void IsEmptyPassTest()
        {
            new CollectionAssertion(FailureHandler.Object, Array.Empty<int>()).IsEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly not empty.
        /// </summary>
        [Fact]
        public void IsEmptyFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 1 }).IsEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object is correctly not empty.
        /// </summary>
        [Fact]
        public void IsNotEmptyPassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 1 }).IsNotEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly empty.
        /// </summary>
        [Fact]
        public void IsNotEmptyFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, Array.Empty<int>()).IsNotEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has the correct size.
        /// </summary>
        [Fact]
        public void HasSizePassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 1, 2, 3 }).HasSize(3);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object has the incorrect size.
        /// </summary>
        [Fact]
        public void HasSizeFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, Array.Empty<int>()).HasSize(3);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has the minimum size.
        /// </summary>
        [Fact]
        public void HasAtLeastSizePassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 1, 2, 3 }).HasAtLeastSize(2);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object does not have the minimum size.
        /// </summary>
        [Fact]
        public void HasAtLeastSizeFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, Array.Empty<int>()).HasAtLeastSize(1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has less than the maximum size.
        /// </summary>
        [Fact]
        public void HasAtMostSizePassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 2 }).HasAtMostSize(4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object has more than the maximum size.
        /// </summary>
        [Fact]
        public void HasAtMostSizeFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 1, 2, 3 }).HasAtMostSize(1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
