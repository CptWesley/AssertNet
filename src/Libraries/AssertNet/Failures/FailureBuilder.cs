using AssertNet.AssertionTypes;

namespace AssertNet.Failures;

/// <summary>
/// A builder for failure messages.
/// </summary>
/// <typeparam name="TAssert">The assertion type.</typeparam>
[Mutable]
public sealed class FailureBuilder<TAssert>
    where TAssert : IAssertion
{
    private readonly TAssert assertion;

    /// <summary>
    /// Initializes a new instance of the <see cref="FailureBuilder{TAssert}"/> class.
    /// </summary>
    /// <param name="assertion">The wrapped assertion.</param>
    internal FailureBuilder(TAssert assertion)
    {
        this.assertion = assertion;
    }

    /// <summary>
    /// The name of the assertion being performed.
    /// </summary>
    public string? Assertion { get; set; }

    /// <summary>
    /// The user-supplied additional message.
    /// </summary>
    public string? Message { get; set; }

    /// <summary>
    /// The expectation explanation.
    /// </summary>
    public string? Expectation { get; set; }

    /// <summary>
    /// The optional explanation argument.
    /// </summary>
    public object? ExpectationArgument { get; set; }

    /// <summary>
    /// Sets the <see cref="Assertion"/> property.
    /// </summary>
    /// <param name="assertion">The new value.</param>
    /// <returns>The updated builder instance.</returns>
    [FluentSyntax]
    public FailureBuilder<TAssert> WithAssertion(string? assertion)
    {
        this.Assertion = assertion;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Message"/> property.
    /// </summary>
    /// <param name="message">The new value.</param>
    /// <returns>The updated builder instance.</returns>
    [FluentSyntax]
    public FailureBuilder<TAssert> WithMessage(string? message)
    {
        this.Message = message;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="ExpectationArgument"/> property.
    /// </summary>
    /// <param name="expectationArgument">The new value.</param>
    /// <returns>The updated builder instance.</returns>
    [FluentSyntax]
    public FailureBuilder<TAssert> WithExpectationArgument(object? expectationArgument)
    {
        this.ExpectationArgument = expectationArgument;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Expectation"/> property.
    /// </summary>
    /// <param name="expectation">The new value.</param>
    /// <returns>The updated builder instance.</returns>
    [FluentSyntax]
    public FailureBuilder<TAssert> WithExpectation(string? expectation)
    {
        this.Expectation = expectation;
        return this;
    }

    /// <summary>
    /// Sets the <see cref="Expectation"/> and <see cref="ExpectationArgument"/> properties.
    /// </summary>
    /// <param name="expectation">The new <see cref="Expectation"/> value.</param>
    /// <param name="expectationArgument">The new <see cref="ExpectationArgument"/> value.</param>
    /// <returns>The updated builder instance.</returns>
    [FluentSyntax]
    public FailureBuilder<TAssert> WithExpectation(string? expectation, object? expectationArgument)
        => WithExpectation(expectation)
        .WithExpectationArgument(expectationArgument);

    /// <summary>
    /// Triggers the failure if the given <paramref name="condition"/> is <see langword="true"/>.
    /// </summary>
    /// <param name="condition">The condition to check.</param>
    /// <returns>The original wrapped assertion.</returns>
#if NET7_0_OR_GREATER
    [StackTraceHidden]
#endif
    [FluentSyntax]
    public TAssert FailWhen(bool condition)
    {
        if (condition)
        {
            var msg = ToString();
            assertion.FailureHandler.Fail(msg);
        }

        return assertion;
    }

    /// <inheritdoc />
    [Pure]
    public override string ToString()
    {
        var sb = new StringBuilder();

        if (Assertion is { Length: > 0 })
        {
            sb.Append(Assertion).Append(' ');
        }

        sb.AppendLine("Assertion failure");

        if (Message is { Length: > 0 })
        {
            sb.AppendLine(Message);
        }

        sb.AppendLine("Expecting:");

        var subjectString = StringOf(assertion.Subject);

        if (assertion.Expression is { Length: > 0 } && assertion.Expression != subjectString)
        {
            sb.Append(assertion.Expression).Append(" (").Append(subjectString).AppendLine(")");
        }
        else
        {
            sb.AppendLine(subjectString);
        }

        if (Expectation is { Length: > 0 })
        {
            if (ExpectationArgument is { })
            {
                sb.Append(Expectation).AppendLine(":");
                sb.AppendLine(StringOf(ExpectationArgument));
            }
            else
            {
                sb.AppendLine(Expectation);
            }
        }

        // Trim the last whitespaces.
        while (sb.Length > 0 && sb[sb.Length - 1] is '\r' or '\n')
        {
            sb.Length--;
        }

        return sb.ToString();
    }

    /// <summary>
    /// Gets the string version of an object.
    /// </summary>
    /// <typeparam name="T">Type of the object.</typeparam>
    /// <param name="ob">The object to get the string version of.</param>
    /// <returns>"null" if the object is null. The value of .ToString() otherwise.</returns>
    [Pure]
    private static string StringOf<T>(T? ob)
        => ob?.ToString() is { } str
        ? str
        : "<null>";
}
