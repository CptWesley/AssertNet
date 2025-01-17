using System.Linq.Expressions;
using AssertNet.AssertionTypes;
using AssertNet.FailureHandlers;
using Moq;

namespace AssertNet.Moq.Mocks;

/// <summary>
/// Class representing assertions made about method invocations.
/// </summary>
/// <typeparam name="T">Type of the object being mocked.</typeparam>
public sealed class VoidMethodInvocationAssertion<T> : InvocationAssertion<T>
    where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="VoidMethodInvocationAssertion{T}"/> class.
    /// </summary>
    /// <param name="mockAssertion">The original mock assertion.</param>
    /// <param name="expression">Expression of the invocation.</param>
    public VoidMethodInvocationAssertion(IAssertion<Mock<T>> mockAssertion, Expression<Action<T>> expression)
        : base(mockAssertion) => Expression = expression;

    /// <summary>
    /// Gets expression of the invocation.
    /// </summary>
    /// <value>
    /// The expression of the invocation.
    /// </value>
    public Expression<Action<T>> Expression { get; }

    /// <inheritdoc />
    protected override void VerifyMoq(Times times, string? message)
    {
        Subject.Verify(Expression, times, message);
    }
}
