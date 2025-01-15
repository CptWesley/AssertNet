namespace AssertNet.FailureHandlers;

/// <summary>
/// General exception failure handler.
/// </summary>
/// <seealso cref="IFailureHandler" />
public abstract class ExceptionFailureHandler : IFailureHandler
{
    private readonly Type? exceptionType;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionFailureHandler"/> class.
    /// </summary>
    /// <param name="assemblyName">Name of the assembly.</param>
    /// <param name="exceptionName">Name of the exception.</param>
    protected ExceptionFailureHandler(string assemblyName, string exceptionName)
    {
        if (TryLoadAssembly(assemblyName, out var assembly))
        {
            exceptionType = assembly.GetType(exceptionName);
        }
    }

    /// <inheritdoc/>
    [DoesNotReturn]
    public void Fail(string message)
    {
        Exception? ex = null;
        if (exceptionType is { })
        {
            ex = Activator.CreateInstance(exceptionType, message) as Exception;
        }

        ex ??= new Exception(message);
        throw ex;
    }

    /// <inheritdoc/>
    public bool IsAvailable()
        => exceptionType != null;

    [SuppressMessage("Microsoft.Design", "CA1031", Justification = "We don't really care about the reason why it's not available.")]
    private static bool TryLoadAssembly(string assemblyName, [MaybeNullWhen(false)] out Assembly assembly)
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
