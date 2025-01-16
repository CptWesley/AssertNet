using AssertNet.AssertionTypes;
using Moq;

namespace AssertNet.Moq.Mocks;

/// <summary>
/// Class representing assertions made about method invocations.
/// </summary>
/// <typeparam name="T">Type of the object being mocked.</typeparam>
public abstract class InvocationAssertion<T>
    where T : class
{
    /// <summary>
    /// Initializes a new instance of the <see cref="InvocationAssertion{T}"/> class.
    /// </summary>
    /// <param name="target">The mock under test.</param>
    protected InvocationAssertion(Mock<T> target) => Target = target;

    /// <summary>
    /// Gets the mock under test.
    /// </summary>
    /// <value>
    /// The mock under test.
    /// </value>
    public Mock<T> Target { get; }

    /// <summary>
    /// Asserts that the expression was never invoked.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> Never(string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> Once(string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked at least once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> AtLeastOnce(string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked at most once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> AtMostOnce(string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked at least the given amount of times.
    /// </summary>
    /// <param name="count">The minimum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> AtLeast(int count, string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked at most the given amount of times.
    /// </summary>
    /// <param name="count">The maximum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> AtMost(int count, string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked exactly the given amount of times.
    /// </summary>
    /// <param name="count">The exact amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> Exactly(int count, string? message = null);

    /// <summary>
    /// Asserts that the expression was invoked a number of times in a certain range.
    /// </summary>
    /// <param name="minimum">The minimum amount of invocations.</param>
    /// <param name="maximum">The maximum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public abstract IAssertion<Mock<T>> Between(int minimum, int maximum, string? message = null);
}
