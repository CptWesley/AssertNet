namespace AssertNet.AssertionTypes;

/// <summary>
/// Interface representing assertions.
/// </summary>
/// <typeparam name="TAssert">The self-referential assertion type.</typeparam>
/// <typeparam name="TSubject">The type of the object under test.</typeparam>
public interface IAssertion<out TAssert, out TSubject> : IAssertion<TSubject>
    where TAssert : IAssertion<TAssert, TSubject>
{
}
