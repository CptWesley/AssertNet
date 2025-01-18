namespace AssertNet.AssertionTypes;

/// <summary>
/// Class representing assertions made on single objects.
/// </summary>
/// <typeparam name="TSubject">The type of the object under test.</typeparam>
/// <seealso cref="Assertion{TAssert, TSubject}" />
public sealed class Assertion<TSubject> : Assertion<Assertion<TSubject>, TSubject>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Assertion{TSubject}"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="subject">The object which is under test.</param>
    /// <param name="expression">The expression string of the subject, if available.</param>
    public Assertion(IFailureHandler failureHandler, TSubject subject, [CallerArgumentExpression(nameof(subject))] string? expression = null)
        : base(failureHandler, subject, expression)
    {
    }
}
