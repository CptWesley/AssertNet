namespace AssertNet;

/// <summary>
/// Static assertion class for the xUnit framework.
/// </summary>
public static class Assertions
{
    /// <summary>
    /// Makes an assertion about a void action.
    /// </summary>
    /// <param name="action">Void action under test.</param>
    /// <returns>Assertion about a void action.</returns>
    public static VoidAssertion That(this AssertionBuilder _, Action action) => new(FailureHandlerFactory.Create(), action);

    /// <summary>
    /// Makes an assertion about an exception.
    /// </summary>
    /// <param name="exception">Exception under test.</param>
    /// <returns>Assertion about an exception.</returns>
    public static ExceptionAssertion That(this AssertionBuilder _, Exception exception) => new(FailureHandlerFactory.Create(), exception);

    /// <summary>
    /// Makes an assertion about a boolean value.
    /// </summary>
    /// <param name="value">Boolean value under test.</param>
    /// <returns>Assertion about a boolean value.</returns>
    public static BooleanAssertion That(this AssertionBuilder _, bool value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a numeric value.
    /// </summary>
    /// <param name="value">Numeric value under test.</param>
    /// <returns>Assertion about a numeric value.</returns>
    public static DoubleAssertion That(this AssertionBuilder _, double value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a string.
    /// </summary>
    /// <param name="value">String under test.</param>
    /// <returns>Assertion about a string.</returns>
    public static StringAssertion That(this AssertionBuilder _, string value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about an enumerable.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
    /// <param name="enumerable">Enumerable under test.</param>
    /// <returns>Assertion about an enumerable.</returns>
    public static EnumerableAssertion<T> That<T>(IEnumerable<T> enumerable) => new(FailureHandlerFactory.Create(), enumerable);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    public static SingleAssertion That(this AssertionBuilder _, object value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a void action.
    /// </summary>
    /// <param name="action">Void action under test.</param>
    /// <returns>Assertion about a void action.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static VoidAssertion AssertThat(Action action) => new VoidAssertion(FailureHandlerFactory.Create(), action);

    /// <summary>
    /// Makes an assertion about an exception.
    /// </summary>
    /// <param name="exception">Exception under test.</param>
    /// <returns>Assertion about an exception.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static ExceptionAssertion AssertThat(Exception exception) => new ExceptionAssertion(FailureHandlerFactory.Create(), exception);

    /// <summary>
    /// Makes an assertion about a boolean value.
    /// </summary>
    /// <param name="value">Boolean value under test.</param>
    /// <returns>Assertion about a boolean value.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static BooleanAssertion AssertThat(bool value) => new BooleanAssertion(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a numeric value.
    /// </summary>
    /// <param name="value">Numeric value under test.</param>
    /// <returns>Assertion about a numeric value.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static DoubleAssertion AssertThat(double value) => new DoubleAssertion(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a string.
    /// </summary>
    /// <param name="value">String under test.</param>
    /// <returns>Assertion about a string.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static StringAssertion AssertThat(string value) => new StringAssertion(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about an enumerable.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
    /// <param name="enumerable">Enumerable under test.</param>
    /// <returns>Assertion about an enumerable.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static EnumerableAssertion<T> AssertThat<T>(IEnumerable<T> enumerable) => new EnumerableAssertion<T>(FailureHandlerFactory.Create(), enumerable);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    [Obsolete("Use Asserts.That instead.")]
    public static SingleAssertion AssertThat(object value) => new SingleAssertion(FailureHandlerFactory.Create(), value);
}
