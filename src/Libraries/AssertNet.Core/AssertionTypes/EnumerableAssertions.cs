using AssertNet.Core.AssertionTypes;

namespace AssertNet;

/// <summary>Assertions on <see cref="IEnumerable{T}"/>.</summary>
public static class EnumerableAssertions
{
    /// <summary>
    /// Checks if the collection contains the element.
    /// </summary>
    /// <param name="assertion">
    /// The assertion.
    /// </param>
    /// <param name="element">
    /// The element to check for.
    /// </param>
    /// <param name="message">
    /// Custom message for the assertion failure.
    /// </param>
    /// <returns>The current assertion.</returns>
    [FluentSyntax]
    public static Assertion<TCollection> Contains<TCollection, TItem>(this Assertion<TCollection> assertion, TItem element, string? message = null)
        where TCollection : IEnumerable<TItem>
    {
        if (!assertion.Subject.Contains(element))
        {
            assertion.Fails(new FailureBuilder("Contains()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append("To contain", element)
                .Finish());
        }

        return assertion;
    }
}
