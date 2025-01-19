using AssertNet.AssertionTypes;
using AssertNet.AssertionTypes.Void;
using AssertNet.Failures;
using AssertNet.Tests.AssertionTypes.Objects;

namespace AssertNet.Tests.AssertionTypes.Void;

/// <summary>
/// Test class for the <see cref="ExceptionAssertion"/> class.
/// </summary>
public class ExceptionAssertionTests : ObjectAssertionTests<Sut<Exception>, Exception>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionAssertionTests"/> class.
    /// </summary>
    public ExceptionAssertionTests()
        : base(new Exception())
    {
    }

    /// <summary>
    /// Checks that the constructor functions properly.
    /// </summary>
    [Fact]
    public void ConstructorTest()
    {
        var e = new Mock<Exception>(MockBehavior.Loose).Object;
        var assertion = new Sut<Exception>(FailureHandler.Object, e);
        Assert.Same(FailureHandler.Object, assertion.FailureHandler);
        Assert.Same(e, assertion.Subject);
    }

    /// <summary>
    /// Checks that the assertion passes if the exception has the correct message.
    /// </summary>
    [Fact]
    public void WithMessagePassTest()
    {
        string msg = "t2fdres4";
        new Sut<Exception>(FailureHandler.Object, new Exception(msg)).WithMessage(msg);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the exception has the wrong message.
    /// </summary>
    [Fact]
    public void WithMessageFailTest()
    {
        string msg = "4356543rf";
        new Sut<Exception>(FailureHandler.Object, new Exception()).WithMessage(msg);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the exception contains the message.
    /// </summary>
    [Fact]
    public void WithMessageContainingPassTest()
    {
        new Sut<Exception>(FailureHandler.Object, new Exception("abcd")).WithMessageContaining("c");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the exception does not contain the message.
    /// </summary>
    [Fact]
    public void WithMessageContainingFailTest()
    {
        new Sut<Exception>(FailureHandler.Object, new Exception("b")).WithMessageContaining("a");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the exception does not have an inner exception.
    /// </summary>
    [Fact]
    public void WithNoInnerExceptionPassTest()
    {
        new Sut<Exception>(FailureHandler.Object, new Exception()).WithNoInnerException();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the exception has an inner exception.
    /// </summary>
    [Fact]
    public void WithNoInnerExceptionFailTest()
    {
        new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty, new Exception())).WithNoInnerException();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the exception does have an inner exception.
    /// </summary>
    [Fact]
    public void WithInnerExceptionPassTest()
    {
        var inner = new Exception();
        var assertion = new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty, inner)).WithInnerException();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        Assert.Same(inner, assertion.Subject);
    }

    /// <summary>
    /// Checks that the assertion fails if the exception does not have an inner exception.
    /// </summary>
    [Fact]
    public void WithInnerExceptionFailTest()
    {
        new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty)).WithInnerException();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the exception does have an inner exception
    /// of the correct type.
    /// </summary>
    [Fact]
    public void WithInnerExceptionSpecificPassTest()
    {
        var inner = new ArgumentException(string.Empty);
        var assertion = new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty, inner)).WithInnerException<ArgumentException>();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        Assert.Same(inner, assertion.Subject);
    }

    /// <summary>
    /// Checks that the assertion fails if the exception does not have an inner exception
    /// at all.
    /// </summary>
    [Fact]
    public void WithInnerExceptionSpecificNoneFailTest()
    {
        var assertion = new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty)).WithInnerException<ArgumentException>();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion fails if the exception does not have an inner exception
    /// of the correct type.
    /// </summary>
    [Fact]
    public void WithInnerExceptionSpecificWrongFailTest()
    {
        var inner = new Exception();
        var assertion = new Sut<Exception>(
            FailureHandler.Object,
            new Exception(string.Empty, inner)).WithInnerException<ArgumentException>();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
