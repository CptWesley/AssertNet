using AssertNet.Core.AssertionTypes;

namespace AssertNet;

/// <summary>
/// Class representing assertions made about strings.
/// </summary>
/// <seealso cref="Assertion{TAssert, TTarget}" />
public static class StringAssertions
{
    /// <summary>
    /// Asserts if a string is equal to a given other string if cases are ignored.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="other">The other string to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsEqualToIgnoringCase<TAssert>(this TAssert assertion, string? other, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (!string.Equals(assertion.Subject, other, StringComparison.OrdinalIgnoreCase))
        {
            assertion.Fail(new FailureBuilder("IsEqualToIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to while ignoring cases", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string is not equal to a given other string if cases are ignored.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="other">The other string to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsNotEqualToIgnoringCase<TAssert>(this TAssert assertion, string other, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (string.Equals(assertion.Subject, other, StringComparison.OrdinalIgnoreCase))
        {
            assertion.Fail(new FailureBuilder("IsNotEqualToIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be equal to while ignoring cases", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string contains a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which needs to be contained.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert Contains<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || !assertion.Subject.Contains(substring))
        {
            assertion.Fail(new FailureBuilder("Contains()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To contain", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not contain a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring may not be contained.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotContain<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.Contains(substring))
        {
            assertion.Fail(new FailureBuilder("DoesNotContain()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to contain", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string contains a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which needs to be contained.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert ContainsIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || assertion.Subject.IndexOf(substring, StringComparison.OrdinalIgnoreCase) < 0)
        {
            assertion.Fail(new FailureBuilder("ContainsIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To contain ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not contain a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring may not be contained.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotContainIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.IndexOf(substring, StringComparison.OrdinalIgnoreCase) >= 0)
        {
            assertion.Fail(new FailureBuilder("DoesNotContainIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to contain ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Determines whether the string under test contains a given pattern.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="pattern">The pattern to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert ContainsPattern<TAssert>(this TAssert assertion, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (!Regex.IsMatch(assertion.Subject, pattern))
        {
            assertion.Fail(new FailureBuilder("ContainsPattern()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To contain the pattern", pattern)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Determines whether the string under test does not contain a given pattern.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="pattern">The pattern to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotContainPattern<TAssert>(this TAssert assertion, [StringSyntax(StringSyntaxAttribute.Regex)] string pattern, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && Regex.IsMatch(assertion.Subject, pattern))
        {
            assertion.Fail(new FailureBuilder("DoesNotContainPattern()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to contain the pattern", pattern)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string starts with a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string must start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert StartsWith<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || !assertion.Subject.StartsWith(substring, false, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("StartsWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To start with", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not start with a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string may not start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotStartWith<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.StartsWith(substring, false, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("DoesNotStartWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to start with", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string starts with a certain substring while ignoring case.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string must start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert StartsWithIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || !assertion.Subject.StartsWith(substring, true, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("StartsWithIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To start with ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not start with a certain substring while ignoring case.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string may not start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotStartWithIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.StartsWith(substring, true, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("DoesNotStartWithIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to start with ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string ends with a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string must start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert EndsWith<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || !assertion.Subject.EndsWith(substring, false, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("EndsWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To end with", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not end with a certain substring.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string may not start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotEndWith<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.EndsWith(substring, false, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("DoesNotEndWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to end with", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string ends with a certain substring while ignoring case.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string must start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert EndsWithIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || !assertion.Subject.EndsWith(substring, true, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("EndsWithIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To end with ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts if a string does not end with a certain substring while ignoring case.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="substring">Substring which the string may not start with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert DoesNotEndWithIgnoringCase<TAssert>(this TAssert assertion, string substring, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is { } && assertion.Subject.EndsWith(substring, true, CultureInfo.InvariantCulture))
        {
            assertion.Fail(new FailureBuilder("DoesNotEndWithIgnoringCase()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to end with ignoring case", substring)
                .Finish());
        }

        return assertion;
    }

    /*
    /// <summary>
    /// Checks if the string is empty.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || assertion.Subject.Length > 0)
        {
            assertion.Fail(new FailureBuilder("IsEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be empty")
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the string is not empty.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsNotEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null || assertion.Subject.Length <= 0)
        {
            assertion.Fail(new FailureBuilder("IsNotEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be empty")
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the string is null or empty.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsNullOrEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (!string.IsNullOrEmpty(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNullOrEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be null or empty")
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the string is not empty or null.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsNotNullOrEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (string.IsNullOrEmpty(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotNullOrEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be null or empty")
                .Finish());
        }

        return assertion;
    }
    */

    /// <summary>
    /// Checks if the string has a certain size.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="size">The size the string should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert HasSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have a length of", size)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.Length != size)
        {
            assertion.Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have a length of", size)
                .Append("But has a length of", assertion.Subject.Length)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the string has at least a certain size.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="size">The size the string should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert HasAtLeastSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at least a length of", size)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.Length < size)
        {
            assertion.Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at least a length of", size)
                .Append("But has length of", assertion.Subject.Length)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the string has at most a certain size.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="size">The size the string should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert HasAtMostSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<string>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at most a length of", size)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.Length > size)
        {
            assertion.Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at most a length of", size)
                .Append("But has length of", assertion.Subject.Length)
                .Finish());
        }

        return assertion;
    }
}
