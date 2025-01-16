namespace AssertNet.Diagnostics;

/// <summary>Indicates that the method checks an assertion.</summary>
[AttributeUsage(AttributeTargets.Method, AllowMultiple = false, Inherited = false)]
internal sealed class AssertionAttribute(string? justification = null) : ImpureAttribute(justification) { }
