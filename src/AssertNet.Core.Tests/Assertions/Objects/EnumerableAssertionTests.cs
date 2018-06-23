using System;
using System.Collections.Generic;
using System.Linq;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.Failures;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="CollectionAssertion"/> class.
    /// </summary>
    public class EnumerableAssertionTests : ObjectAssertionTests<EnumerableAssertion<int>, IEnumerable<int>>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="EnumerableAssertionTests"/> class.
        /// </summary>
        public EnumerableAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            CollectionAssertion = new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3 });
            Assertion = CollectionAssertion;
        }

        /// <summary>
        /// Gets the assertion under test.
        /// </summary>
        private EnumerableAssertion<int> CollectionAssertion { get; }

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
            new EnumerableAssertion<int>(FailureHandler.Object, Array.Empty<int>()).IsEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly not empty.
        /// </summary>
        [Fact]
        public void IsEmptyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1 }).IsEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object is correctly not empty.
        /// </summary>
        [Fact]
        public void IsNotEmptyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1 }).IsNotEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object is incorrectly empty.
        /// </summary>
        [Fact]
        public void IsNotEmptyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, Array.Empty<int>()).IsNotEmpty();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has the correct size.
        /// </summary>
        [Fact]
        public void HasSizePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3 }).HasSize(3);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object has the incorrect size.
        /// </summary>
        [Fact]
        public void HasSizeFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, Array.Empty<int>()).HasSize(3);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has the minimum size.
        /// </summary>
        [Fact]
        public void HasAtLeastSizePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3 }).HasAtLeastSize(2);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object does not have the minimum size.
        /// </summary>
        [Fact]
        public void HasAtLeastSizeFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, Array.Empty<int>()).HasAtLeastSize(1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if the object has less than the maximum size.
        /// </summary>
        [Fact]
        public void HasAtMostSizePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 2 }).HasAtMostSize(4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the object has more than the maximum size.
        /// </summary>
        [Fact]
        public void HasAtMostSizeFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3 }).HasAtMostSize(1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values.
        /// </summary>
        [Fact]
        public void ContainsOnlyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 2, 2, 1 }).ContainsOnly(1, 2);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains other values.
        /// </summary>
        [Fact]
        public void ContainsOnlyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 9, 3, 5 }).ContainsOnly(3, 4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection other elements.
        /// </summary>
        [Fact]
        public void DoesNotContainOnlyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 2, 2, 1 }).DoesNotContainOnly(1, 3);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains only the given values.
        /// </summary>
        [Fact]
        public void DoesNotContainOnlyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 9, 3, 5 }).DoesNotContainOnly(9, 3, 3, 5);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values in correct order.
        /// </summary>
        [Fact]
        public void ContainsExactlyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 2, 9, 6 }).ContainsExactly(2, 9, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains other values or is out of order.
        /// </summary>
        [Fact]
        public void ContainsExactlyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactly(5, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion passes if the collection is not sequence equal to some other collection.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 3, 4, 5 }).DoesNotContainExactly(3, 5, 4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the collection is sequence equal to some other collection.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 9, 6, 4 }).DoesNotContainExactly(9, 6, 4);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does not fail if collection only contains the given values in correct order.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains wrong elements.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderWrongFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 9, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains too many values.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderTooManyFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6, 7, 7);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion fails if collection contains too few values.
        /// </summary>
        [Fact]
        public void ContainsExactlyInAnyOrderTooFewFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion does fails if collection only contains the given values in correct order.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyInAnyOrderFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion passes if collection contains too many values.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyInAnyOrderTooManyPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 6, 7, 7);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion passes if collection contains too few values.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyInAnyOrderTooFewPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion passes if collection contains wrong elements.
        /// </summary>
        [Fact]
        public void DoesNotContainExactlyInAnyOrderWrongPassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 9, 7, 6);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion passes if a collection contains a certain sequence.
        /// </summary>
        [Fact]
        public void ContainsSequencePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).ContainsSequence(1, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if a collection does not contain a certain sequence.
        /// </summary>
        [Fact]
        public void ContainsSequenceFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).ContainsSequence(1, 1, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion passes if a collection does not contain a certain sequence.
        /// </summary>
        [Fact]
        public void DoesNotContainSequencePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainSequence(1, 1, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if a collection contains a certain sequence.
        /// </summary>
        [Fact]
        public void DoesNotContainSequenceFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainSequence(1, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that the assertion passes if a collection contains a certain interleaved sequence.
        /// </summary>
        [Fact]
        public void ContainsInterleavedSequencePassTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).ContainsInterleavedSequence(1, 0, 0);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if a collection does not contain a certain interleaved sequence.
        /// </summary>
        [Fact]
        public void ContainsInterleavedSequenceFailTest()
        {
            new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 0, 1, 0, 1, 1, 0 }).ContainsInterleavedSequence(1, 1, 1, 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
        }

        /// <summary>
        /// Checks that we can properly filter assertions.
        /// </summary>
        [Fact]
        public void WhereTest()
        {
            EnumerableAssertion<int> originalAssertion = new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3, 4 });
            EnumerableAssertion<int> newAssertion = originalAssertion.Where(x => x > 2);
            Assert.Equal(2, newAssertion.Target.Count());
            Assert.Contains(3, newAssertion.Target);
            Assert.Contains(4, newAssertion.Target);
        }

        /// <summary>
        /// Checks that we can properly project assertions.
        /// </summary>
        [Fact]
        public void SelectTest()
        {
            EnumerableAssertion<int> originalAssertion = new EnumerableAssertion<int>(FailureHandler.Object, new int[] { 1, 2, 3, 4 });
            EnumerableAssertion<int> newAssertion = originalAssertion.Select(x => x + 1);
            Assert.Equal(4, newAssertion.Target.Count());
            Assert.Contains(2, newAssertion.Target);
            Assert.Contains(3, newAssertion.Target);
            Assert.Contains(4, newAssertion.Target);
            Assert.Contains(5, newAssertion.Target);
        }
    }
}
