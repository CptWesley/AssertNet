namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsNegativeInfinity assertion.
/// </summary>
internal sealed class IsNegativeInfinity() : StaticBooleanMethodAssertion("IsNegativeInfinity")
{
    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is negative infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNegativeInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsNegativeInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNegativeInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be negative infinity"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not negative infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotNegativeInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsNegativeInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotNegativeInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be negative infinity"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
