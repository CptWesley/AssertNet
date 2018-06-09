namespace AssertNet.Core
{
    /// <summary>
    /// Abstract class representing assertions.
    /// </summary>
    public abstract class Assertion
    {
        /// <summary>
        /// The failure handler of the assertion.
        /// </summary>
        private readonly IFailureHandler _failureHandler;

        /// <summary>
        /// Initializes a new instance of the <see cref="Assertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        public Assertion(IFailureHandler failureHandler)
        {
            _failureHandler = failureHandler;
        }

        /// <summary>
        /// Fails an assertion with a specific message.
        /// </summary>
        /// <param name="message">The message to fail with.</param>
        protected void Fail(string message)
        {
            _failureHandler.Fail(message);
        }
    }
}
