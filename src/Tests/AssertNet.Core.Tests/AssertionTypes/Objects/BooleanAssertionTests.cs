using AssertNet.Core.AssertionTypes;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="BooleanAssertion"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{T1, T2}" />
public class BooleanAssertionTests : ObjectAssertionTests<SimpleAssertion<bool>, bool>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BooleanAssertionTests"/> class.
    /// </summary>
    public BooleanAssertionTests()
    {
        FailureHandler = new Mock<IFailureHandler>(MockBehavior.Loose);
        Assertion = new SimpleAssertion<bool>(FailureHandler.Object, true);
    }

    /// <summary>
    /// Checks that the assertion passes if the value is correctly true.
    /// </summary>
    [Fact]
    public void IsTruePassTest()
    {
        new SimpleAssertion<bool>(FailureHandler.Object, true).IsTrue();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is incorrectly false.
    /// </summary>
    [Fact]
    public void IsTrueFailTest()
    {
        new SimpleAssertion<bool>(FailureHandler.Object, false).IsTrue();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is correctly false.
    /// </summary>
    [Fact]
    public void IsFalsePassTest()
    {
        new SimpleAssertion<bool>(FailureHandler.Object, false).IsFalse();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is incorrectly true.
    /// </summary>
    [Fact]
    public void IsFalseFailTest()
    {
        new SimpleAssertion<bool>(FailureHandler.Object, true).IsFalse();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
