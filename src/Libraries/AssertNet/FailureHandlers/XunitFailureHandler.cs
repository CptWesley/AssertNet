namespace AssertNet.FailureHandlers
{
    /// <summary>
    /// Handles failures when running xUnit.
    /// </summary>
    /// <seealso cref="ExceptionFailureHandler" />
    public class XunitFailureHandler : ExceptionFailureHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="XunitFailureHandler"/> class.
        /// </summary>
        public XunitFailureHandler()
            : base("xunit.assert", "Xunit.Sdk.XunitException")
        {
        }
    }
}
