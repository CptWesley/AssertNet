using System;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;
using System.Linq;

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

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values.
        /// </summary>
        [Fact]
        public void ContainsOnlyPassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 2, 2, 1 }).ContainsOnly(1, 2);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains other values.
        /// </summary>
        [Fact]
        public void ContainsOnlyFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 9, 3, 5 }).ContainsOnly(3, 4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values in correct order.
        /// </summary>
        [Fact]
        public void ContainsExactlyPassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 2, 9, 6 }).ContainsExactly(2, 9, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains other values or is out of order.
        /// </summary>
        [Fact]
        public void ContainsExactlyFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactly(5, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values in correct order.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderPassTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains wrong elements.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderWrongFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 9, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains too many values.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderTooManyFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6, 7, 7);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains too few values.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderTooFewFailTest()
        {
            new CollectionAssertion(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }
    }
}
