using AssertNet.Core.AssertionTypes;

namespace AssertNet;

/// <summary>
/// Class representing assertions made on boolean items.
/// </summary>
/// <seealso cref="Assertion{TAssert, TTarget}" />
public static class BooleanAssertions
{
    /// <summary>
    /// Asserts that the boolean value is true.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsTrue<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : Assertion<bool>
    {
        if (!assertion.Subject)
        {
            assertion.Fail(new FailureBuilder("IsTrue()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", true)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that the boolean value is false.
    /// </summary>
    /// <param name="assertion">The initial assertion chain.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="TAssert">The type of assertion.</typeparam>
    /// <returns>The updated assertion chain.</returns>
    public static TAssert IsFalse<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : Assertion<bool>
    {
        if (assertion.Subject)
        {
            assertion.Fail(new FailureBuilder("IsFalse()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", false)
                .Finish());
        }

        return assertion;
    }
}
