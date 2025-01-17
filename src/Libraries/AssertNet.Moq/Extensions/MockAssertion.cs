using System.Linq.Expressions;
using AssertNet.AssertionTypes;
using AssertNet.Moq.Mocks;
using Moq;

namespace AssertNet;

/// <summary>
/// Extension methods for assertions related to Moq mocks.
/// </summary>
public static class MoqMockAssertions
{
    /// <summary>
    /// Starts an assertion about an invocation.
    /// </summary>
    /// <typeparam name="T">The mocked type.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="expression">The expression.</param>
    /// <returns>An assertion about an invocation.</returns>
    public static InvocationAssertion<T> HasInvoked<T>(this IAssertion<Mock<T>> assertion, Expression<Action<T>> expression)
        where T : class
        => new VoidMethodInvocationAssertion<T>(assertion, expression);

    /// <summary>
    /// Starts an assertion about a property get expression.
    /// </summary>
    /// <typeparam name="T">The mocked type.</typeparam>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="expression">The expression of getting the property.</param>
    /// <returns>An assertion about the property get expression.</returns>
    public static InvocationAssertion<T> HasInvoked<T, TProperty>(this IAssertion<Mock<T>> assertion, Expression<Func<T, TProperty>> expression)
        where T : class
        => new MethodInvocationAssertion<T, TProperty>(assertion, expression);

    /// <summary>
    /// Starts an assertion about a property set expression.
    /// </summary>
    /// <typeparam name="T">The mocked type.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <param name="expression">The set expression.</param>
    /// <returns>An assertion about the property set expression.</returns>
    public static InvocationAssertion<T> HasAssigned<T>(this IAssertion<Mock<T>> assertion, Action<T> expression)
        where T : class
        => new SetPropertyInvocationAssertion<T>(assertion, expression);

    /// <summary>
    /// Determines whether the target mock has not performed any other unverified invocations.
    /// </summary>
    /// <typeparam name="T">The mocked type.</typeparam>
    /// <param name="assertion">The original assertion chain.</param>
    /// <returns>The current mock assertion.</returns>
    public static IAssertion<Mock<T>> HasNotPerformedOtherInvocations<T>(this IAssertion<Mock<T>> assertion)
        where T : class
    {
        assertion.Subject.VerifyNoOtherCalls();
        return assertion;
    }
}
