using AssertNet.Core.Failures;
using NUnit.Framework;

namespace AssertNet.NUnit
{
    /// <summary>
    /// Failure handler for NUnit.
    /// </summary>
    /// <seealso cref="IFailureHandler" />
    public class NUnitFailureHandler : IFailureHandler
    {
        /// <summary>
        /// Creates an assertion failure with a certain message.
        /// </summary>
        /// <param name="message">The message of the assertion failure.</param>
        public void Fail(string message)
        {
            throw new AssertionException(message);
        }
    }
}
