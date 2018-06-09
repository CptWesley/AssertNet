using System;
using AssertNet.Core.FailureHandlers;

namespace AssertNet.Core.Assertions.Void
{
    /// <summary>
    /// Class representing assertions made on thrown exceptions.
    /// </summary>
    /// <seealso cref="Assertion" />
    public class ExceptionAssertion : Assertion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ExceptionAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler.</param>
        /// <param name="exception">The exception.</param>
        public ExceptionAssertion(IFailureHandler failureHandler, Exception exception)
            : base(failureHandler)
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
    }
}
