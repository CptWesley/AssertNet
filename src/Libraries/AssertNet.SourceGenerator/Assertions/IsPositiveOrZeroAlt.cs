namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsPositiveOrZero assertion.
/// </summary>
internal sealed class IsPositiveOrZeroAlt : Assertion
{
    private static readonly IsPositiveOrZero IsPositive = new();

    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type)
        => !IsPositive.IsApplicableFor(type) && type.IsNumericType();

    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is a positive number or zero.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsPositiveOrZero<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!(assertion.Subject >= 0))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsPositive()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be a positive number or zero"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not a positive number or zero.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotPositiveOrZero<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (assertion.Subject >= 0)
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsNotPositive()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be a positive number or zero"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
