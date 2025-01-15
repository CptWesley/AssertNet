using System;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using AssertNet.Core.Failures;

namespace AssertNet.FailureHandlers;

/// <summary>
/// General exception failure handler.
/// </summary>
/// <seealso cref="IFailureHandler" />
public abstract class ExceptionFailureHandler : IFailureHandler
{
    private readonly Type exceptionType;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionFailureHandler"/> class.
    /// </summary>
    /// <param name="assemblyName">Name of the assembly.</param>
    /// <param name="exceptionName">Name of the exception.</param>
    public ExceptionFailureHandler(string assemblyName, string exceptionName)
    {
        if (TryLoadAssembly(assemblyName, out Assembly assembly))
        {
            exceptionType = assembly.GetType(exceptionName);
        }
    }

    /// <inheritdoc/>
    public void Fail(string message)
        => throw Activator.CreateInstance(exceptionType, message) as Exception;

    /// <inheritdoc/>
    public bool IsAvailable()
        => exceptionType != null;

    [SuppressMessage("Microsoft.Design", "CA1031", Justification = "We don't really care about the reason why it's not available.")]
    private static bool TryLoadAssembly(string assemblyName, out Assembly assembly)
    {
        try
        {
            assembly = Assembly.Load(new AssemblyName(assemblyName));
            return assembly != null;
        }
        catch
        {
            assembly = null;
            return false;
        }
    }
}
