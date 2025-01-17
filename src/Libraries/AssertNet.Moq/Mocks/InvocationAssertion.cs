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
    /// <param name="mockAssertion">The original mock assertion.</param>
    protected InvocationAssertion(IAssertion<Mock<T>> mockAssertion)
        => MockAssertion = mockAssertion;

    /// <summary>
    /// Gets the mock under test.
    /// </summary>
    /// <value>
    /// The mock under test.
    /// </value>
    public IAssertion<Mock<T>> MockAssertion { get; }

    /// <inheritdoc cref="IAssertion.Subject" />
    public Mock<T> Subject => MockAssertion.Subject;

    /// <summary>
    /// Asserts that the expression was never invoked.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> Never(string? message = null)
    {
        Verify(Times.Never(), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> Once(string? message = null)
    {
        Verify(Times.Once(), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked at least once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> AtLeastOnce(string? message = null)
    {
        Verify(Times.AtLeastOnce(), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked at most once.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> AtMostOnce(string? message = null)
    {
        Verify(Times.AtMostOnce(), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked at least the given amount of times.
    /// </summary>
    /// <param name="count">The minimum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> AtLeast(int count, string? message = null)
    {
        Verify(Times.AtLeast(count), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked at most the given amount of times.
    /// </summary>
    /// <param name="count">The maximum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> AtMost(int count, string? message = null)
    {
        Verify(Times.AtMost(count), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked exactly the given amount of times.
    /// </summary>
    /// <param name="count">The exact amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> Exactly(int count, string? message = null)
    {
        Verify(Times.Exactly(count), message);
        return MockAssertion;
    }

    /// <summary>
    /// Asserts that the expression was invoked a number of times in a certain range.
    /// </summary>
    /// <param name="minimum">The minimum amount of invocations.</param>
    /// <param name="maximum">The maximum amount of invocations.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>An assertion on the mock we were making an assertion about.</returns>
    public IAssertion<Mock<T>> Between(int minimum, int maximum, string? message = null)
    {
        Verify(Times.Between(minimum, maximum, global::Moq.Range.Inclusive), message);
        return MockAssertion;
    }

    private void Verify(Times times, string? message)
    {
        try
        {
            VerifyMoq(times, message);
        }
        catch (Exception ex)
        {
            MockAssertion.Fail(ex.Message);
            throw;
        }
    }

    protected abstract void VerifyMoq(Times times, string? message);
}
