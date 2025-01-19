using AssertNet.AssertionTypes;

namespace AssertNet.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="Assertion"/> class.
/// </summary>
public class EnumerableAssertionTests : ObjectAssertionTests<Sut<int[]>, int[]>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerableAssertionTests"/> class.
    /// </summary>
    public EnumerableAssertionTests()
        : base(new[] { 1, 2, 3 })
    {
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object is correctly contained.
    /// </summary>
    [Fact]
    public void ContainsPassTest()
    {
        Assertion.Contains(3, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object is incorrectly not contained.
    /// </summary>
    [Fact]
    public void ContainsFailTest()
    {
        Assertion.Contains(1, 2, 4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object is correctly not contained.
    /// </summary>
    [Fact]
    public void DoesNotContainPassTest()
    {
        Assertion.DoesNotContain(4, 5, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object is incorrectly contained.
    /// </summary>
    [Fact]
    public void DoesNotContainFailTest()
    {
        Assertion.DoesNotContain(4, 5, 1, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object is correctly empty.
    /// </summary>
    [Fact]
    public void IsEmptyPassTest()
    {
        CreateAssertion(Array.Empty<int>()).IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object is incorrectly not empty.
    /// </summary>
    [Fact]
    public void IsEmptyFailTest()
    {
        CreateAssertion(new[] { 1 }).IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object is correctly not empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyPassTest()
    {
        CreateAssertion(new[] { 1 }).IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object is incorrectly empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyFailTest()
    {
        CreateAssertion(Array.Empty<int>()).IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object has the correct size.
    /// </summary>
    [Fact]
    public void HasSizePassTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object has the incorrect size.
    /// </summary>
    [Fact]
    public void HasSizeFailTest()
    {
        CreateAssertion(Array.Empty<int>()).HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object has the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizePassTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).HasAtLeastSize(2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object does not have the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizeFailTest()
    {
        CreateAssertion(Array.Empty<int>()).HasAtLeastSize(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the object has less than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizePassTest()
    {
        CreateAssertion(new[] { 5, 2 }).HasAtMostSize(4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the object has more than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizeFailTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).HasAtMostSize(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if collection only contains the given values.
    /// </summary>
    [Fact]
    public void ContainsOnlyPassTest()
    {
        CreateAssertion(new[] { 2, 2, 1 }).ContainsOnly(1, 2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains other values.
    /// </summary>
    [Fact]
    public void ContainsOnlyFailTest()
    {
        CreateAssertion(new[] { 9, 3, 5 }).ContainsOnly(3, 4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if collection other elements.
    /// </summary>
    [Fact]
    public void DoesNotContainOnlyPassTest()
    {
        CreateAssertion(new[] { 2, 2, 1 }).DoesNotContainOnly(1, 3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains only the given values.
    /// </summary>
    [Fact]
    public void DoesNotContainOnlyFailTest()
    {
        CreateAssertion(new[] { 9, 3, 5 }).DoesNotContainOnly(9, 3, 3, 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if collection only contains the given values in correct order.
    /// </summary>
    [Fact]
    public void ContainsExactlyPassTest()
    {
        CreateAssertion(new[] { 2, 9, 6 }).ContainsExactly(2, 9, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains other values or is out of order.
    /// </summary>
    [Fact]
    public void ContainsExactlyFailTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).ContainsExactly(5, 7, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if the collection is not sequence equal to some other collection.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyPassTest()
    {
        CreateAssertion(new[] { 3, 4, 5 }).DoesNotContainExactly(3, 5, 4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the collection is sequence equal to some other collection.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyFailTest()
    {
        CreateAssertion(new[] { 9, 6, 4 }).DoesNotContainExactly(9, 6, 4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if collection only contains the given values in correct order.
    /// </summary>
    [Fact]
    public void ContainsExactlyInAnyOrderPassTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 7, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains wrong elements.
    /// </summary>
    [Fact]
    public void ContainsExactlyInAnyOrderWrongFailTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 9, 7, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains too many values.
    /// </summary>
    [Fact]
    public void ContainsExactlyInAnyOrderTooManyFailTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6, 7, 7);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion fails if collection contains too few values.
    /// </summary>
    [Fact]
    public void ContainsExactlyInAnyOrderTooFewFailTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).ContainsExactlyInAnyOrder(5, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does fails if collection only contains the given values in correct order.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyInAnyOrderFailTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 7, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if collection contains too many values.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyInAnyOrderTooManyPassTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 6, 7, 7);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if collection contains too few values.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyInAnyOrderTooFewPassTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if collection contains wrong elements.
    /// </summary>
    [Fact]
    public void DoesNotContainExactlyInAnyOrderWrongPassTest()
    {
        CreateAssertion(new[] { 5, 6, 7 }).DoesNotContainExactlyInAnyOrder(5, 9, 7, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if a collection contains a certain sequence.
    /// </summary>
    [Fact]
    public void ContainsSequencePassTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).ContainsSequence(1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if a collection does not contain a certain sequence.
    /// </summary>
    [Fact]
    public void ContainsSequenceFailTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).ContainsSequence(1, 1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if a collection does not contain a certain sequence.
    /// </summary>
    [Fact]
    public void DoesNotContainSequencePassTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainSequence(1, 1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if a collection contains a certain sequence.
    /// </summary>
    [Fact]
    public void DoesNotContainSequenceFailTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainSequence(1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if a collection contains a certain interleaved sequence.
    /// </summary>
    [Fact]
    public void ContainsInterleavedSequencePassTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).ContainsInterleavedSequence(1, 0, 0);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if a collection does not contain a certain interleaved sequence.
    /// </summary>
    [Fact]
    public void ContainsInterleavedSequenceFailTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).ContainsInterleavedSequence(1, 1, 1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if a collection does not contain a certain interleaved sequence.
    /// </summary>
    [Fact]
    public void DoesNotContainInterleavedSequencePassTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainInterleavedSequence(1, 1, 0, 0);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if a collection contains a certain interleaved sequence.
    /// </summary>
    [Fact]
    public void DoesNotContainInterleavedSequenceFailTest()
    {
        CreateAssertion(new[] { 0, 1, 0, 1, 1, 0 }).DoesNotContainInterleavedSequence(0, 1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if the enumerable contains null.
    /// </summary>
    [Fact]
    public void ContainsNullPassTest()
    {
        CreateAssertion(new[] { "a", null!, "b" }).ContainsNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the enumerable does not contain null.
    /// </summary>
    [Fact]
    public void ContainsNullFailTest()
    {
        CreateAssertion(new[] { "c", "d" }).ContainsNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if the enumerable does not contain null.
    /// </summary>
    [Fact]
    public void DoesNotContainNullPassTest()
    {
        CreateAssertion(new[] { "e", "f" }).DoesNotContainNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the enumerable contains null.
    /// </summary>
    [Fact]
    public void DoesNotContainNullFailTest()
    {
        CreateAssertion(new[] { "g", null!, "h" }).DoesNotContainNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if all elements hold to a condition.
    /// </summary>
    [Fact]
    public void AllSatisfyPassTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).AllSatisfy(x => x > 0);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if not all elements hold to a condition.
    /// </summary>
    [Fact]
    public void AllSatisfyFailTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).AllSatisfy(x => x > 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if some element holds to a condition.
    /// </summary>
    [Fact]
    public void SomeSatisfyPassTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).SomeSatisfy(x => x > 2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if no element holds to a condition.
    /// </summary>
    [Fact]
    public void SomeSatisfyFailTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).SomeSatisfy(x => x > 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion passes if no element holds to a condition.
    /// </summary>
    [Fact]
    public void NoneSatisfyPassTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).NoneSatisfy(x => x > 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if some element holds to a condition.
    /// </summary>
    [Fact]
    public void NoneSatisfyFailTest()
    {
        CreateAssertion(new[] { 1, 2, 3 }).NoneSatisfy(x => x > 2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that we can properly filter assertions.
    /// </summary>
    [Fact]
    public void WhereTest()
    {
        var originalAssertion = CreateAssertion(new[] { 1, 2, 3, 4 });
        var newAssertion = originalAssertion.Where(x => x > 2);
        Assert.Equal(2, newAssertion.Subject.Count());
        Assert.Contains(3, newAssertion.Subject);
        Assert.Contains(4, newAssertion.Subject);
    }

    /// <summary>
    /// Checks that we can properly project assertions.
    /// </summary>
    [Fact]
    public void SelectTest()
    {
        var originalAssertion = CreateAssertion(new[] { 1, 2, 3, 4 });
        var newAssertion = originalAssertion.Select(x => x + 1);
        Assert.Equal(4, newAssertion.Subject.Count());
        Assert.Contains(2, newAssertion.Subject);
        Assert.Contains(3, newAssertion.Subject);
        Assert.Contains(4, newAssertion.Subject);
        Assert.Contains(5, newAssertion.Subject);
    }
}
