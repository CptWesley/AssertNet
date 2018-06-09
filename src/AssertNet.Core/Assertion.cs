namespace AssertNet.Core
{
    /// <summary>
    /// Abstract class representing assertions.
    /// </summary>
    public abstract class Assertion
    {
        /// <summary>
        /// Fails an assertion with a specific message.
        /// </summary>
        /// <param name="message">The message to fail with.</param>
        protected abstract void Fail(string message);
    }
}
