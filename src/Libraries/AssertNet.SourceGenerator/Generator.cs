namespace AssertNet.SourceGenerator;

/// <summary>
/// Responsible for generating the output source code.
/// </summary>
[Generator]
internal sealed class Generator : IIncrementalGenerator
{
    /// <inheritdoc />
    public void Initialize(IncrementalGeneratorInitializationContext context)
    {
        var input = GetInput(context);
        context.RegisterSourceOutput(input, TryGenerate);
    }

    [Pure]
    private static IncrementalValuesProvider<INamedTypeSymbol> GetInput(IncrementalGeneratorInitializationContext context)
        => GetInput(context.CompilationProvider);

    [Pure]
    private static IncrementalValuesProvider<INamedTypeSymbol> GetInput(IncrementalValueProvider<Compilation> provider)
        => provider.SelectMany(GetInput);

    [Pure]
    private static IEnumerable<INamedTypeSymbol> GetInput(Compilation compilation, CancellationToken ct)
    {
        ct.ThrowIfCancellationRequested();

        var types = compilation.GetAllTypes(ct);
        var withAttributes = types.Where(HasGenerationAttribute);

        return withAttributes;
    }

    [Pure]
    private static bool HasGenerationAttribute(ITypeSymbol type)
        => type.GetAttributes().Any(IsGenerationAttribute);

    [Pure]
    private static bool IsGenerationAttribute(AttributeData attribute)
    {
        if (attribute.AttributeClass is not { } type)
        {
            return false;
        }

        var name = type.ToString();
        return name.StartsWith("AssertNet.SourceGenerator.GenerateAssertionsForAttribute");
    }

    private static void TryGenerate(SourceProductionContext ctx, INamedTypeSymbol type)
    {
        var content = TryGenerate(type);
        var fileName = $"{type}.g.cs";
        ctx.AddSource(fileName, content);
    }

    [Pure]
    private static string TryGenerate(INamedTypeSymbol type)
    {
        string text;
        try
        {
            text = Generate(type);
        }
        catch (Exception ex)
        {
            text = ex.ToString();
        }

        var sb = new StringBuilder();

        sb
            .AppendLine("// <auto-generated />")
            .AppendLine("#pragma warning disable")
            .AppendLine()
            .AppendLine(text);

        return sb.ToString();
    }

    [Pure]
    private static string Generate(INamedTypeSymbol type)
    {
        var sb = new StringBuilder();
        sb
            .AppendLine($"namespace {type.ContainingNamespace}")
            .AppendLine($"{{")
            .AppendLine($"    public static partial class {type.Name}")
            .AppendLine($"    {{");

        sb
            .AppendLine($"    }}")
            .AppendLine($"}}");
        return sb.ToString();
    }
}
