using AssertNet.AssertionTypes;

namespace AssertNet.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="DoubleAssertion"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{TAssert, TTarget}" />
public class ComparableAssertionTests() : ObjectAssertionTests<Assertion<long>, long>(42)
{
    /// <summary>
    /// Checks that the assertion passes if the value is greater than a certain value.
    /// </summary>
    [Fact]
    public void IsGreaterThanPassTest()
    {
        CreateAssertion(20).IsGreaterThan(10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than a certain value.
    /// </summary>
    [Fact]
    public void IsGreaterThanFailTest()
    {
        CreateAssertion(15).IsGreaterThan(15);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is greater than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsGreaterThanOrEqualPassTest()
    {
        CreateAssertion(32).IsGreaterThanOrEqualTo(32);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not greater than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsGreaterThanOrEqualFailTest()
    {
        CreateAssertion(2).IsGreaterThanOrEqualTo(23);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is lesser than a certain value.
    /// </summary>
    [Fact]
    public void IsLessThanPassTest()
    {
        CreateAssertion(12).IsLessThan(13);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not lesser than a certain value.
    /// </summary>
    [Fact]
    public void IsLessThanFailTest()
    {
        CreateAssertion(25).IsLessThan(10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is lesser than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsLessThanOrEqualPassTest()
    {
        CreateAssertion(2).IsLessThanOrEqualTo(2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not lesser than or equal to a certain value.
    /// </summary>
    [Fact]
    public void IsLessThanOrEqualFailTest()
    {
        CreateAssertion(15).IsLessThanOrEqualTo(0);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
