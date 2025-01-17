namespace AssertNet.AssertionTypes;

/// <summary>
/// Interface representing assertions.
/// </summary>
/// <typeparam name="TSubject">The type of the object under test.</typeparam>
public interface IAssertion<out TSubject> : IAssertion
{
    /// <inheritdoc cref="IAssertion.Subject" />
    public new TSubject Subject { get; }
}
