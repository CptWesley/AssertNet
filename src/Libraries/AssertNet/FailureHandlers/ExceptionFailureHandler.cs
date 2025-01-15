using System.Linq.Expressions;

namespace AssertNet.FailureHandlers;

/// <summary>
/// General exception failure handler.
/// </summary>
/// <seealso cref="IFailureHandler" />
public abstract class ExceptionFailureHandler : IFailureHandler
{
    private static readonly Func<string, Exception> defaultCreateException
        = msg => new AssertionFailedException(msg);

    private readonly Type? exceptionType;
    private readonly Func<string, Exception> createException;

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

        createException = GenerateCreationFunction(exceptionType);
        if (createException == defaultCreateException)
        {
            exceptionType = null;
        }
    }

    private static Func<string, Exception> GenerateCreationFunction(Type? type)
    {
        if (type is null)
        {
            return defaultCreateException;
        }

        var constructor = type
            .GetConstructors()
            .FirstOrDefault(c => c.GetParameters() is { Length: 1 } parameters && parameters[0].ParameterType == typeof(string));

        if (constructor is null)
        {
            return defaultCreateException;

        }

        var arg = Expression.Parameter(typeof(string), "message");
        var create = Expression.New(constructor, arg);
        var func = Expression.Lambda(typeof(Func<string, Exception>), create, arg);
        var compiled = func.Compile();

        if (compiled is not Func<string, Exception> cast)
        {
            return defaultCreateException;
        }

        return cast;
    }

    /// <inheritdoc/>
    [DoesNotReturn]
    public void Fail(string message)
        => throw createException(message);

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
