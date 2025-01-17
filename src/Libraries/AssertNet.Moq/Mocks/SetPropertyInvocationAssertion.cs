using AssertNet.AssertionTypes;
using AssertNet.FailureHandlers;
using Moq;

namespace AssertNet.Moq.Mocks;

/// <summary>
/// Class representing assertions made about property setters.
/// </summary>
/// <typeparam name="T">Type of the object being mocked.</typeparam>
public sealed class SetPropertyInvocationAssertion<T> : InvocationAssertion<T>
    where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SetPropertyInvocationAssertion{T}"/> class.
    /// </summary>
    /// <param name="mockAssertion">The original mock assertion.</param>
    /// <param name="expression">Expression of the invocation.</param>
    public SetPropertyInvocationAssertion(IAssertion<Mock<T>> mockAssertion, Action<T> expression)
        : base(mockAssertion) => Expression = expression;

    /// <summary>
    /// Gets expression of the property requests.
    /// </summary>
    /// <value>
    /// The expression of the property requests.
    /// </value>
    public Action<T> Expression { get; }

    /// <inheritdoc />
    protected override void VerifyMoq(Times times, string? message)
    {
        Subject.VerifySet(Expression, times, message);
    }
}
