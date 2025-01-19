using AssertNet.AssertionTypes;

namespace AssertNet;

/// <summary>A wrapper around a system/subject under test (SUT).</summary>
/// <typeparam name="TAssert">
/// Derived type of the assertion.
/// </typeparam>
/// <typeparam name="TSubject">
/// The type of the subject under test.
/// </typeparam>
/// <summary>
/// Abstract class representing assertions of objects.
/// </summary>
/// <seealso cref="IAssertion" />
public abstract class Sut<TAssert, TSubject> : IAssertion<TAssert, TSubject>
    where TAssert : Sut<TAssert, TSubject>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Sut{TAssert, TTarget}"/> class.
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
    protected Sut(IFailureHandler failureHandler, TSubject subject, string? expression)
    {
        FailureHandler = failureHandler;
        Subject = subject;
        Expression = expression;
    }

    /// <inheritdoc />
    public TSubject Subject { get; }

    /// <inheritdoc />
    object? IAssertion.Subject => Subject;

    /// <inheritdoc />
    public string? Expression { get; }

    /// <inheritdoc />
    public IFailureHandler FailureHandler { get; }

    /// <inheritdoc cref="ObjectAssertions.IsNotInstanceOf{TAssert}(TAssert, Type, string?)" />
    [Assertion]
    public TAssert IsNotInstanceOf<T>(string? message = null)
        => (TAssert)ObjectAssertions.IsNotInstanceOf<T>(this, message);

    /// <inheritdoc cref="ObjectAssertions.IsNotExactlyInstanceOf{TAssert}(TAssert, Type, string?)" />
    [Assertion]
    public TAssert IsNotExactlyInstanceOf<T>(string? message = null)
        => (TAssert)ObjectAssertions.IsNotExactlyInstanceOf<T>(this, message);

    /// <inheritdoc cref="ObjectAssertions.Satisfies{TSubject}(IAssertion{TSubject}, Func{TSubject, bool}, string?)" />
    [Assertion]
    public TAssert Satisfies(Func<TSubject, bool> condition, string? message = null)
        => (TAssert)ObjectAssertions.Satisfies(this, condition, message);

    /// <inheritdoc cref="ObjectAssertions.DoesNotSatisfy{TSubject}(IAssertion{TSubject}, Func{TSubject, bool}, string?)" />
    [Assertion]
    public TAssert DoesNotSatisfy(Func<TSubject, bool> condition, string? message = null)
        => (TAssert)ObjectAssertions.DoesNotSatisfy(this, condition, message);
}
