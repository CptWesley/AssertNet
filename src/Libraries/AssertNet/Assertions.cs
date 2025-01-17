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
    public static Assertion<T> That<T>(this AssertionBuilder _, T value) => new(FailureHandlerFactory.Create(), value);
     
    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    [Obsolete("Use Asserts.That instead.")]
    [OverloadResolutionPriority(-100)]
    public static Assertion<T> AssertThat<T>(T value) => new Assertion<T>(FailureHandlerFactory.Create(), value);
}
