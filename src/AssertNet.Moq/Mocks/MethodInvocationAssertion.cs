using System;
using System.Linq.Expressions;
using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about non-void methods.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    /// <typeparam name="TProperty">Return type of the method.</typeparam>
    public class MethodInvocationAssertion<T, TProperty> : InvocationAssertion<T>
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
        public override void Never() => Target.Verify(Expression, Times.Never);

        /// <inheritdoc/>
        public override void Once() => Target.Verify(Expression, Times.Once);

        /// <inheritdoc/>
        public override void AtLeastOnce() => Target.Verify(Expression, Times.AtLeastOnce);

        /// <inheritdoc/>
        public override void AtMostOnce() => Target.Verify(Expression, Times.AtMostOnce);

        /// <inheritdoc/>
        public override void AtLeast(int count) => Target.Verify(Expression, Times.AtLeast(count));

        /// <inheritdoc/>
        public override void AtMost(int count) => Target.Verify(Expression, Times.AtMost(count));

        /// <inheritdoc/>
        public override void Exactly(int count) => Target.Verify(Expression, Times.Exactly(count));

        /// <inheritdoc/>
        public override void Between(int minimum, int maximum) => Target.Verify(Expression, Times.Between(minimum, maximum, Range.Inclusive));
    }
}
