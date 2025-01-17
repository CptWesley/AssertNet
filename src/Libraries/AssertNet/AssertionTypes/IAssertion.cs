namespace AssertNet.AssertionTypes;

/// <summary>
/// Interface representing assertions.
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
