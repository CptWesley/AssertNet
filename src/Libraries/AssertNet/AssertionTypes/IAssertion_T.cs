namespace AssertNet.AssertionTypes;

public interface IAssertion<out TSubject> : IAssertion
{
    /// <inheritdoc cref="IAssertion.Subject" />
    public new TSubject Subject { get; }
}
