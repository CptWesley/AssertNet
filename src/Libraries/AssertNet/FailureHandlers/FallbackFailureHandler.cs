namespace AssertNet.FailureHandlers;

/// <summary>
/// Failure handler used when we could not find any available test framework failure handlers.
/// </summary>
/// <seealso cref="IFailureHandler" />
public class FallbackFailureHandler : IFailureHandler
{
    /// <inheritdoc/>
    [DoesNotReturn]
    public void Fail(string message)
        => throw new AssertionFailedException(message);

    /// <inheritdoc/>
    [Pure]
    public bool IsAvailable()
        => true;
}
