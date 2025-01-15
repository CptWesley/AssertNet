using AssertNet.Core.AssertionTypes.Objects;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="DoubleAssertion"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{TAssert, TTarget}" />
public class DoubleAssertionTests : ObjectAssertionTests<DoubleAssertion, double>
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
        new DoubleAssertion(FailureHandler.Object, 32).IsGreaterThanOrEqualTo(32);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsGreaterThanOrEqualFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 2).IsGreaterThanOrEqualTo(23);
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
        new DoubleAssertion(FailureHandler.Object, 2).IsLesserThanOrEqualTo(2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not lesser than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsLesserThanOrEqualFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 2).IsLesserThanOrEqualTo(0);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to 0.
    /// </summary>
    [Fact]
    public void IsZeroPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to 0.
    /// </summary>
    [Fact]
    public void IsZeroFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 1).IsZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is greater than 0.
    /// </summary>
    [Fact]
    public void IsPositivePassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 1).IsPositive();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than 0.
    /// </summary>
    [Fact]
    public void IsPositiveFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsPositive();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is greater than or equal to 0.
    /// </summary>
    [Fact]
    public void IsPositiveOrZeroPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsPositiveOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than or equal to 0.
    /// </summary>
    [Fact]
    public void IsPositiveOrZeroFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, -1).IsPositiveOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is lesser than 0.
    /// </summary>
    [Fact]
    public void IsNegativePassTest()
    {
        new DoubleAssertion(FailureHandler.Object, -1).IsNegative();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not lesser than 0.
    /// </summary>
    [Fact]
    public void IsNegativeFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsNegative();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is lesser than or equal to 0.
    /// </summary>
    [Fact]
    public void IsNegativeOrZeroPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsNegativeOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not lesser than or equal to 0.
    /// </summary>
    [Fact]
    public void IsNegativeOrZeroFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 1).IsNegativeOrZero();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is in the range.
    /// </summary>
    [Fact]
    public void IsInRangePassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 9).IsInRange(8, 10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that an exception is thrown when the range is not valid.
    /// </summary>
    [Fact]
    public void IsInRangeExceptionTest()
    {
        Assert.Throws<ArgumentException>(() => new DoubleAssertion(FailureHandler.Object, 0).IsInRange(10, 8));
    }

    /// <summary>
    /// Checks that the assertion fails if the value is below the minimum.
    /// </summary>
    [Fact]
    public void IsInRangeLowFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 3).IsInRange(5, 6);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is above the maximum.
    /// </summary>
    [Fact]
    public void IsInRangeHighFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 4).IsInRange(2, 3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is below the minimum.
    /// </summary>
    [Fact]
    public void IsNotInRangeLowPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 6).IsNotInRange(8, 10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is above the maximum.
    /// </summary>
    [Fact]
    public void IsNotInRangeHighPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 5).IsNotInRange(3, 4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that an exception is thrown when the range is not valid.
    /// </summary>
    [Fact]
    public void IsNotInRangeExceptionTest()
    {
        Assert.Throws<ArgumentException>(() => new DoubleAssertion(FailureHandler.Object, 0).IsNotInRange(10, 8));
    }

    /// <summary>
    /// Checks that the assertion fails if the value is in the range.
    /// </summary>
    [Fact]
    public void IsNotInRangeFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 5).IsNotInRange(0, 10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualToDoublePassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 20).IsEqualTo(20);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualToDoubleFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsEqualTo(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to another value within a margin.
    /// </summary>
    [Fact]
    public void IsEqualToMarginPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 21).IsEqualTo(20, 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to another value within a margin.
    /// </summary>
    [Fact]
    public void IsEqualToMarginFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 5).IsEqualTo(1, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualNotToDoublePassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsNotEqualTo(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to another value.
    /// </summary>
    [Fact]
    public void IsEqualNotToDoubleFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 3).IsNotEqualTo(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to another value with a margin.
    /// </summary>
    [Fact]
    public void IsEqualNotToMarginPassTest()
    {
        new DoubleAssertion(FailureHandler.Object, 0).IsNotEqualTo(10, 5);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to another value with a margin.
    /// </summary>
    [Fact]
    public void IsEqualNotToMarginFailTest()
    {
        new DoubleAssertion(FailureHandler.Object, 3).IsNotEqualTo(4, 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
