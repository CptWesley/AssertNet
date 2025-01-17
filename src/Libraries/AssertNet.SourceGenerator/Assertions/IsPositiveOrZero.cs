namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsPositiveOrZero assertion.
/// </summary>
internal sealed class IsPositiveOrZero() : StaticBooleanMethodAssertion("IsPositive")
{
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
            if (!{name}.IsPositive(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsPositive()"")
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
            if ({name}.IsPositive(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotPositive()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be a positive number or zero"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
