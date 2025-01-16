namespace AssertNet.Failures;

/// <summary>
/// Interface for failure handlers.
/// </summary>
public interface IFailureHandler
{
    /// <summary>
    /// Determines whether this instance is available.
    /// </summary>
    /// <returns><c>true</c> if this instance is available; otherwise, <c>false</c>.</returns>
    bool IsAvailable();

    /// <summary>
    /// Creates an assertion failure with a certain message.
    /// </summary>
    /// <param name="message">The message of the assertion failure.</param>
    [DoesNotReturn]
    void Fail(string message);
}
