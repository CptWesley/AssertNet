using AssertNet.Core.Failures;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertNet.MSTest
{
    /// <summary>
    /// Failure handler for NUnit.
    /// </summary>
    /// <seealso cref="IFailureHandler" />
    public class MSTestFailureHandler : IFailureHandler
    {
        /// <summary>
        /// Creates an assertion failure with a certain message.
        /// </summary>
        /// <param name="message">The message of the assertion failure.</param>
        public void Fail(string message)
        {
            throw new AssertFailedException(message);
        }
    }
}
