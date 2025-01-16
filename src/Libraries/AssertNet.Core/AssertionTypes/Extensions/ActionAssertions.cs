namespace AssertNet.Core.AssertionTypes.Void;

/// <summary>
/// Class representing assertions made on actions.
/// </summary>
/// <seealso cref="IAssertion" />
public static class ActionAssertions
{
    /// <summary>
    /// Assert that the action does not throw any exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotThrowException<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<Action>
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            assertion.Fail(new FailureBuilder("DoesNotThrowException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to throw an exception")
                .Append("But threw", e)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of a specific type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the exception which may not be thrown.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion<Action> DoesNotThrowException<T>(this IAssertion<Action> assertion, string? message = null)
        where T : Exception
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (typeof(T).IsAssignableFrom(e.GetType()))
            {
                assertion.Fail(new FailureBuilder("DoesNotThrowException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("Not to throw an exception of type", typeof(T))
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return assertion;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of a specific type.
    /// </summary>
    /// <param name="t">Type of the exception which may not be thrown.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotThrowException<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion<Action>
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (t.IsAssignableFrom(e.GetType()))
            {
                assertion.Fail(new FailureBuilder("DoesNotThrowException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("Not to throw an exception of type", t)
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return assertion;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of an exact type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the exception which may not be thrown.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion<Action> DoesNotThrowExactlyException<T>(this IAssertion<Action> assertion, string? message = null)
        where T : Exception
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType() == typeof(T))
            {
                assertion.Fail(new FailureBuilder("DoesNotThrowExactlyException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("Not to throw an exception exactly of type", typeof(T))
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return assertion;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of an exact type.
    /// </summary>
    /// <param name="t">Type of the exception which may not be thrown.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotThrowExactlyException<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion<Action>
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType() == t)
            {
                assertion.Fail(new FailureBuilder("DoesNotThrowExactlyException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("Not to throw an exception exactly of type", t)
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return assertion;
    }

    /// <summary>
    /// Assert that the action throws some exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public static IAssertion<Exception> ThrowsException(this IAssertion<Action> assertion, string? message = null)
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            return new Assertion<Exception>(assertion.FailureHandler, e);
        }

        assertion.Fail(new FailureBuilder("ThrowsException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To throw an exception, but nothing was thrown")
                .Finish());

        return new Assertion<Exception>(assertion.FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws a specific exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Exception type to expect.</typeparam>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public static IAssertion<T> ThrowsException<T>(this IAssertion<Action> assertion, string? message = null)
        where T : Exception
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (T e)
        {
            return new Assertion<T>(assertion.FailureHandler, e);
        }
        catch (Exception e)
        {
            assertion.Fail(new FailureBuilder("ThrowsException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To throw an exception of type", typeof(T))
                .Append("But threw", e)
                .Finish());
            return new Assertion<T>(assertion.FailureHandler, null!);
        }

        assertion.Fail(new FailureBuilder("ThrowsException()")
            .Append(message)
            .Append("Expecting", assertion.Subject)
            .Append("To throw an exception of type", typeof(T))
            .Finish());

        return new Assertion<T>(assertion.FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws a specific exception.
    /// </summary>
    /// <param name="t">Exception type to expect.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public static IAssertion<Exception> ThrowsException(this IAssertion<Action> assertion, Type t, string? message = null)
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType().IsSubclassOf(t) || e.GetType() == t)
            {
                return new Assertion<Exception>(assertion.FailureHandler, e);
            }
            else
            {
                assertion.Fail(new FailureBuilder("ThrowsException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("To throw an exception of type", t)
                    .Append("But threw", e)
                    .Finish());
                return new Assertion<Exception>(assertion.FailureHandler, null!);
            }
        }

        assertion.Fail(new FailureBuilder("ThrowsException()")
            .Append(message)
            .Append("Expecting", assertion.Subject)
            .Append("To throw an exception of type", t)
            .Finish());

        return new Assertion<Exception>(assertion.FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws exactly a specific exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Exception type to expect.</typeparam>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public static IAssertion<T> ThrowsExactlyException<T>(this IAssertion<Action> assertion, string? message = null)
        where T : Exception
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (T e) when (e.GetType() == typeof(T))
        {
            return new Assertion<T>(assertion.FailureHandler, e);
        }
        catch (Exception e)
        {
            assertion.Fail(new FailureBuilder("ThrowsExactlyException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To throw an exception exactly of type", typeof(T))
                .Append("But threw", e)
                .Finish());

            return new Assertion<T>(assertion.FailureHandler, null!);
        }

        assertion.Fail(new FailureBuilder("ThrowsExactlyException()")
            .Append(message)
            .Append("Expecting", assertion.Subject)
            .Append("To throw an exception exactly of type", typeof(T))
            .Append("But no exception was thrown")
            .Finish());

        return new Assertion<T>(assertion.FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws exactly a specific exception.
    /// </summary>
    /// <param name="t">Exception type to expect.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public static IAssertion<Exception> ThrowsExactlyException(this IAssertion<Action> assertion, Type t, string? message = null)
    {
        try
        {
            assertion.Subject.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType() == t)
            {
                return new Assertion<Exception>(assertion.FailureHandler, e);
            }
            else
            {
                assertion.Fail(new FailureBuilder("ThrowsExactlyException()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("To throw an exception exactly of type", t)
                    .Append("But threw", e)
                    .Finish());
                return new Assertion<Exception>(assertion.FailureHandler, null!);
            }
        }

        assertion.Fail(new FailureBuilder("ThrowsExactlyException()")
            .Append(message)
            .Append("Expecting", assertion.Subject)
            .Append("To throw an exception exactly of type", t)
            .Append("But no exception was thrown")
            .Finish());

        return new Assertion<Exception>(assertion.FailureHandler, null!);
    }
}
