using AssertNet.AssertionTypes;

namespace AssertNet.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="Assertion{Double}"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{TAssert, TTarget}" />
public class DoubleAssertionTests() : ObjectAssertionTests<Assertion<double>, double>(42)
{
    /// <summary>
    /// Checks that the assertion passes if the value is equal to 0.
    /// </summary>
    [Fact]
    public void IsZeroPassTest()
    {
        CreateAssertion(0d).IsZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to 0.
    /// </summary>
    [Fact]
    public void IsZeroFailTest()
    {
        CreateAssertion(1d).IsZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is greater than 0.
    /// </summary>
    [Fact]
    public void IsPositivePassTest()
    {
        CreateAssertion(1d).IsPositive();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than 0.
    /// </summary>
    [Fact]
    public void IsPositiveFailTest()
    {
        CreateAssertion(0d).IsPositive();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is greater than or equal to 0.
    /// </summary>
    [Fact]
    public void IsPositiveOrZeroPassTest()
    {
        CreateAssertion(0d).IsPositiveOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than or equal to 0.
    /// </summary>
    [Fact]
    public void IsPositiveOrZeroFailTest()
    {
        CreateAssertion(-1d).IsPositiveOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is less than 0.
    /// </summary>
    [Fact]
    public void IsNegativePassTest()
    {
        CreateAssertion(-1d).IsNegative();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not less than 0.
    /// </summary>
    [Fact]
    public void IsNegativeFailTest()
    {
        CreateAssertion(0d).IsNegative();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is less than or equal to 0.
    /// </summary>
    [Fact]
    public void IsNegativeOrZeroPassTest()
    {
        CreateAssertion(0d).IsNegativeOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not less than or equal to 0.
    /// </summary>
    [Fact]
    public void IsNegativeOrZeroFailTest()
    {
        CreateAssertion(1d).IsNegativeOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is in the range.
    /// </summary>
    [Fact]
    public void IsInRangePassTest()
    {
        CreateAssertion(9d).IsInRange(8d, 10d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that an exception is thrown when the range is not valid.
    /// </summary>
    [Fact]
    public void IsInRangeExceptionTest()
    {
        Assert.Throws<ArgumentException>(() => CreateAssertion(0d).IsInRange(10d, 8d));
    }

    /// <summary>
    /// Checks that the assertion fails if the value is below the minimum.
    /// </summary>
    [Fact]
    public void IsInRangeLowFailTest()
    {
        CreateAssertion(3d).IsInRange(5d, 6d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is above the maximum.
    /// </summary>
    [Fact]
    public void IsInRangeHighFailTest()
    {
        CreateAssertion(4d).IsInRange(2d, 3d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is below the minimum.
    /// </summary>
    [Fact]
    public void IsNotInRangeLowPassTest()
    {
        CreateAssertion(6d).IsNotInRange(8d, 10d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is above the maximum.
    /// </summary>
    [Fact]
    public void IsNotInRangeHighPassTest()
    {
        CreateAssertion(5d).IsNotInRange(3d, 4d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that an exception is thrown when the range is not valid.
    /// </summary>
    [Fact]
    public void IsNotInRangeExceptionTest()
    {
        Assert.Throws<ArgumentException>(() => CreateAssertion(0d).IsNotInRange(10d, 8d));
    }

    /// <summary>
    /// Checks that the assertion fails if the value is in the range.
    /// </summary>
    [Fact]
    public void IsNotInRangeFailTest()
    {
        CreateAssertion(5d).IsNotInRange(0d, 10d);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualToDoublePassTest()
    {
        CreateAssertion(20d).IsEqualTo(20);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualToDoubleFailTest()
    {
        CreateAssertion(0d).IsEqualTo(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to another value within a margin.
    /// </summary>
    [Fact]
    public void IsEqualToMarginPassTest()
    {
        CreateAssertion(21d).IsApproximately(20, 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to another value within a margin.
    /// </summary>
    [Fact]
    public void IsEqualToMarginFailTest()
    {
        CreateAssertion(5d).IsApproximately(1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualNotToDoublePassTest()
    {
        CreateAssertion(0d).IsNotEqualTo(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualNotToDoubleFailTest()
    {
        CreateAssertion(3d).IsNotEqualTo(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to another value with a margin.
    /// </summary>
    [Fact]
    public void IsEqualNotToMarginPassTest()
    {
        CreateAssertion(0d).IsNotApproximately(10, 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to another value with a margin.
    /// </summary>
    [Fact]
    public void IsEqualNotToMarginFailTest()
    {
        CreateAssertion(3d).IsNotApproximately(4, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
