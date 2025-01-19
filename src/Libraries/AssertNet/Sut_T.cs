namespace AssertNet;

/// <summary>A wrapper around a system/subject under test (SUT).</summary>
/// <typeparam name="TSubject">
/// The type of the subject under test.
/// </typeparam>
/// <seealso cref="Sut{TAssert, TSubject}" />
public sealed class Sut<TSubject> : Sut<Sut<TSubject>, TSubject>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sut{TTarget}"/> class.
    /// </summary>
    /// <param name="failureHandler">
    /// The failure handler of the assertion.
    /// </param>
    /// <param name="subject">
    /// The system/subject under test.
    /// </param>
    /// <param name="expression">
    /// The expression string of the subject, if available.
    /// </param>
    public Sut(IFailureHandler failureHandler, TSubject subject, [CallerArgumentExpression(nameof(subject))] string? expression = null)
        : base(failureHandler, subject, expression)
    {
    }
}
