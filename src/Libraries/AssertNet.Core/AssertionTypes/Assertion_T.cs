namespace AssertNet.Core.AssertionTypes;

public class Assertion<TSubject> : Assertion
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Assertion{TSubject}"/> class.
    /// </summary>
    /// <param name="subject">The object which is under test.</param>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    public Assertion(IFailureHandler failureHandler, TSubject subject)
        : base(failureHandler, subject)
    {
        Subject = subject;
    }

    /// <summary>
    /// Gets the object under test.
    /// </summary>
    /// <value>
    /// The object under test.
    /// </value>
    public new TSubject Subject { get; }
}
