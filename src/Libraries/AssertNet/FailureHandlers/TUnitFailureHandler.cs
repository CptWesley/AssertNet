namespace AssertNet.FailureHandlers;

/// <summary>
/// Handles failures when running TUnit.
/// </summary>
/// <seealso cref="ExceptionFailureHandler" />
public class TUnitFailureHandler : ExceptionFailureHandler
{
    /// <summary>
    /// Initializes a new instance of the <see cref="TUnitFailureHandler"/> class.
    /// </summary>
    public TUnitFailureHandler()
        : base("TUnit.Assertions", "TUnit.Assertions.Exceptions.AssertionException")
    {
    }
}
