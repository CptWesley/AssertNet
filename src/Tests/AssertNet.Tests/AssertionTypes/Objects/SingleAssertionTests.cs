using AssertNet.AssertionTypes;
using AssertNet.Failures;

namespace AssertNet.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="SingleAssertion"/> class.
/// </summary>
public class SingleAssertionTests : ObjectAssertionTests<Assertion<object?>, object?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SingleAssertionTests"/> class.
    /// </summary>
    public SingleAssertionTests()
    {
        FailureHandler = new Mock<IFailureHandler>(MockBehavior.Loose);
        Assertion = new Assertion<object?>(FailureHandler.Object, "bery43566435fgdtfg");
    }

    /// <summary>
    /// Checks that there are no failures if the object is incorrectly null.
    /// </summary>
    [Fact]
    public void IsNotNullFailTest()
    {
        Assertion = new Assertion<object?>(FailureHandler.Object, null);
        Assertion.IsNotNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are failures if the object is correctly null.
    /// </summary>
    [Fact]
    public void IsNullPassTest()
    {
        Assertion = new Assertion<object?>(FailureHandler.Object, null);
        Assertion.IsNull();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are no failures if an object is exactly an instance of a type.
    /// </summary>
    [Fact]
    public void IsExactlyInstanceOfPassTest()
    {
        Assertion.IsExactlyInstanceOf<string>();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if an object is exactly an instance of a type.
    /// </summary>
    [Fact]
    public void IsNotExactlyInstanceOfFailTest()
    {
        Assertion.IsNotExactlyInstanceOf<string>();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
