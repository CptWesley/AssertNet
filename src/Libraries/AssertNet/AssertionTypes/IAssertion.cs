namespace AssertNet.AssertionTypes;

/// <summary>
/// Abstract class representing assertions.
/// </summary>
public interface IAssertion
{
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
}

public static class AssertionExtensions
{
    /// <summary>
    /// Fails an assertion with a specific message.
    /// </summary>
    /// <param name="message">The message to fail with.</param>
    [DoesNotReturn]
    public static void Fail(this IAssertion assertion, string message)
    {
        assertion.FailureHandler.Fail(message);
    }
}
