namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Generates the IsTrue assertion.
/// </summary>
internal sealed class IsTrue : Assertion
{
    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type)
        => type.SpecialType is SpecialType.System_Boolean;

    /// <inheritdoc />
    [Pure]
    public override bool Applies(IMethodSymbol method)
        => method.MethodKind is MethodKind.UserDefinedOperator
        && method.Name is "op_True"
        && method.IsStatic
        && method.Arity == 0
        && method.Parameters.Length == 1
        && method.ReturnType.SpecialType is SpecialType.System_Boolean;

    /// <inheritdoc />
    [Pure]
    public override string GetCode(string name)
        => @$"
        /// <summary>
        /// Asserts that the boolean value is true.
        /// </summary>
        /// <param name=""assertion"">The initial assertion chain.</param>
        /// <param name=""message"">Custom message for the assertion failure.</param>
        /// <typeparam name=""TAssert"">The type of assertion.</typeparam>
        /// <returns>The updated assertion chain.</returns>
        [Assertion]
        public static TAssert IsTrue<TAssert>(this TAssert assertion, global::System.String? message = null)
            where TAssert : global::AssertNet.AssertionTypes.IAssertion<{name}>
        {{
            if (assertion.Subject)
            {{
                return assertion;
            }}
            else
            {{
                assertion.FailureHandler.Fail(new global::AssertNet.Failures.LegacyFailureBuilder(""IsTrue()"")
                    .Append(message)
                    .Append(""Expecting"", assertion.Subject)
                    .Append(""To be equal to"", true)
                    .Finish());
                return assertion;
            }}
        }}";
}
