namespace AssertNet.Core.FailureHandlers
{
    /// <summary>
    /// Interface for failure handlers.
    /// </summary>
    public interface IFailureHandler
    {
        /// <summary>
        /// Creates an assertion failure with a certain message.
        /// </summary>
        /// <param name="message">The message of the assertion failure.</param>
        void Fail(string message);
    }
}
