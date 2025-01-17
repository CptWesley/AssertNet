using AssertNet.AssertionTypes;
using AssertNet.SourceGenerator;
using System.Numerics;

namespace AssertNet;

/// <summary>
/// Provides assertions related to numbers.
/// </summary>
[GenerateAssertionsFor<byte>]
[GenerateAssertionsFor<sbyte>]
[GenerateAssertionsFor<ushort>]
[GenerateAssertionsFor<short>]
[GenerateAssertionsFor<uint>]
[GenerateAssertionsFor<int>]
[GenerateAssertionsFor<ulong>]
[GenerateAssertionsFor<long>]
[GenerateAssertionsFor<BigInteger>]
[GenerateAssertionsFor<float>]
[GenerateAssertionsFor<double>]
[GenerateAssertionsFor<decimal>]
public static partial class NumericAssertions
{
#if NET7_0_OR_GREATER
    /// <summary>Ensures that the number under test is a finite number.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsFinite<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsFinite(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsFinite()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be finite")
                 .Finish());
        }

        return assertion;
    }
#endif

    /// <summary>Ensures that the number under test is a finite number.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsFinite<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<double>
    {
        if (double.IsInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be finite")
                 .Finish());
        }

        return assertion;
    }
}
