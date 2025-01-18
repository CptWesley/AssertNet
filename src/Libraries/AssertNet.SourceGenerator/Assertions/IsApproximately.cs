namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsApproximately assertion.
/// </summary>
internal sealed class IsApproximately() : Assertion
{
    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type)
        => (type.DefinesAddition()
        && type.DefinesMinus()
        && type.DefinesGreaterThan()
        && type.DefinesLessThan())
        || type.IsNumericType();

    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the value under test is approximately equivalent.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""other"">The value to compare to.</param>
        /// <param name=""margin"">The variance to allow.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsApproximately<TAssert>(this TAssert assertion, {name} other, {name} margin, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (assertion.Subject < other - margin || assertion.Subject > other + margin)
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsApproximately()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be greater than or equal to"", other - margin)
                     .Append(""And less than or equal to"", other + margin)
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the value under test is not approximately equivalent.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""other"">The value to compare to.</param>
        /// <param name=""margin"">The variance to disallow.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotApproximately<TAssert>(this TAssert assertion, {name} other, {name} margin, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!(assertion.Subject < other - margin || assertion.Subject > other + margin))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsNotApproximately()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be less than"", other - margin)
                     .Append(""Or greater than"", other + margin)
                     .Finish());
            }}

            return assertion;
        }}
";
}
