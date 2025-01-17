namespace AssertNet.AssertionTypes;

/// <summary>
/// Abstract class representing assertions of objects.
/// </summary>
/// <typeparam name="TAssert">Derived type of the assertion.</typeparam>
/// <typeparam name="TSubject">Type of the object under test.</typeparam>
/// <seealso cref="IAssertion" />
public abstract class Assertion<TAssert, TSubject> : IAssertion<TAssert, TSubject>
    where TAssert : Assertion<TAssert, TSubject>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Assertion{TAssert, TTarget}"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="subject">The object which is under test.</param>
    /// <param name="expression">The expression string of the subject, if available.</param>
    protected Assertion(IFailureHandler failureHandler, TSubject subject, string? expression)
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
