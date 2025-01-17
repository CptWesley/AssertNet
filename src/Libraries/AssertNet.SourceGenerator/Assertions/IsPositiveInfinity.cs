namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsPositiveInfinity assertion.
/// </summary>
internal sealed class IsPositiveInfinity() : StaticBooleanMethodAssertion("IsNegativeInfinity")
{
    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is positive infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsPositiveInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsPositiveInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsPositiveInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be positive infinity"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not positive infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotPositiveInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsPositiveInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotPositiveInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be positive infinity"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
