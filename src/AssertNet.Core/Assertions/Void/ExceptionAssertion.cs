using System;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;

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
        /// Asserts that an exception has a message containing
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
    }
}
