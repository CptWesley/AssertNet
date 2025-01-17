namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsNegativeOrZero assertion.
/// </summary>
internal sealed class IsNegativeOrZero : Assertion
{
    private static readonly IsNegative IsNegative = new();
    private static readonly IsZero IsZero = new();

    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type)
        => IsNegative.IsApplicableFor(type)
        && IsZero.IsApplicableFor(type);

    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is a negative number or zero.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNegativeOrZero<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsNegative(assertion.Subject) && !{name}.IsZero(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNegativeOrZero()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be a negative number or zero"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not a negative number or zero.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotNegativeOrZero<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsNegative(assertion.Subject) || {name}.IsZero(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotNegativeOrZero()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be a negative number or zero"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
