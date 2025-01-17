namespace AssertNet.AssertionTypes;

/// <summary>
/// Class representing assertions made about doubles (and other numeric values).
/// </summary>
/// <seealso cref="Assertion{TAssert, TTarget}" />
[GenerateAssertionsFor<double>]
public static partial class DoubleAssertions
{
    /// <summary>
    /// Asserts if a double is equal to zero.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsZero<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
#pragma warning disable S1244 // Intentionally comparing to exactly zero.
        if (assertion.Subject != 0)
#pragma warning restore S1244
        {
            assertion.Fail(new FailureBuilder("IsZero()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", 0)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is greater than zero.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsPositive<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject <= 0)
        {
            assertion.Fail(new FailureBuilder("IsPositive()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than", 0)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is greater than or equal to zero.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsPositiveOrZero<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject < 0)
        {
            assertion.Fail(new FailureBuilder("IsPositiveOrZero()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than or equal to", 0)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is greater than zero.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsNegative<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject >= 0)
        {
            assertion.Fail(new FailureBuilder("IsNegative()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than", 0)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is greater than or equal to zero.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsNegativeOrZero<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject > 0)
        {
            assertion.Fail(new FailureBuilder("IsNegativeOrZero()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than or equal to", 0)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the double under test is equal to another double within a certain margin.
    /// </summary>
    /// <param name="other">The other double to compare with.</param>
    /// <param name="margin">The margin to still identify another double as equal.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsApproximately<TAssert>(this TAssert assertion, double other, double margin, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject < other - margin || assertion.Subject > other + margin)
        {
            assertion.Fail(new FailureBuilder("IsApproximately()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than or equal to", other - margin)
                .Append("And lesser than or equal to", other + margin)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the double under test is not equal to another double within a certain margin.
    /// </summary>
    /// <param name="other">The other double to compare with.</param>
    /// <param name="margin">The margin to still identify another double as equal.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsNotApproximately<TAssert>(this TAssert assertion, double other, double margin, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (assertion.Subject >= other - margin && assertion.Subject <= other + margin)
        {
            assertion.Fail(new FailureBuilder("IsNotApproximately()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than", other - margin)
                .Append("Or greater than", other + margin)
                .Finish());
        }

        return assertion;
    }
}
