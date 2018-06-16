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
    public class GetAssertion<T, TProperty>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GetAssertion{T, TProperty}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        /// <param name="expression">Expression of the invocation.</param>
        public GetAssertion(Mock<T> target, Expression<Func<T, TProperty>> expression)
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
        /// Gets expression of the property requests.
        /// </summary>
        /// <value>
        /// The expression of the property requests.
        /// </value>
        public Expression<Func<T, TProperty>> Expression { get; }

        /// <summary>
        /// Asserts that the property was never requested.
        /// </summary>
        public void Never() => Target.VerifyGet(Expression, Times.Never);

        /// <summary>
        /// Asserts that the property was requested once.
        /// </summary>
        public void Once() => Target.VerifyGet(Expression, Times.Once);

        /// <summary>
        /// Asserts that the property was requested at least once.
        /// </summary>
        public void AtLeastOnce() => Target.VerifyGet(Expression, Times.AtLeastOnce);

        /// <summary>
        /// Asserts that the property was requested at most once.
        /// </summary>
        public void AtMostOnce() => Target.VerifyGet(Expression, Times.AtMostOnce);

        /// <summary>
        /// Asserts that the property was requested at least the given amount of times.
        /// </summary>
        /// <param name="count">The minimum amount of requests.</param>
        public void AtLeast(int count) => Target.VerifyGet(Expression, Times.AtLeast(count));

        /// <summary>
        /// Asserts that the property was requested at most the given amount of times.
        /// </summary>
        /// <param name="count">The maximum amount of requests.</param>
        public void AtMost(int count) => Target.VerifyGet(Expression, Times.AtMost(count));

        /// <summary>
        /// Asserts that the property was requested exactly the given amount of times.
        /// </summary>
        /// <param name="count">The exact amount of requests.</param>
        public void Exactly(int count) => Target.VerifyGet(Expression, Times.Exactly(count));

        /// <summary>
        /// Asserts that the property was requested a number of times in a certain range.
        /// </summary>
        /// <param name="minimum">The minimum amount of requests.</param>
        /// <param name="maximum">The maximum amount of requests.</param>
        public void Between(int minimum, int maximum) => Target.VerifyGet(Expression, Times.Between(minimum, maximum, Range.Inclusive));
    }
}
