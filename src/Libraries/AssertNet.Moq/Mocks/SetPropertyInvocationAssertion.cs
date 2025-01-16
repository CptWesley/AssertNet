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
    /// <param name="target">The mock under test.</param>
    /// <param name="expression">Expression of the invocation.</param>
    public SetPropertyInvocationAssertion(Mock<T> target, System.Action<T> expression)
        : base(target) => Expression = expression;

    /// <summary>
    /// Gets expression of the property requests.
    /// </summary>
    /// <value>
    /// The expression of the property requests.
    /// </value>
    public System.Action<T> Expression { get; }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Never(string? message = null)
    {
        Target.VerifySet(Expression, Times.Never(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Once(string? message = null)
    {
        Target.VerifySet(Expression, Times.Once(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtLeastOnce(string? message = null)
    {
        Target.VerifySet(Expression, Times.AtLeastOnce(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtMostOnce(string? message = null)
    {
        Target.VerifySet(Expression, Times.AtMostOnce(), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtLeast(int count, string? message = null)
    {
        Target.VerifySet(Expression, Times.AtLeast(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> AtMost(int count, string? message = null)
    {
        Target.VerifySet(Expression, Times.AtMost(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Exactly(int count, string? message = null)
    {
        Target.VerifySet(Expression, Times.Exactly(count), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }

    /// <inheritdoc/>
    public override IAssertion<Mock<T>> Between(int minimum, int maximum, string? message = null)
    {
        Target.VerifySet(Expression, Times.Between(minimum, maximum, global::Moq.Range.Inclusive), message);
        return new Assertion<Mock<T>>(FailureHandlerFactory.Create(), Target);
    }
}
