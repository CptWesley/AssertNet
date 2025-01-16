namespace AssertNet.AssertionTypes;

/// <summary>
/// Abstract class representing assertions of objects.
/// </summary>
/// <typeparam name="TAssert">Derived type of the assertion.</typeparam>
/// <typeparam name="TSubject">Type of the object under test.</typeparam>
/// <seealso cref="IAssertion" />
public class Assertion<TAssert, TSubject> : IAssertion<TSubject>
    where TAssert : Assertion<TAssert, TSubject>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Assertion{TAssert, TTarget}"/> class.
    /// </summary>
    /// <param name="subject">The object which is under test.</param>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    public Assertion(IFailureHandler failureHandler, TSubject subject)
    {
        FailureHandler = failureHandler;
        Subject = subject;
    }

    /// <inheritdoc />
    public TSubject Subject { get; }

    /// <inheritdoc />
    object? IAssertion.Subject => Subject;

    /// <inheritdoc />
    public IFailureHandler FailureHandler { get; }

    /// <inheritdoc cref="ObjectAssertions.IsNotInstanceOf{TAssert}(TAssert, Type, string?)" />
    public TAssert IsNotInstanceOf<T>(string? message = null)
        => (TAssert)ObjectAssertions.IsNotInstanceOf<T>(this, message);

    /// <inheritdoc cref="ObjectAssertions.IsNotExactlyInstanceOf{TAssert}(TAssert, Type, string?)" />
    public TAssert IsNotExactlyInstanceOf<T>(string? message = null)
        => (TAssert)ObjectAssertions.IsNotExactlyInstanceOf<T>(this, message);

    /// <inheritdoc cref="ObjectAssertions.Satisfies{TSubject}(IAssertion{TSubject}, Func{TSubject, bool}, string?)" />
    public TAssert Satisfies(Func<TSubject, bool> condition, string? message = null)
        => (TAssert)ObjectAssertions.Satisfies(this, condition, message);

    /// <inheritdoc cref="ObjectAssertions.DoesNotSatisfy{TSubject}(IAssertion{TSubject}, Func{TSubject, bool}, string?)" />
    public TAssert DoesNotSatisfy(Func<TSubject, bool> condition, string? message = null)
        => (TAssert)ObjectAssertions.DoesNotSatisfy(this, condition, message);
}
