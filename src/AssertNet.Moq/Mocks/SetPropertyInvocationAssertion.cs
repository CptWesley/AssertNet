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
        public override MockAssertion<T> Never()
        {
            Target.VerifySet(Expression, Times.Never);
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> Once()
        {
            Target.VerifySet(Expression, Times.Once);
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> AtLeastOnce()
        {
            Target.VerifySet(Expression, Times.AtLeastOnce);
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> AtMostOnce()
        {
            Target.VerifySet(Expression, Times.AtMostOnce);
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> AtLeast(int count)
        {
            Target.VerifySet(Expression, Times.AtLeast(count));
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> AtMost(int count)
        {
            Target.VerifySet(Expression, Times.AtMost(count));
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> Exactly(int count)
        {
            Target.VerifySet(Expression, Times.Exactly(count));
            return new MockAssertion<T>(Target);
        }

        /// <inheritdoc/>
        public override MockAssertion<T> Between(int minimum, int maximum)
        {
            Target.VerifySet(Expression, Times.Between(minimum, maximum, Range.Inclusive));
            return new MockAssertion<T>(Target);
        }
    }
}
