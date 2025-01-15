namespace AssertNet.FailureHandlers
{
    /// <summary>
    /// Handles failures when running NUnit.
    /// </summary>
    /// <seealso cref="ExceptionFailureHandler" />
    public class NunitFailureHandler : ExceptionFailureHandler
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="NunitFailureHandler"/> class.
        /// </summary>
        public NunitFailureHandler()
            : base("nunit.framework", "NUnit.Framework.AssertionException")
        {
        }
    }
}
