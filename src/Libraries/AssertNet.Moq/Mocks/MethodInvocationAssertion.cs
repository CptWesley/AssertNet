using System.Linq.Expressions;
using AssertNet.AssertionTypes;
using AssertNet.FailureHandlers;
using Moq;

namespace AssertNet.Moq.Mocks;

/// <summary>
/// Class representing assertions made about non-void methods.
/// </summary>
/// <typeparam name="T">Type of the object being mocked.</typeparam>
/// <typeparam name="TProperty">Return type of the method.</typeparam>
public sealed class MethodInvocationAssertion<T, TProperty> : InvocationAssertion<T>
    where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MethodInvocationAssertion{T, TProperty}"/> class.
    /// </summary>
    /// <param name="mockAssertion">The original mock assertion.</param>
    /// <param name="expression">Expression of the invocation.</param>
    public MethodInvocationAssertion(IAssertion<Mock<T>> mockAssertion, Expression<Func<T, TProperty>> expression)
        : base(mockAssertion) => Expression = expression;

    /// <summary>
    /// Gets expression of the method invocation.
    /// </summary>
    /// <value>
    /// The expression of the method invocation.
    /// </value>
    public Expression<Func<T, TProperty>> Expression { get; }

    /// <inheritdoc />
    protected override void VerifyMoq(Times times, string? message)
    {
        Subject.Verify(Expression, times, message);
    }
}
