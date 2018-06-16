using System;
using System.Linq.Expressions;
using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about property getters.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    /// <typeparam name="TProperty">Type of the property.</typeparam>
    public class GetPropertyInvocationAssertion<T, TProperty> : InvocationAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetPropertyInvocationAssertion{T, TProperty}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        /// <param name="expression">Expression of the invocation.</param>
        public GetPropertyInvocationAssertion(Mock<T> target, Expression<Func<T, TProperty>> expression)
            : base(target) => Expression = expression;

        /// <summary>
        /// Gets expression of the property requests.
        /// </summary>
        /// <value>
        /// The expression of the property requests.
        /// </value>
        public Expression<Func<T, TProperty>> Expression { get; }

        /// <inheritdoc/>
        public override void Never() => Target.VerifyGet(Expression, Times.Never);

        /// <inheritdoc/>
        public override void Once() => Target.VerifyGet(Expression, Times.Once);

        /// <inheritdoc/>
        public override void AtLeastOnce() => Target.VerifyGet(Expression, Times.AtLeastOnce);

        /// <inheritdoc/>
        public override void AtMostOnce() => Target.VerifyGet(Expression, Times.AtMostOnce);

        /// <inheritdoc/>
        public override void AtLeast(int count) => Target.VerifyGet(Expression, Times.AtLeast(count));

        /// <inheritdoc/>
        public override void AtMost(int count) => Target.VerifyGet(Expression, Times.AtMost(count));

        /// <inheritdoc/>
        public override void Exactly(int count) => Target.VerifyGet(Expression, Times.Exactly(count));

        /// <inheritdoc/>
        public override void Between(int minimum, int maximum) => Target.VerifyGet(Expression, Times.Between(minimum, maximum, Range.Inclusive));
    }
}
