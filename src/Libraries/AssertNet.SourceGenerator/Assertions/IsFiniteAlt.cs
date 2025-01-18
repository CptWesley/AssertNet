namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsFinite assertion.
/// </summary>
internal sealed class IsFiniteAlt() : Assertion
{
    private static readonly IsFinite IsFinite = new();
    private static readonly IsInfinity IsInfinity = new();
    private static readonly IsNaN IsNaN = new();

    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type)
        => !IsFinite.IsApplicableFor(type)
        && IsInfinity.IsApplicableFor(type)
        && IsNaN.IsApplicableFor(type);

    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is a finite number.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsFinite<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsInfinity(assertion.Subject) || {name}.IsNaN(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsFinite()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be a finite number"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not a finite number.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotFinite<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsInfinity(assertion.Subject) && !{name}.IsNaN(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsNotFinite()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be a finite number"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
