namespace AssertNet.AssertionTypes;

/// <summary>
/// Class representing assertions made about doubles (and other numeric values).
/// </summary>
public static class ComparableAssertions
{
    /// <summary>
    /// Asserts if the asserted value is greater than the value under test.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="other">
    /// Value which should be greater than the value under test.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsGreaterThan<TAssert, TSubject>(this TAssert assertion, TSubject other, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (assertion.Subject.CompareTo(other) <= 0)
        {
            assertion.Fail(new FailureBuilder("IsGreaterThan()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if the asserted value is greater than or equal to the value under test.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="other">
    /// Value which should be greater than or equal to the value under test.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsGreaterThanOrEqualTo<TAssert, TSubject>(this TAssert assertion, TSubject other, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (assertion.Subject.CompareTo(other) < 0)
        {
            assertion.Fail(new FailureBuilder("IsGreaterThanOrEqualTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than or equal to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if the asserted value is lesser than the value under test.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="other">
    /// Value which should be lesser than the value under test.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsLesserThan<TAssert, TSubject>(this TAssert assertion, TSubject other, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (assertion.Subject.CompareTo(other) >= 0)
        {
            assertion.Fail(new FailureBuilder("IsLesserThan()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if the asserted value is lesser than or equal to the value under test.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="other">
    /// Value which should be lesser than or equal to the value under test.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    [Assertion]
    public static TAssert IsLesserThanOrEqualTo<TAssert, TSubject>(this TAssert assertion, TSubject other, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (assertion.Subject.CompareTo(other) > 0)
        {
            assertion.Fail(new FailureBuilder("IsLesserThanOrEqualTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than or equal to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is within a certain range.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="minimum">
    /// Lower bound of the range the value should be in.
    /// </param>
    /// <param name="maximum">
    /// Upper bound of the range the value should be in.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    /// <exception cref="ArgumentException">Thrown if the maximum is larger or equal to the minimum.</exception>
    [Assertion]
    public static TAssert IsInRange<TAssert, TSubject>(this TAssert assertion, TSubject minimum, TSubject maximum, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (maximum.CompareTo(minimum) <= 0)
        {
            throw new ArgumentException($"Value for 'minimum' ({minimum}) should be lower than the value for 'maximum' ({maximum}).");
        }

        if (assertion.Subject.CompareTo(minimum) < 0 || assertion.Subject.CompareTo(maximum) > 0)
        {
            assertion.Fail(new FailureBuilder("IsInRange()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be greater than or equal to", minimum)
                .Append("And lesser than or equal to", maximum)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a double is outside a certain range.
    /// </summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="minimum">
    /// Lower bound of the range the value may not be in.
    /// </param>
    /// <param name="maximum">
    /// Upper bound of the range the value may not be in.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <typeparam name="TAssert">
    /// The type of the assertion.
    /// </typeparam>
    /// <typeparam name="TSubject">
    /// The type of the subject.
    /// </typeparam>
    /// <returns>The current assertion.</returns>
    /// <exception cref="ArgumentException">Thrown if the maximum is larger or equal to the minimum.</exception>
    [Assertion]
    public static TAssert IsNotInRange<TAssert, TSubject>(this TAssert assertion, TSubject minimum, TSubject maximum, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : IComparable<TSubject>
    {
        if (maximum.CompareTo(minimum) <= 0)
        {
            throw new ArgumentException($"Value for 'minimum' ({minimum}) should be lower than the value for 'maximum' ({maximum}).");
        }

        if (assertion.Subject.CompareTo(minimum) >= 0 && assertion.Subject.CompareTo(maximum) <= 0)
        {
            assertion.Fail(new FailureBuilder("IsNotInRange()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be lesser than", minimum)
                .Append("Or greater than", maximum)
                .Finish());
        }

        return assertion;
    }
}
