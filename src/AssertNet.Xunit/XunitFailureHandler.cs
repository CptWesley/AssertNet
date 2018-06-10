using AssertNet.Core.FailureHandlers;
using Xunit.Sdk;

namespace AssertNet.Xunit
{
    /// <summary>
    /// Failure handler for xUnit.
    /// </summary>
    /// <seealso cref="IFailureHandler" />
    public class XunitFailureHandler : IFailureHandler
    {
        /// <summary>
        /// Creates an assertion failure with a certain message.
        /// </summary>
        /// <param name="message">The message of the assertion failure.</param>
        public void Fail(string message)
        {
            throw new XunitException(message);
        }
    }
}
