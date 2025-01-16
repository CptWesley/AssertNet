using AssertNet.AssertionTypes;
using AssertNet.AssertionTypes.Void;
using AssertNet.Failures;

namespace AssertNet.Tests.AssertionTypes.Void;

/// <summary>
/// Test class for the <see cref="VoidAssertion"/> class.
/// </summary>
public class VoidAssertionTests
{
    private readonly Mock<IFailureHandler> _handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="VoidAssertionTests"/> class.
    /// </summary>
    public VoidAssertionTests()
    {
        _handler = new Mock<IFailureHandler>(MockBehavior.Loose);
    }

    /// <summary>
    /// Checks that the constructor functions properly.
    /// </summary>
    [Fact]
    public void ConstructorTest()
    {
        var action = new Mock<Action>(MockBehavior.Loose).Object;
        var assertion = new Assertion<Action>(_handler.Object, action);
        Assert.Same(_handler.Object, assertion.FailureHandler);
    }

    /// <summary>
    /// Checks that whenever a method does not throw an exception the condition passes.
    /// </summary>
    [Fact]
    public void DoesNotThrowExceptionPassTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).DoesNotThrowException();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that whenever a method throws an exception the condition fails.
    /// </summary>
    [Fact]
    public void DoesNotThrowExceptionFailTest()
    {
        new Assertion<Action>(_handler.Object, () => throw new Exception()).DoesNotThrowException();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that whenever a method does not throw an exception the condition passes.
    /// </summary>
    [Fact]
    public void DoesNotThrowExceptionTypedAnyPassTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).DoesNotThrowException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that whenever a method does not throw the specific exception the condition passes.
    /// </summary>
    [Fact]
    public void DoesNotThrowExceptionTypedPassTest()
    {
        new Assertion<Action>(_handler.Object, () => throw new Exception()).DoesNotThrowException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that whenever a method throws the specific exception the condition fails.
    /// </summary>
    [Fact]
    public void DoesNotThrowExceptionTypedFailTest()
    {
        new Assertion<Action>(
            _handler.Object,
            () => throw new ArgumentException(string.Empty)).DoesNotThrowException<Exception>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that whenever a method does not throw an exception the condition passes.
    /// </summary>
    [Fact]
    public void DoesNotThrowExactlyExceptionAnyPassTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).DoesNotThrowExactlyException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that whenever a method does not throw the exact exception the condition passes.
    /// </summary>
    [Fact]
    public void DoesNotThrowExactlyExceptionPassTest()
    {
        new Assertion<Action>(_handler.Object, () => throw new ArgumentException(string.Empty)).DoesNotThrowExactlyException<Exception>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that whenever a method throws the exact exception the condition fails.
    /// </summary>
    [Fact]
    public void DoesNotThrowExactlyExceptionFailTest()
    {
        new Assertion<Action>(
            _handler.Object,
            () => throw new ArgumentException(string.Empty)).DoesNotThrowExactlyException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the condition passes whenever an exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsAnyExceptionPassTest()
    {
        var result = new Assertion<Action>(_handler.Object, () => throw new Exception()).ThrowsException();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        Assert.NotNull(result);
    }

    /// <summary>
    /// Checks that the condition fails whenever no exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsAnyExceptionFailTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).ThrowsException();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the condition passes whenever the specific exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsSpecificExceptionPassTest()
    {
        var result = new Assertion<Action>(
            _handler.Object,
            () => throw new ArgumentException(string.Empty)).ThrowsException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        Assert.NotNull(result);
    }

    /// <summary>
    /// Checks that the condition fails whenever no exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsSpecificExceptionWrongFailTest()
    {
        new Assertion<Action>(
            _handler.Object,
            () => throw new Exception()).ThrowsException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the condition fails whenever no exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsSpecificExceptionFailTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).ThrowsException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the condition passes whenever the exact exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsExactlyExceptionPassTest()
    {
        var result = new Assertion<Action>(
            _handler.Object,
            () => throw new ArgumentException(string.Empty)).ThrowsExactlyException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        Assert.NotNull(result);
    }

    /// <summary>
    /// Checks that the condition fails whenever the invalid exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsExactlyExceptionWrongFailTest()
    {
        new Assertion<Action>(
            _handler.Object,
            () => throw new ArgumentException(string.Empty)).ThrowsExactlyException<Exception>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the condition fails whenever no exception is thrown.
    /// </summary>
    [Fact]
    public void ThrowsExactlyExceptionFailTest()
    {
        new Assertion<Action>(_handler.Object, DoNothing).ThrowsExactlyException<ArgumentException>();
        _handler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Do Nothing.
    /// </summary>
    private static void DoNothing()
    {
        // Do nothing.
    }
}
