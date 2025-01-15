#if NET8_0_OR_GREATER

using System.Numerics;

namespace AssertNet.Core.AssertionTypes;

/// <summary>Assertions on <see cref="INumber{TSelf}" />.</summary>
public static class NumericAssertions
{
    /// <summary>Ensures that the number under test is a finite number.</summary>
    /// <typeparam name="TNumber">
    /// The type of the number.
    /// </typeparam>
    /// <param name="assertion">
    /// The assertion.
    /// </param>
    /// <param name="message">
    /// The assertion message.
    /// </param>
    [FluentSyntax]
    public static Assertion<TNumber> IsFinite<TNumber>(this Assertion<TNumber> assertion, string? message = null) where TNumber : struct, INumber<TNumber>
    {
        if (!TNumber.IsFinite(assertion.Subject))
        {
            assertion.Fails(new FailureBuilder("IsZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be finate")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is zero.</summary>
    /// <typeparam name="TNumber">
    /// The type of the number.
    /// </typeparam>
    /// <param name="assertion">
    /// The assertion.
    /// </param>
    /// <param name="message">
    /// The assertion message.
    /// </param>
    [FluentSyntax]
    public static Assertion<TNumber> IsZero<TNumber>(this Assertion<TNumber> assertion, string? message = null) where TNumber : struct, INumber<TNumber>
    {
        if (!TNumber.IsZero(assertion.Subject))
        {
            assertion.Fails(new FailureBuilder("IsZero()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", TNumber.Zero)
                .Finish());
        }

        return assertion;
    }
}

#endif
