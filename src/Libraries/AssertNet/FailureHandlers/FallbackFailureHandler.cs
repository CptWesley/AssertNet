using AssertNet.Core.Failures;

namespace AssertNet.FailureHandlers;

/// <summary>
/// Failure handler used when we could not find any available test framework failure handlers.
/// </summary>
/// <seealso cref="IFailureHandler" />
public class FallbackFailureHandler : IFailureHandler
{
    /// <inheritdoc/>
    public void Fail(string message)
        => throw new AssertionFailedException(message);

    /// <inheritdoc/>
    public bool IsAvailable()
        => true;
}
