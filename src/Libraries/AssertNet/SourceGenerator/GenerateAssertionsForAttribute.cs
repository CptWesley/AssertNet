namespace AssertNet.SourceGenerator;

/// <summary>
/// Indicates assertions should be generated for the given type.
/// </summary>
/// <param name="type">The type for which assertions should be generated.</param>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
[Inheritable]
public class GenerateAssertionsForAttribute(Type type) : Attribute
{
    /// <summary>
    /// The type for which assertions should be generated.
    /// </summary>
    public Type Type { get; } = type;
}

/// <summary>
/// Indicates assertions should be generated for the given type.
/// </summary>
/// <typeparam name="T">The type for which assertions should be generated.</typeparam>
[AttributeUsage(AttributeTargets.Class, AllowMultiple = true, Inherited = false)]
public sealed class GenerateAssertionsForAttribute<T>() : GenerateAssertionsForAttribute(typeof(T));
