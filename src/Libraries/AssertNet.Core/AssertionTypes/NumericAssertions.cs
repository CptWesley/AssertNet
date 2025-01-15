#if NET8_0_OR_GREATER

using System.Numerics;

namespace AssertNet.Core.AssertionTypes;

public static class NumericAssertions
{
    public static void IsFinate<TNumber>(this Assertion<TNumber> assertion, string? message = null) where TNumber : struct, INumber<TNumber>
    {
        if (!TNumber.IsFinite(assertion.Subject))
        {
            assertion.Fails(new FailureBuilder("IsZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be finate")
                 .Finish());
        }
    }

    public static void IsZero<TNumber>(this Assertion<TNumber> assertion, string? message = null) where TNumber : struct, INumber<TNumber>
    {
        if (!TNumber.IsZero(assertion.Subject))
        {
            assertion.Fails(new FailureBuilder("IsZero()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", TNumber.Zero)
                .Finish());
        }
    }
}

#endif
