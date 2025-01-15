namespace AssertNet.FailureHandlers;

/// <summary>
/// Creates a <see cref="IFailureHandler"/> instance based on the available frameworks.
/// </summary>
public static class FailureHandlerFactory
{
    private static Lazy<IFailureHandler> lazyHandler = new(CreateInternal);

    /// <summary>
    /// Creates a <see cref="IFailureHandler"/> instance based on the avaiable testing frameworks.
    /// </summary>
    /// <returns>A new <see cref="IFailureHandler"/> instance.</returns>
    public static IFailureHandler Create()
        => lazyHandler.Value;

    private static IFailureHandler CreateInternal()
    {
        var types = typeof(FailureHandlerFactory).Assembly.GetTypes()
            .Where(t => typeof(IFailureHandler).IsAssignableFrom(t) && !t.IsAbstract && t != typeof(FallbackFailureHandler));
        foreach (Type type in types)
        {
            var handler = (IFailureHandler)Activator.CreateInstance(type);

            if (handler.IsAvailable())
            {
                return handler;
            }
        }

        return new FallbackFailureHandler();
    }
}
