namespace AssertNet.Core.AssertionTypes.Void;

/// <summary>
/// Class representing assertions made on actions.
/// </summary>
/// <seealso cref="IAssertion" />
[SuppressMessage("Design", "CA1031", Justification = "Needed for the library functionality.")]
public class VoidAssertion : Assertion<VoidAssertion, Action>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoidAssertion"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="action">The action under test.</param>
    public VoidAssertion(IFailureHandler failureHandler, Action action)
        : base(failureHandler, action)
    {
        Action = action;
    }

    /// <summary>
    /// Gets the action under test.
    /// </summary>
    /// <value>
    /// The action under test.
    /// </value>
    public Action Action { get; }

    /// <summary>
    /// Assert that the action does not throw any exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public VoidAssertion DoesNotThrowException(string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            this.Fail(new FailureBuilder("DoesNotThrowException()")
                .Append(message)
                .Append("Expecting", Action)
                .Append("Not to throw an exception")
                .Append("But threw", e)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of a specific type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the exception which may not be thrown.</typeparam>
    /// <returns>The current assertion.</returns>
    public VoidAssertion DoesNotThrowException<T>(string? message = null)
        where T : Exception => DoesNotThrowException(typeof(T), message);

    /// <summary>
    /// Assert that the action does not throw an exception of a specific type.
    /// </summary>
    /// <param name="t">Type of the exception which may not be thrown.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public VoidAssertion DoesNotThrowException(Type t, string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType().IsSubclassOf(t) || e.GetType() == t)
            {
                this.Fail(new FailureBuilder("DoesNotThrowException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("Not to throw an exception of type", t)
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return this;
    }

    /// <summary>
    /// Assert that the action does not throw an exception of an exact type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the exception which may not be thrown.</typeparam>
    /// <returns>The current assertion.</returns>
    public VoidAssertion DoesNotThrowExactlyException<T>(string? message = null)
        where T : Exception => DoesNotThrowExactlyException(typeof(T), message);

    /// <summary>
    /// Assert that the action does not throw an exception of an exact type.
    /// </summary>
    /// <param name="t">Type of the exception which may not be thrown.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public VoidAssertion DoesNotThrowExactlyException(Type t, string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType() == t)
            {
                this.Fail(new FailureBuilder("DoesNotThrowExactlyException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("Not to throw an exception exactly of type", t)
                    .Append("But threw", e)
                    .Finish());
            }
        }

        return this;
    }

    /// <summary>
    /// Assert that the action throws some exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public IAssertion<Exception> ThrowsException(string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            return new Assertion<Exception>(FailureHandler, e);
        }

        this.Fail(new FailureBuilder("ThrowsException()")
                .Append(message)
                .Append("Expecting", Action)
                .Append("To throw an exception, but nothing was thrown")
                .Finish());

        return new Assertion<Exception>(FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws a specific exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Exception type to expect.</typeparam>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public IAssertion<T> ThrowsException<T>(string? message = null)
        where T : Exception
    {
        try
        {
            Action.Invoke();
        }
        catch (T e)
        {
            return new Assertion<T>(FailureHandler, e);
        }
        catch (Exception e)
        {
            this.Fail(new FailureBuilder("ThrowsException()")
                .Append(message)
                .Append("Expecting", Action)
                .Append("To throw an exception of type", typeof(T))
                .Append("But threw", e)
                .Finish());
            return new Assertion<T>(FailureHandler, null!);
        }

        this.Fail(new FailureBuilder("ThrowsException()")
            .Append(message)
            .Append("Expecting", Action)
            .Append("To throw an exception of type", typeof(T))
            .Finish());

        return new Assertion<T>(FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws a specific exception.
    /// </summary>
    /// <param name="t">Exception type to expect.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public IAssertion<Exception> ThrowsException(Type t, string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType().IsSubclassOf(t) || e.GetType() == t)
            {
                return new Assertion<Exception>(FailureHandler, e);
            }
            else
            {
                this.Fail(new FailureBuilder("ThrowsException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("To throw an exception of type", t)
                    .Append("But threw", e)
                    .Finish());
                return new Assertion<Exception>(FailureHandler, null!);
            }
        }

        this.Fail(new FailureBuilder("ThrowsException()")
            .Append(message)
            .Append("Expecting", Action)
            .Append("To throw an exception of type", t)
            .Finish());

        return new Assertion<Exception>(FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws exactly a specific exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Exception type to expect.</typeparam>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public IAssertion<T> ThrowsExactlyException<T>(string? message = null)
        where T : Exception
    {
        try
        {
            Action.Invoke();
        }
        catch (T e) when (e.GetType() == typeof(T))
        {
            return new Assertion<T>(FailureHandler, e);
        }
        catch (Exception e)
        {
            this.Fail(new FailureBuilder("ThrowsExactlyException()")
                .Append(message)
                .Append("Expecting", Action)
                .Append("To throw an exception exactly of type", typeof(T))
                .Append("But threw", e)
                .Finish());

            return new Assertion<T>(FailureHandler, null!);
        }

        this.Fail(new FailureBuilder("ThrowsExactlyException()")
            .Append(message)
            .Append("Expecting", Action)
            .Append("To throw an exception exactly of type", typeof(T))
            .Append("But no exception was thrown")
            .Finish());

        return new Assertion<T>(FailureHandler, null!);
    }

    /// <summary>
    /// Assert that the action throws exactly a specific exception.
    /// </summary>
    /// <param name="t">Exception type to expect.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the thrown exception.</returns>
    public IAssertion<Exception> ThrowsExactlyException(Type t, string? message = null)
    {
        try
        {
            Action.Invoke();
        }
        catch (Exception e)
        {
            if (e.GetType() == t)
            {
                return new Assertion<Exception>(FailureHandler, e);
            }
            else
            {
                this.Fail(new FailureBuilder("ThrowsExactlyException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("To throw an exception exactly of type", t)
                    .Append("But threw", e)
                    .Finish());
                return new Assertion<Exception>(FailureHandler, null!);
            }
        }

        this.Fail(new FailureBuilder("ThrowsExactlyException()")
            .Append(message)
            .Append("Expecting", Action)
            .Append("To throw an exception exactly of type", t)
            .Append("But no exception was thrown")
            .Finish());

        return new Assertion<Exception>(FailureHandler, null!);
    }
}
