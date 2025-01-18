namespace AssertNet.Failures;

/// <summary>
/// A builder for failure messages.
/// </summary>
[Mutable]
public sealed class FailureMessageBuilder
{
    public object? Subject { get; set; }

    public string? Expression { get; set; }

    public string? Assertion { get; set; }

    public string? Message { get; set; }

    public string? Expectation { get; set; }

    public object? ExpectationArgument { get; set; }

    [FluentSyntax]
    public FailureMessageBuilder WithSubject(object? subject)
    {
        this.Subject = subject;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithExpression(string? expression)
    {
        this.Expression = expression;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithAssertion(string? assertion)
    {
        this.Assertion = assertion;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithMessage(string? message)
    {
        this.Message = message;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithExpectation(string? expectation)
    {
        this.Expectation = expectation;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithExpectationArgument(object? expectationArgument)
    {
        this.ExpectationArgument = expectationArgument;
        return this;
    }

    [FluentSyntax]
    public FailureMessageBuilder WithExpectation(string? expectation, object? expectationArgument)
        => WithExpectation(expectation)
        .WithExpectationArgument(expectationArgument);

#if NET7_0_OR_GREATER
    [StackTraceHidden]
#endif
    public void FailWhen(bool condition)
    {
        if (!condition)
        {
            return;
        }

        FailureHandlerFactory.Create().Fail(ToString());
    }

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

        var subjectString = StringOf(Subject);

        if (Expression is { Length: > 0 } && Expression != subjectString)
        {
            sb.Append(Expression).Append(" (").Append(subjectString).AppendLine(")");
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
