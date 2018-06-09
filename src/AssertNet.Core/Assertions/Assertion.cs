using AssertNet.Core.FailureHandlers;

namespace AssertNet.Core.Assertions
{
    /// <summary>
    /// Abstract class representing assertions.
    /// </summary>
    public abstract class Assertion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="Assertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        public Assertion(IFailureHandler failureHandler)
        {
            FailureHandler = failureHandler;
        }

        /// <summary>
        /// Gets the failure handler of the assertion.
        /// </summary>
        public IFailureHandler FailureHandler { get; }

        /// <summary>
        /// Fails an assertion with a specific message.
        /// </summary>
        /// <param name="message">The message to fail with.</param>
        protected void Fail(string message)
        {
            FailureHandler.Fail(message);
        }
    }
}
