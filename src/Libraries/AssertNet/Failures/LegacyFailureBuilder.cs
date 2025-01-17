namespace AssertNet.Failures;

/// <summary>
/// Class representing an assertion failure text.
/// </summary>
[Obsolete("Use FailureBuilder instead.")]
public class LegacyFailureBuilder
{
    private readonly StringBuilder _builder;

    /// <summary>
    /// Initializes a new instance of the <see cref="LegacyFailureBuilder"/> class.
    /// </summary>
    /// <param name="name">The name of the assertion which failed.</param>
    public LegacyFailureBuilder(string name)
    {
        _builder = new StringBuilder($"{name} Assertion failure");
    }

    /// <summary>
    /// Appends an object line.
    /// </summary>
    /// <typeparam name="T">Type of the object to append.</typeparam>
    /// <param name="objectName">Name of the object.</param>
    /// <param name="part">The object.</param>
    /// <returns>The current <see cref="LegacyFailureBuilder"/> instance.</returns>
    [FluentSyntax]
    public LegacyFailureBuilder Append<T>(string objectName, T? part)
    {
        _builder.Append($"{Environment.NewLine}{objectName}:{Environment.NewLine}{StringOf(part)}");
        return this;
    }

    /// <summary>
    /// Appends the specified line.
    /// </summary>
    /// <param name="line">The line.</param>
    /// <returns>The current <see cref="LegacyFailureBuilder"/> instance.</returns>
    [FluentSyntax]
    public LegacyFailureBuilder Append(string? line)
    {
        if (line != null)
        {
            _builder.Append($"{Environment.NewLine}{line}");
        }

        return this;
    }

    /// <summary>
    /// Appends an enumerable line.
    /// </summary>
    /// <typeparam name="T">Type of the enumerable.</typeparam>
    /// <param name="objectName">Name of the enumerable.</param>
    /// <param name="enumerable">The enumerable.</param>
    /// <returns>The current <see cref="LegacyFailureBuilder"/> instance.</returns>
    [FluentSyntax]
    public LegacyFailureBuilder AppendEnumerable<T>(string objectName, IEnumerable<T> enumerable)
    {
        _builder.Append($"{Environment.NewLine}{objectName}:{Environment.NewLine}[{string.Join(", ", enumerable.Select(StringOf))}]");
        return this;
    }

    /// <inheritdoc cref="AppendEnumerable{T}(string, IEnumerable{T})" />
    [FluentSyntax]
    public LegacyFailureBuilder AppendEnumerable(string objectName, IEnumerable enumerable)
        => AppendEnumerable(objectName, enumerable.AsGeneric());

    /// <summary>
    /// Finishes the FailureBuilder instance.
    /// </summary>
    /// <returns>The assertion error message created.</returns>
    [Pure]
    public string Finish() => _builder.ToString();

    /// <summary>
    /// Gets the string version of an object.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <param name="ob">The object to get the string version of.</param>
    /// <returns>"null" if the object is null. The value of .ToString() otherwise.</returns>
    [Pure]
    private static string StringOf<T>(T? ob)
        => ob?.ToString() is { } str
        ? str
        : "<null>";
}
