namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsInfinity assertion.
/// </summary>
internal sealed class IsInfinity() : StaticBooleanMethodAssertion("IsInfinity")
{
    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => $@"
        /// <summary>Ensures that the number under test is infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (!{name}.IsInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To be infinity"")
                     .Finish());
            }}

            return assertion;
        }}

        /// <summary>Ensures that the number under test is not infinity.</summary>
        /// <typeparam name=""TAssert"">The type of the assertion.</typeparam>
        /// <param name=""assertion"">The original assertion chain.</param>
        /// <param name=""message"">The assertion message.</param>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsNotInfinity<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if ({name}.IsInfinity(assertion.Subject))
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.FailureBuilder(""IsNotInfinity()"")
                     .Append(message)
                     .Append(""Expecting"", assertion.Subject)
                     .Append(""To not be infinity"")
                     .Finish());
            }}

            return assertion;
        }}
";
}
