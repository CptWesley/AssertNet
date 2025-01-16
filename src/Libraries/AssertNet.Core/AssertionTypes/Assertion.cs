namespace AssertNet.Core.AssertionTypes;

/// <summary>
/// Abstract class representing assertions.
/// </summary>
public class Assertion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Assertion"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="subject">The object which is under test.</param>
    protected Assertion(IFailureHandler failureHandler, object? subject)
    {
        FailureHandler = failureHandler;
        Subject = subject;
    }

    /// <summary>
    /// Gets the object under test.
    /// </summary>
    /// <value>
    /// The object under test.
    /// </value>
    public object? Subject { get; }

    /// <summary>
    /// Gets the failure handler of the assertion.
    /// </summary>
    public IFailureHandler FailureHandler { get; }

    /// <summary>
    /// Fails an assertion with a specific message.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    [DoesNotReturn]
    public void Fail(string message)
    {
        FailureHandler.Fail(message);
    }
}

public class Assertion<TSubject> : Assertion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ObjectAssertion{TAssert, TTarget}"/> class.
    /// </summary>
    /// <param name="subject">The object which is under test.</param>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    public Assertion(IFailureHandler failureHandler, TSubject subject)
        : base(failureHandler, subject)
    {
        Subject = subject;
    }

    /// <summary>
    /// Gets the object under test.
    /// </summary>
    /// <value>
    /// The object under test.
    /// </value>
    public new TSubject Subject { get; }
}
