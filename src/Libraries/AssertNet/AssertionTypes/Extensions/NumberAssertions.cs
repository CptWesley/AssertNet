#if NET7_0_OR_GREATER

using AssertNet.AssertionTypes;
using System.Numerics;

namespace AssertNet;

/// <summary>
/// Provides assertions related to numbers.
/// </summary>
public static class NumberAssertions
{
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
                 .Append("To be a finite number")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is a not finite number.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotFinite<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsFinite(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotFinite()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be a finite number")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is positive infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsPositiveInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsPositiveInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsPositiveInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be positive infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not positive infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotPositiveInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsPositiveInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotPositiveInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be positive infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is negative infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNegativeInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsNegativeInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNegativeInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be negative infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not negative infinity.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotNegativeInfinity<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsNegativeInfinity(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotNegativeInfinity()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be negative infinity")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not-a-number (NaN).</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNaN<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsNaN(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNaN()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be not-a-number (NaN)")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not not-a-number (NaN).</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotNaN<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsNaN(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotNaN()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be not-a-number (NaN)")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is positive or zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsPositiveOrZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsPositive(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsPositiveOrZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be positive or zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not positive or zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotPositiveOrZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsPositive(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotPositiveOrZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be positive or zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is positive.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsPositive<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsPositive(assertion.Subject) || TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsPositive()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be positive")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not positive.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotPositive<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsPositive(assertion.Subject) && !TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotPositive()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be positive")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is negative.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNegative<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsNegative(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNegative()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be negative")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not negative.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotNegative<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsNegative(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotNegative()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be negative")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is negative or zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNegativeOrZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (!TNumber.IsNegative(assertion.Subject) && !TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNegativeOrZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be negative or zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the number under test is not negative or zero.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotNegativeOrZero<TAssert, TNumber>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumberBase<TNumber>
    {
        if (TNumber.IsNegative(assertion.Subject) || TNumber.IsZero(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotNegativeOrZero()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To not be negative or zero")
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the value under test is approximately equivalent.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="other">The value to compare to.</param>
    /// <param name="margin">The variance to allow.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsApproximately<TAssert, TNumber>(this TAssert assertion, TNumber other, TNumber margin, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumber<TNumber>
    {
        if (assertion.Subject < other - margin || assertion.Subject > other + margin)
        {
            assertion.FailureHandler.Fail(new FailureBuilder("IsApproximately()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be greater than or equal to", other - margin)
                 .Append("And less than or equal to", other + margin)
                 .Finish());
        }

        return assertion;
    }

    /// <summary>Ensures that the value under test is not approximately equivalent.</summary>
    /// <typeparam name="TAssert">The type of the assertion.</typeparam>
    /// <typeparam name="TNumber">The type of the number.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="other">The value to compare to.</param>
    /// <param name="margin">The variance to disallow.</param>
    /// <param name="message">The assertion message.</param>
    /// <returns>The updated assertion chain.</returns>
    [Assertion]
    public static TAssert IsNotApproximately<TAssert, TNumber>(this TAssert assertion, TNumber other, TNumber margin, string? message = null)
        where TAssert : IAssertion<TNumber>
        where TNumber : struct, INumber<TNumber>
    {
        if (!(assertion.Subject < other - margin || assertion.Subject > other + margin))
        {
            assertion.FailureHandler.Fail(new FailureBuilder("IsNotApproximately()")
                 .Append(message)
                 .Append("Expecting", assertion.Subject)
                 .Append("To be less than", other - margin)
                 .Append("Or greater than", other + margin)
                 .Finish());
        }

        return assertion;
    }
}
#endif
