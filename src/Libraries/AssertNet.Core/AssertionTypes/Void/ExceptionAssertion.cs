namespace AssertNet.Core.AssertionTypes.Void;

/// <summary>
/// Class representing assertions made on thrown exceptions.
/// </summary>
/// <seealso cref="Assertion" />
[SuppressMessage("Globalization", "CA1307", Justification = "Build target netstandard2.0 does not support suggested function.")]
public class ExceptionAssertion : ObjectAssertion<ExceptionAssertion, Exception>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ExceptionAssertion"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler.</param>
    /// <param name="exception">The exception.</param>
    public ExceptionAssertion(IFailureHandler failureHandler, Exception exception)
        : base(failureHandler, exception)
    {
    }

    /// <summary>
    /// Asserts that an exception has a certain message.
    /// </summary>
    /// <param name="message">The message which the exception should have.</param>
    /// <param name="customMessage">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public ExceptionAssertion WithMessage(string message, string customMessage = null)
    {
        if (Target.Message != message)
        {
            Fail(new FailureBuilder("WithMessage()")
                .Append(customMessage)
                .Append("Expecting", Target)
                .Append("To have the message", message)
                .Append("But has the message", Target.Message)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Asserts that an exception has a message containing the given string.
    /// a certain string.
    /// </summary>
    /// <param name="message">Part of the message which the exception should have.</param>
    /// <param name="customMessage">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public ExceptionAssertion WithMessageContaining(string message, string customMessage = null)
    {
        if (!Target.Message.Contains(message))
        {
            Fail(new FailureBuilder("WithMessageContaining()")
                .Append(customMessage)
                .Append("Expecting", Target)
                .Append("To have a message containing", message)
                .Append("But has the message", Target.Message)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Asserts that an exception has no inner exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public ExceptionAssertion WithNoInnerException(string message = null)
    {
        if (Target.InnerException != null)
        {
            Fail(new FailureBuilder("WithMessageContaining()")
                .Append(message)
                .Append("Expecting", Target)
                .Append("To not have an inner exception, but has", Target.InnerException)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Asserts that an exception has an inner exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the inner exception.</returns>
    public ExceptionAssertion WithInnerException(string message = null)
    {
        if (Target.InnerException != null)
        {
            return new ExceptionAssertion(FailureHandler, Target.InnerException);
        }

        Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", Target)
                .Append("To have an inner exception, but has none")
                .Finish());
        return null;
    }

    /// <summary>
    /// Asserts that an exception has an inner exception with a specific type..
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the inner exception.</typeparam>
    /// <returns>An exception assertion for the inner exception.</returns>
    public ExceptionAssertion WithInnerException<T>(string message = null)
        where T : Exception
    {
        if (Target.InnerException == null)
        {
            Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", Target)
                .Append("To have an inner exception, but has none")
                .Finish());
            return null;
        }
        else if (!(Target.InnerException is T))
        {
            Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", Target)
                .Append("To have an inner exception of type", typeof(T))
                .Append("But has an inner exception of type", Target.InnerException.GetType())
                .Finish());
            return null;
        }

        return new ExceptionAssertion(FailureHandler, Target.InnerException);
    }
}
