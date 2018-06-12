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
                Fail($"Expecting message '{message}', but found '{Exception.Message}'.");
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
                Fail($"Expecting '{Exception.Message}' to contain '{message}'.");
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
                Fail($"Expected '{Exception}' not to have an inner exception, but has '{Exception.InnerException}'.");
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

            Fail($"Expected '{Exception}' to have an inner exception, but has '{Exception.InnerException}'.");
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
                Fail($"Expected '{Exception}' to have an inner exception, but has '{Exception.InnerException}'.");
                return null;
            }
            else if (!(Exception.InnerException is T))
            {
                Fail($"Expected '{Exception.InnerException}' to be of type '{typeof(T)}'.");
                return null;
            }

            return new ExceptionAssertion(FailureHandler, Exception.InnerException);
        }
    }
}
