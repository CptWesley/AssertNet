using System;
using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about property setters.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    public class SetPropertyInvocationAssertion<T> : InvocationAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SetPropertyInvocationAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        /// <param name="expression">Expression of the invocation.</param>
        public SetPropertyInvocationAssertion(Mock<T> target, Action<T> expression)
            : base(target) => Expression = expression;

        /// <summary>
        /// Gets expression of the property requests.
        /// </summary>
        /// <value>
        /// The expression of the property requests.
        /// </value>
        public Action<T> Expression { get; }

        /// <inheritdoc/>
        public override void Never() => Target.VerifySet(Expression, Times.Never);

        /// <inheritdoc/>
        public override void Once() => Target.VerifySet(Expression, Times.Once);

        /// <inheritdoc/>
        public override void AtLeastOnce() => Target.VerifySet(Expression, Times.AtLeastOnce);

        /// <inheritdoc/>
        public override void AtMostOnce() => Target.VerifySet(Expression, Times.AtMostOnce);

        /// <inheritdoc/>
        public override void AtLeast(int count) => Target.VerifySet(Expression, Times.AtLeast(count));

        /// <inheritdoc/>
        public override void AtMost(int count) => Target.VerifySet(Expression, Times.AtMost(count));

        /// <inheritdoc/>
        public override void Exactly(int count) => Target.VerifySet(Expression, Times.Exactly(count));

        /// <inheritdoc/>
        public override void Between(int minimum, int maximum) => Target.VerifySet(Expression, Times.Between(minimum, maximum, Range.Inclusive));
    }
}
