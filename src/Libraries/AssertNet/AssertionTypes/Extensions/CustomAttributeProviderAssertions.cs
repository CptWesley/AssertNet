namespace AssertNet.AssertionTypes;

/// <summary>Assertions on <see cref="ICustomAttributeProvider" />.</summary>
public static class CustomAttributeProviderAssertions
{
    /// <summary>Asserts that the subject is decorated with the specified attribute.</summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="attribute">
    /// The attribute that is expected to be amongst the custom attributes.
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
    public static TAssert IsDecoratedWith<TAssert, TSubject>(this TAssert assertion, Type attribute, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : ICustomAttributeProvider
    {
        if (!assertion.Subject.GetCustomAttributes(true).Any(a => a.GetType() == attribute))
        {
            assertion.Fail(new FailureBuilder("IsDecoratedWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append($"To be decorated with {attribute}, but was not")
                .Finish());
        }

        return assertion;
    }

    /// <summary>Asserts that the subject is not decorated with the specified attribute.</summary>
    /// <param name="assertion">
    /// The value under test to assert on.
    /// </param>
    /// <param name="attribute">
    /// The attribute that is expected not to be amongst the custom attributes.
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
    public static TAssert IsNotDecoratedWith<TAssert, TSubject>(this TAssert assertion, Type attribute, string? message = null)
        where TAssert : IAssertion<TSubject>
        where TSubject : ICustomAttributeProvider
    {
        if (assertion.Subject.GetCustomAttributes(true).Any(a => a.GetType() == attribute))
        {
            assertion.Fail(new FailureBuilder("IsDecoratedWith()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append($"To be decorated with {attribute}, but was not")
                .Finish());
        }

        return assertion;
    }
}
