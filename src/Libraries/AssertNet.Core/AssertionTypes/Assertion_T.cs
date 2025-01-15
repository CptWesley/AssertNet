namespace AssertNet.Core.AssertionTypes;

public abstract class Assertion<TSubject> : Assertion
{
    protected Assertion(TSubject subject, IFailureHandler failureHandler) : base(failureHandler)
    {
        Subject = subject;
    }

    /// <summary>The subject under test.</summary>
    public TSubject Subject { get; }

    public void Fails(string message) => Fail(message);
}
