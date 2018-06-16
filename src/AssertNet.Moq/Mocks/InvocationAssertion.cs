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
    }
}
