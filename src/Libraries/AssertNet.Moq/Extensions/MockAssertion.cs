using System.Linq.Expressions;
using AssertNet.AssertionTypes;
using AssertNet.Moq.Mocks;
using Moq;

namespace AssertNet;

/// <summary>
/// Class representing assertions made about mocks.
/// </summary>
/// <typeparam name="T">Type of the object being mocked.</typeparam>
public static class MoqMockAssertions
{
    /// <summary>
    /// Starts an assertion about an invocation.
    /// </summary>
    /// <param name="expression">The expression.</param>
    /// <returns>An assertion about an invocation.</returns>
    public static InvocationAssertion<T> HasInvoked<T>(this IAssertion<Mock<T>> assertion, Expression<Action<T>> expression)
        where T : class
        => new VoidMethodInvocationAssertion<T>(assertion.Subject, expression);

    /// <summary>
    /// Starts an assertion about a property get expression.
    /// </summary>
    /// <typeparam name="TProperty">The type of the property.</typeparam>
    /// <param name="expression">The expression of getting the property.</param>
    /// <returns>An assertion about the property get expression.</returns>
    public static InvocationAssertion<T> HasInvoked<T, TProperty>(this IAssertion<Mock<T>> assertion, Expression<Func<T, TProperty>> expression)
        where T : class
        => new MethodInvocationAssertion<T, TProperty>(assertion.Subject, expression);

    /// <summary>
    /// Starts an assertion about a property set expression.
    /// </summary>
    /// <param name="expression">The set expression.</param>
    /// <returns>An assertion about the property set expression.</returns>
    public static InvocationAssertion<T> HasAssigned<T>(this IAssertion<Mock<T>> assertion, Action<T> expression)
        where T : class
        => new SetPropertyInvocationAssertion<T>(assertion.Subject, expression);

    /// <summary>
    /// Determines whether the target mock has not performed any other unverified invocations.
    /// </summary>
    /// <returns>The current mock assertion.</returns>
    public static IAssertion<Mock<T>> HasNotPerformedOtherInvocations<T>(this IAssertion<Mock<T>> assertion)
        where T : class
    {
        assertion.Subject.VerifyNoOtherCalls();
        return assertion;
    }
}
