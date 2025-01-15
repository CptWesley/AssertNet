using AssertNet.Moq.Mocks;
using Moq;

namespace AssertNet.Moq;

/// <summary>
/// Static assertion class for the Moq framework.
/// </summary>
public static class Assertions
{
    /// <summary>
    /// Makes an assertion about a mock.
    /// </summary>
    /// <param name="mock">Mock under test.</param>
    /// <typeparam name="T">Type of the mock.</typeparam>
    /// <returns>Assertion about a mock.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static MockAssertion<T> AssertThat<T>(Mock<T> mock)
        where T : class
        => new MockAssertion<T>(mock);
}
