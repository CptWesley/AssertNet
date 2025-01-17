using AssertNet.SourceGenerator.Assertions;

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
            .AppendLine("#nullable enable")
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

        var attributes = type
            .GetAttributes()
            .Select(GetGenerationAttributeType)
            .OfType<INamedTypeSymbol>();

        foreach (var attribute in attributes)
        {
            GenerateFor(sb, attribute);
        }

        sb
            .AppendLine($"    }}")
            .AppendLine($"}}");
        return sb.ToString();
    }

    [Pure]
    private static ITypeSymbol? GetGenerationAttributeType(AttributeData attribute)
    {
        if (!IsGenerationAttribute(attribute))
        {
            return null;
        }

        if (attribute.AttributeClass?.TypeArguments is { Length: 1 } typeArgs)
        {
            return typeArgs[0];
        }

        if (attribute.ConstructorArguments is { Length: 1 } consArgs)
        {
            return consArgs[0].Value as ITypeSymbol;
        }

        return null;
    }

    private static void GenerateFor(StringBuilder sb, ITypeSymbol type)
    {
        var name = GetSafeName(type);

        foreach (var assertion in Assertion.All.Where(a => a.IsApplicableFor(type)))
        {
            var code = assertion.GetCode(name);
            sb.AppendLine(code);
        }
    }

    [Pure]
    private static string GetSafeName(ITypeSymbol type)
        => type.SpecialType switch
        {
            SpecialType.System_Boolean => $"global::System.Boolean",
            SpecialType.System_Byte => $"global::System.Byte",
            SpecialType.System_SByte => $"global::System.SByte",
            SpecialType.System_UInt16 => $"global::System.UInt16",
            SpecialType.System_Int16 => $"global::System.Int16",
            SpecialType.System_UInt32 => $"global::System.UInt32",
            SpecialType.System_Int32 => $"global::System.Int32",
            SpecialType.System_UInt64 => $"global::System.UInt64",
            SpecialType.System_Int64 => $"global::System.Int64",
            SpecialType.System_Single => $"global::System.Single",
            SpecialType.System_Double => $"global::System.Double",
            SpecialType.System_Decimal => $"global::System.Decimal",
            SpecialType.System_Object => $"global::System.Object",
            SpecialType.System_Char => $"global::System.Char",
            SpecialType.System_IntPtr => $"global::System.IntPtr",
            SpecialType.System_UIntPtr => $"global::System.UIntPtr",
            SpecialType.System_String => $"global::Stystem.String",
            SpecialType.None => $"global::{type}",
            _ => type.ToString(),
        };
}
