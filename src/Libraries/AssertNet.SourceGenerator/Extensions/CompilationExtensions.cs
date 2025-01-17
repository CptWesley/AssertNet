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

    /// <summary>
    /// Determines if something is a numeric type.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool IsNumericType(this ITypeSymbol type)
        => type.SpecialType switch
        {
            SpecialType.System_Byte => true,
            SpecialType.System_SByte => true,
            SpecialType.System_UInt16 => true,
            SpecialType.System_Int16 => true,
            SpecialType.System_UInt32 => true,
            SpecialType.System_Int32 => true,
            SpecialType.System_UInt64 => true,
            SpecialType.System_Int64 => true,
            SpecialType.System_Single => true,
            SpecialType.System_Double => true,
            SpecialType.System_Decimal => true,
            SpecialType.System_IntPtr => true,
            SpecialType.System_UIntPtr => true,
            _ => type.ToString() switch
            {
                "System.Numerics.BigInteger" => true,
                _ => false,
            },
        };

    /// <summary>
    /// Checks if the type defines the given arithmetic operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <param name="op">The operator name.</param>
    /// <param name="arity">The operator arity.</param>
    /// <param name="specialType">The special return type if any.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesOperator(this ITypeSymbol type, string op, int arity, SpecialType? specialType = null)
        => type.GetMembers()
        .OfType<IMethodSymbol>()
        .Where(m => m.Name == op || m.Name.EndsWith($".{op}"))
        .Where(m => m.IsStatic)
        .Where(m => m.Arity == 0)
        .Where(m => m.Parameters.Length == arity)
        .Where(m => m.Parameters.All(p => SymbolEqualityComparer.Default.Equals(p.Type, type)))
        .Any(m =>
        {
            if (specialType is { } st)
            {
                return m.ReturnType.SpecialType == st;
            }
            else
            {
                return SymbolEqualityComparer.Default.Equals(m.ReturnType, type);
            }
        });

    /// <summary>
    /// Checks if the type defines the addition operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesAddition(this ITypeSymbol type)
        => type.DefinesOperator("op_Addition", 2);

    /// <summary>
    /// Checks if the type defines the subtraction operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesSubtraction(this ITypeSymbol type)
        => type.DefinesOperator("op_Subtraction", 2);

    /// <summary>
    /// Checks if the type defines the subtraction operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesGreaterThan(this ITypeSymbol type)
        => type.DefinesOperator("op_GreaterThan", 2, SpecialType.System_Boolean);

    /// <summary>
    /// Checks if the type defines the subtraction operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesLessThan(this ITypeSymbol type)
        => type.DefinesOperator("op_LessThan", 2, SpecialType.System_Boolean);

    /// <summary>
    /// Checks if the type defines the minus operator.
    /// </summary>
    /// <param name="type">The type.</param>
    /// <returns>True/false.</returns>
    [Pure]
    public static bool DefinesMinus(this ITypeSymbol type)
        => type.DefinesOperator("op_UnaryNegation", 1);
}
