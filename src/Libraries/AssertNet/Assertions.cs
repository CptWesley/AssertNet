using AssertNet.AssertionTypes;

namespace AssertNet;

/// <summary>
/// Static assertion class for the xUnit framework.
/// </summary>
public static class Assertions
{
    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    [Pure]
    public static Sut<T> That<T>(this AssertionBuilder _, T value, [CallerArgumentExpression(nameof(value))] string? exp = null)
        => new(FailureHandlerFactory.Create(), value, exp);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <param name="exp">The expression under test.</param>
    /// <returns>Assertion about an object.</returns>
    /// <typeparam name="T">The type under test.</typeparam>
    [Pure]
    public static Sut<T> AssertThat<T>(T value, [CallerArgumentExpression(nameof(value))] string? exp = null)
        => new Sut<T>(FailureHandlerFactory.Create(), value, exp);
}
