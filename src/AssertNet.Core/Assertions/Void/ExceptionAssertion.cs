using System;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Void
{
    /// <summary>
    /// Class representing assertions made on thrown exceptions.
    /// </summary>
    /// <seealso cref="Assertion" />
    public class ExceptionAssertion : ObjectAssertion<ExceptionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler.</param>
        /// <param name="exception">The exception.</param>
        public ExceptionAssertion(IFailureHandler failureHandler, Exception exception)
            : base(failureHandler, exception)
        {
            Exception = exception;
        }

        /// <summary>
        /// Gets the exception under test.
        /// </summary>
        /// <value>
        /// The exception under test.
        /// </value>
        public Exception Exception { get; }

        /// <summary>
        /// Asserts that an exception has a certain message.
        /// </summary>
        /// <param name="message">The message which the exception should have.</param>
        /// <returns>The current assertion.</returns>
        public ExceptionAssertion WithMessage(string message)
        {
            if (Exception.Message != message)
            {
                Fail(new FailureBuilder("WithMessage()")
                    .Append("Expecting", Target)
                    .Append("To have the message", message)
                    .Append("But has the message", Exception.Message)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts that an exception has a message containing the given string.
        /// a certain string.
        /// </summary>
        /// <param name="message">Part of the message which the exception should have.</param>
        /// <returns>The current assertion.</returns>
        public ExceptionAssertion WithMessageContaining(string message)
        {
            if (!Exception.Message.Contains(message))
            {
                Fail(new FailureBuilder("WithMessageContaining()")
                    .Append("Expecting", Target)
                    .Append("To have a message containing", message)
                    .Append("But has the message", Exception.Message)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts that an exception has no inner exception.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public ExceptionAssertion WithNoInnerException()
        {
            if (Exception.InnerException != null)
            {
                Fail(new FailureBuilder("WithMessageContaining()")
                    .Append("Expecting", Target)
                    .Append("To not have an inner exception, but has", Exception.InnerException)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts that an exception has an inner exception.
        /// </summary>
        /// <returns>An exception assertion for the inner exception.</returns>
        public ExceptionAssertion WithInnerException()
        {
            if (Exception.InnerException != null)
            {
                return new ExceptionAssertion(FailureHandler, Exception.InnerException);
            }

            Fail(new FailureBuilder("WithInnerException()")
                    .Append("Expecting", Target)
                    .Append("To have an inner exception, but has none")
                    .Finish());
            return null;
        }

        /// <summary>
        /// Asserts that an exception has an inner exception with a specific type..
        /// </summary>
        /// <typeparam name="T">Type of the inner exception.</typeparam>
        /// <returns>An exception assertion for the inner exception.</returns>
        public ExceptionAssertion WithInnerException<T>()
            where T : Exception
        {
            if (Exception.InnerException == null)
            {
                Fail(new FailureBuilder("WithInnerException()")
                    .Append("Expecting", Target)
                    .Append("To have an inner exception, but has none")
                    .Finish());
                return null;
            }
            else if (!(Exception.InnerException is T))
            {
                Fail(new FailureBuilder("WithInnerException()")
                    .Append("Expecting", Target)
                    .Append("To have an inner exception of type", typeof(T))
                    .Append("But has an inner exception of type", Exception.InnerException.GetType())
                    .Finish());
                return null;
            }

            return new ExceptionAssertion(FailureHandler, Exception.InnerException);
        }
    }
}
