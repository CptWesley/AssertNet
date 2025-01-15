namespace AssertNet.FailureHandlers;

/// <summary>
/// Handles failures when running MSTest.
/// </summary>
/// <seealso cref="ExceptionFailureHandler" />
public class MsTestFailureHandler : ExceptionFailureHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MsTestFailureHandler"/> class.
    /// </summary>
    public MsTestFailureHandler()
        : base("Microsoft.VisualStudio.TestPlatform.TestFramework", "Microsoft.VisualStudio.TestTools.UnitTesting.AssertFailedException")
    {
    }
}
