namespace AssertNet.SourceGenerator.Assertions;

/// <summary>
/// Base class for all assertions.
/// </summary>
internal abstract class Assertion
{
    /// <summary>
    /// All assertions.
    /// </summary>
    public static readonly ImmutableArray<Assertion> All
        = typeof(Assertion)
        .Assembly
        .GetTypes()
        .Where(t => t.IsSubclassOf(typeof(Assertion)))
        .Where(t => !t.IsAbstract)
        .Select(t => (Assertion)Activator.CreateInstance(t)!)
        .ToImmutableArray();

    /// <summary>
    /// Checks if assertion applies to <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public virtual bool Applies(ITypeSymbol type)
        => false;

    /// <summary>
    /// Checks if assertion applies to <paramref name="method"/>.
    /// </summary>
    /// <param name="type">The type to check for.</param>
    /// <param name="method">The method to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public virtual bool Applies(ITypeSymbol type, IMethodSymbol method)
        => false;

    /// <summary>
    /// Checks if assertion applies to <paramref name="method"/>.
    /// </summary>
    /// <param name="method">The method to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public virtual bool Applies(IMethodSymbol method)
        => false;

    /// <summary>
    /// Checks if assertion applies to <paramref name="member"/>.
    /// </summary>
    /// <param name="type">The type to check for.</param>
    /// <param name="member">The member to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public virtual bool Applies(ITypeSymbol type, ISymbol member)
        => false;

    /// <summary>
    /// Checks if assertion applies to <paramref name="member"/>.
    /// </summary>
    /// <param name="member">The member to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public virtual bool Applies(ISymbol member)
        => false;

    /// <summary>
    /// Checks if an assertion is applicable in any capacity for the given <paramref name="type"/>.
    /// </summary>
    /// <param name="type">The type to check for.</param>
    /// <returns>
    /// <see langword="true"/> if applies;
    /// <see langword="false"/> otherwise.
    /// </returns>
    [Pure]
    public bool IsApplicableFor(ITypeSymbol type)
    {
        if (Applies(type))
        {
            return true;
        }

        foreach (var member in type.GetMembers())
        {
            if (member is IMethodSymbol method && (Applies(type, method) || Applies(method)))
            {
                return true;
            }

            if (Applies(type, member) || Applies(member))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Gets the method code.
    /// </summary>
    /// <param name="name">The target type.</param>
    /// <returns>The generated code.</returns>
    [Pure]
    public abstract string GetCode(string name);
}
