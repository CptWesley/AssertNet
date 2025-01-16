using AssertNet.AssertionTypes;
using System.Reflection;

namespace AssertNet;

/// <summary>
/// Class representing assertions made on thrown exceptions.
/// </summary>
public static class ExceptionAssertions
{
    /// <summary>
    /// Asserts that an exception has a certain message.
    /// </summary>
    /// <param name="message">The message which the exception should have.</param>
    /// <param name="customMessage">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert WithMessage<TAssert>(this TAssert assertion, string message, string? customMessage = null)
        where TAssert : IAssertion<Exception>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("WithMessage()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have the message", message)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.Message != message)
        {
            assertion.Fail(new FailureBuilder("WithMessage()")
                .Append(customMessage)
                .Append("Expecting", assertion.Subject)
                .Append("To have the message", message)
                .Append("But has the message", assertion.Subject.Message)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that an exception has a message containing the given string.
    /// a certain string.
    /// </summary>
    /// <param name="message">Part of the message which the exception should have.</param>
    /// <param name="customMessage">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert WithMessageContaining<TAssert>(this TAssert assertion, string message, string? customMessage = null)
        where TAssert : IAssertion<Exception>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("WithMessageContaining()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have a message containing", message)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.Message?.Contains(message) is not true)
        {
            assertion.Fail(new FailureBuilder("WithMessageContaining()")
                .Append(customMessage)
                .Append("Expecting", assertion.Subject)
                .Append("To have a message containing", message)
                .Append("But has the message", assertion.Subject.Message)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that an exception has no inner exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert WithNoInnerException<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<Exception>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("WithNoInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To not have an inner exception")
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.InnerException != null)
        {
            assertion.Fail(new FailureBuilder("WithNoInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To not have an inner exception")
                .Append("But has", assertion.Subject.InnerException)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Asserts that an exception has an inner exception.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An exception assertion for the inner exception.</returns>
    public static IAssertion<Exception> WithInnerException(this IAssertion<Exception> assertion, string? message = null)
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have an inner exception, but is null")
                .Finish());
        }
        else if (assertion.Subject.InnerException is null)
        {
            assertion.Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have an inner exception, but has none")
                .Finish());
        }

        return new Assertion<Exception>(assertion.FailureHandler, assertion.Subject.InnerException);
    }

    /// <summary>
    /// Asserts that an exception has an inner exception with a specific type..
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type of the inner exception.</typeparam>
    /// <returns>An exception assertion for the inner exception.</returns>
    public static IAssertion<TInnerException> WithInnerException<TInnerException>(this IAssertion<Exception> assertion, string? message = null)
        where TInnerException : Exception
    {
        TInnerException inner = null!;

        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have an inner exception, but is null")
                .Finish());
        }
        else if (assertion.Subject.InnerException == null)
        {
            assertion.Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have an inner exception, but has none")
                .Finish());
        }
        else if (assertion.Subject.InnerException is not TInnerException inner2)
        {
            assertion.Fail(new FailureBuilder("WithInnerException()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have an inner exception of type", typeof(TInnerException))
                .Append("But has an inner exception of type", assertion.Subject.InnerException.GetType())
                .Finish());
        }
        else
        {
            inner = inner2;
        }

        return new Assertion<TInnerException>(assertion.FailureHandler, inner);
    }
}
