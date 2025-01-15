namespace AssertNet;

/// <summary>Extension point for assertions.</summary>
public sealed class AssertionBuilder
{
    /// <summary>Asserts that.</summary>
    public static readonly AssertionBuilder Asserts = new();

    private AssertionBuilder() { }
}
