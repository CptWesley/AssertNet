using AssertNet.Moq.Mocks;
using Moq;

namespace AssertNet;

/// <summary>Assertions on <see cref="Mock{T}"/> objects.</summary>
public static class MoqAssertions
{
    /// <summary>
    /// Makes an assertion about a mock.
    /// </summary>
    /// <param name="_">
    /// The assertion builder.
    /// </param>
    /// <param name="mock">
    /// Mock object under test.
    /// </param>
    /// <typeparam name="T">
    /// Type of the mock.
    /// </typeparam>
    /// <returns>Assertion about a mock.</returns>
    public static MockAssertion<T> That<T>(this AssertionBuilder _, Mock<T> mock) where T : class
        => new(mock);
}
