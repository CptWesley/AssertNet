using AssertNet.Core.AssertionTypes;
using AssertNet.Core.AssertionTypes.Objects;

namespace AssertNet;

/// <summary>
/// Static assertion class for the xUnit framework.
/// </summary>
public static class Assertions
{
    /// <summary>
    /// Makes an assertion about a numeric value.
    /// </summary>
    /// <param name="value">Numeric value under test.</param>
    /// <returns>Assertion about a numeric value.</returns>
    public static DoubleAssertion That(this AssertionBuilder _, double value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    [OverloadResolutionPriority(-100)]
    public static Assertion<T> That<T>(this AssertionBuilder _, T value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a numeric value.
    /// </summary>
    /// <param name="value">Numeric value under test.</param>
    /// <returns>Assertion about a numeric value.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static DoubleAssertion AssertThat(double value) => new DoubleAssertion(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    [Obsolete("Use Asserts.That instead.")]
    [OverloadResolutionPriority(-100)]
    public static Assertion<T> AssertThat<T>(T value) => new Assertion<T>(FailureHandlerFactory.Create(), value);
}
