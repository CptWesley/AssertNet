namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Base class for assertions of static boolean methods.
/// </summary>
/// <param name="name">The name of the method.</param>
internal abstract class StaticBooleanMethodAssertion(string name) : Assertion
{
    /// <summary>
    /// The name of the method.
    /// </summary>
    public string Name { get; } = name;

    /// <inheritdoc />
    [Pure]
    public override bool Applies(ITypeSymbol type, IMethodSymbol method)
        => method.IsStatic
        && method.Parameters.Length == 1
        && (method.Name == Name || method.Name.EndsWith($".{Name}"))
        && method.ReturnType.SpecialType is SpecialType.System_Boolean
        && SymbolEqualityComparer.Default.Equals(method.Parameters[0].Type, type);
}
