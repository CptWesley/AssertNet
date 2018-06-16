using System;
using System.Linq.Expressions;
using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about invocations.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    public class InvocationAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="InvocationAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        /// <param name="expression">Expression of the invocation.</param>
        public InvocationAssertion(Mock<T> target, Expression<Action<T>> expression)
        {
            Target = target;
            Expression = expression;
        }

        /// <summary>
        /// Gets the mock under test.
        /// </summary>
        /// <value>
        /// The mock under test.
        /// </value>
        public Mock<T> Target { get; }

        /// <summary>
        /// Gets expression of the invocation.
        /// </summary>
        /// <value>
        /// The expression of the invocation.
        /// </value>
        public Expression<Action<T>> Expression { get; }

        /// <summary>
        /// Asserts that the expression was never invoked.
        /// </summary>
        public void Never() => Target.Verify(Expression, Times.Never);

        /// <summary>
        /// Asserts that the expression was invoked once.
        /// </summary>
        public void Once() => Target.Verify(Expression, Times.Once);

        /// <summary>
        /// Asserts that the expression was invoked at least once.
        /// </summary>
        public void AtLeastOnce() => Target.Verify(Expression, Times.AtLeastOnce);

        /// <summary>
        /// Asserts that the expression was invoked at most once.
        /// </summary>
        public void AtMostOnce() => Target.Verify(Expression, Times.AtMostOnce);

        /// <summary>
        /// Asserts that the expression was invoked at least the given amount of times.
        /// </summary>
        /// <param name="count">The minimum amount of invocations.</param>
        public void AtLeast(int count) => Target.Verify(Expression, Times.AtLeast(count));

        /// <summary>
        /// Asserts that the expression was invoked at most the given amount of times.
        /// </summary>
        /// <param name="count">The maximum amount of invocations.</param>
        public void AtMost(int count) => Target.Verify(Expression, Times.AtMost(count));

        /// <summary>
        /// Asserts that the expression was invoked exactly the given amount of times.
        /// </summary>
        /// <param name="count">The exact amount of invocations.</param>
        public void Exactly(int count) => Target.Verify(Expression, Times.Exactly(count));

        /// <summary>
        /// Asserts that the expression was invoked a number of times in a certain range.
        /// </summary>
        /// <param name="minimum">The minimum amount of invocations.</param>
        /// <param name="maximum">The maximum amount of invocations.</param>
        public void Between(int minimum, int maximum) => Target.Verify(Expression, Times.Between(minimum, maximum, Range.Inclusive));
    }
}
