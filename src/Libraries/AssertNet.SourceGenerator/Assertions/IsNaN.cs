namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsNaN assertion.
/// </summary>
internal sealed class IsNaN() : StaticBooleanMethodAssertion("IsNaN")
{
    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is not-a-number (NaN).</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNaN<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsNaN(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNaN()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be not-a-number (NaN)"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not not-a-number (NaN).</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotNaN<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsNaN(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotNaN()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be non-a-number (NaN)"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
