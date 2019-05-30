using System;
using System.Linq.Expressions;
using Moq;

namespace AssertNet.Moq.Mocks
{
    /// <summary>
    /// Class representing assertions made about mocks.
    /// </summary>
    /// <typeparam name="T">Type of the object being mocked.</typeparam>
    public class MockAssertion<T>
        where T : class
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The mock under test.</param>
        public MockAssertion(Mock<T> target)
        {
            Target = target;
        }

        /// <summary>
        /// Gets the mock under test.
        /// </summary>
        /// <value>
        /// The mock under test.
        /// </value>
        public Mock<T> Target { get; }

        /// <summary>
        /// Starts an assertion about an invocation.
        /// </summary>
        /// <param name="expression">The expression.</param>
        /// <returns>An assertion about an invocation.</returns>
        public InvocationAssertion<T> HasInvoked(Expression<Action<T>> expression) => new VoidMethodInvocationAssertion<T>(Target, expression);

        /// <summary>
        /// Starts an assertion about a property get expression.
        /// </summary>
        /// <typeparam name="TProperty">The type of the property.</typeparam>
        /// <param name="expression">The expression of getting the property.</param>
        /// <returns>An assertion about the property get expression.</returns>
        public InvocationAssertion<T> HasInvoked<TProperty>(Expression<Func<T, TProperty>> expression) => new MethodInvocationAssertion<T, TProperty>(Target, expression);

        /// <summary>
        /// Starts an assertion about a property set expression.
        /// </summary>
        /// <param name="expression">The set expression.</param>
        /// <returns>An assertion about the property set expression.</returns>
        public InvocationAssertion<T> HasAssigned(Action<T> expression) => new SetPropertyInvocationAssertion<T>(Target, expression);

        /// <summary>
        /// Determines whether the target mock has not performed any other unverified invocations.
        /// </summary>
        /// <returns>The current mock assertion.</returns>
        public MockAssertion<T> HasNotPerformedOtherInvocations()
        {
            Target.VerifyNoOtherCalls();
            return this;
        }
    }
}
