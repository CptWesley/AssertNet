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
    /// <param name="target">The mock under test.</param>
    /// <param name="expression">Expression of the invocation.</param>
    public MethodInvocationAssertion(Mock<T> target, Expression<Func<T, TProperty>> expression)
        : base(target) => Expression = expression;

    /// <summary>
    /// Gets expression of the method invocation.
    /// </summary>
    /// <value>
    /// The expression of the method invocation.
    /// </value>
    public Expression<Func<T, TProperty>> Expression { get; }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Never(string? message = null)
    {
        Target.Verify(Expression, Times.Never(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Once(string? message = null)
    {
        Target.Verify(Expression, Times.Once(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtLeastOnce(string? message = null)
    {
        Target.Verify(Expression, Times.AtLeastOnce(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtMostOnce(string? message = null)
    {
        Target.Verify(Expression, Times.AtMostOnce(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtLeast(int count, string? message = null)
    {
        Target.Verify(Expression, Times.AtLeast(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtMost(int count, string? message = null)
    {
        Target.Verify(Expression, Times.AtMost(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Exactly(int count, string? message = null)
    {
        Target.Verify(Expression, Times.Exactly(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Between(int minimum, int maximum, string? message = null)
    {
        Target.Verify(Expression, Times.Between(minimum, maximum, global::Moq.Range.Inclusive), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }
}
