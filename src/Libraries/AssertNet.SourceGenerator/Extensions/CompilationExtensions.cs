namespace AssertNet.SourceGenerator.Extensions;

/// <summary>
/// Provides extension methods for <see cref="Compilation"/> instances.
/// </summary>
public static class CompilationExtensions
{
    /// <summary>
    /// Retrieves all namespaces in the given <paramref name="compilation"/>.
    /// </summary>
    /// <param name="compilation">The compilation instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found set of namespaces.</returns>
    [Pure]
    public static ImmutableArray<INamespaceSymbol> GetNamespaces(this Compilation compilation, CancellationToken cancellationToken = default)
    {
        var seen = new HashSet<INamespaceSymbol>(SymbolEqualityComparer.Default);
        var visit = new Queue<INamespaceSymbol>();
        visit.Enqueue(compilation.GlobalNamespace);

        do
        {
            cancellationToken.ThrowIfCancellationRequested();
            INamespaceSymbol search = visit.Dequeue();
            seen.Add(search);

            foreach (INamespaceSymbol? space in search.GetNamespaceMembers())
            {
                if (space == null || seen.Contains(space))
                {
                    continue;
                }

                visit.Enqueue(space);
            }
        } while (visit.Count > 0);

        return seen.ToImmutableArray();
    }

    /// <summary>
    /// Retrieves all types in the given <paramref name="compilation"/>.
    /// </summary>
    /// <param name="compilation">The compilation instance.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found set of types.</returns>
    [Pure]
    public static ImmutableArray<INamedTypeSymbol> GetAllTypes(this Compilation compilation, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();

        var seen = new HashSet<INamedTypeSymbol>(SymbolEqualityComparer.Default);
        foreach (var ns in compilation.GetNamespaces(cancellationToken))
        {
            cancellationToken.ThrowIfCancellationRequested();

            foreach (var r in ns.GetAllTypes(cancellationToken))
            {
                seen.Add(r);
            }
        }

        return seen.ToImmutableArray();
    }

    /// <summary>
    /// Gets all defined types in the given <paramref name="symbol"/>.
    /// </summary>
    /// <param name="symbol">The namespace symbol.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>The found set of types.</returns>
    [Pure]
    public static ImmutableArray<INamedTypeSymbol> GetAllTypes(this INamespaceSymbol symbol, CancellationToken cancellationToken = default)
        => symbol.GetTypeMembers()
        .SelectMany(x => x.AllNestedTypesAndSelf(cancellationToken))
        .ToImmutableArray();

    [Pure]
    private static IEnumerable<INamedTypeSymbol> AllNestedTypesAndSelf(this INamedTypeSymbol symbol, CancellationToken cancellationToken = default)
    {
        cancellationToken.ThrowIfCancellationRequested();
        yield return symbol;
        foreach (var typeMember in symbol.GetTypeMembers())
        {
            foreach (var nestedType in typeMember.AllNestedTypesAndSelf(cancellationToken))
            {
                cancellationToken.ThrowIfCancellationRequested();
                yield return nestedType;
            }
        }
    }
}
