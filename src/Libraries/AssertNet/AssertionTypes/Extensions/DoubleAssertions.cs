namespace AssertNet.AssertionTypes;

/// <summary>
/// Class representing assertions made about <see cref="double"/>s.
/// </summary>
/// <seealso cref="Assertion{TAssert, TTarget}" />
[GenerateAssertionsFor<double>]
public static partial class DoubleAssertions
{
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
