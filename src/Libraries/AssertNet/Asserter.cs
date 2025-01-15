namespace AssertNet;

public sealed class Asserter
{
    /// <summary>Asserts that.</summary>
    public static readonly Asserter Asserts = new();

    /// <summary>
    /// Makes an assertion about a void action.
    /// </summary>
    /// <param name="action">Void action under test.</param>
    /// <returns>Assertion about a void action.</returns>
    public VoidAssertion That(Action action) => new(FailureHandlerFactory.Create(), action);

    /// <summary>
    /// Makes an assertion about an exception.
    /// </summary>
    /// <param name="exception">Exception under test.</param>
    /// <returns>Assertion about an exception.</returns>
    public ExceptionAssertion That(Exception exception) => new(FailureHandlerFactory.Create(), exception);

    /// <summary>
    /// Makes an assertion about a boolean value.
    /// </summary>
    /// <param name="value">Boolean value under test.</param>
    /// <returns>Assertion about a boolean value.</returns>
    public BooleanAssertion That(bool value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a numeric value.
    /// </summary>
    /// <param name="value">Numeric value under test.</param>
    /// <returns>Assertion about a numeric value.</returns>
    public DoubleAssertion That(double value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about a string.
    /// </summary>
    /// <param name="value">String under test.</param>
    /// <returns>Assertion about a string.</returns>
    public StringAssertion That(string value) => new(FailureHandlerFactory.Create(), value);

    /// <summary>
    /// Makes an assertion about an enumerable.
    /// </summary>
    /// <typeparam name="T">Type of the elements in the enumerable.</typeparam>
    /// <param name="enumerable">Enumerable under test.</param>
    /// <returns>Assertion about an enumerable.</returns>
    public EnumerableAssertion<T> That<T>(IEnumerable<T> enumerable) => new(FailureHandlerFactory.Create(), enumerable);

    /// <summary>
    /// Makes an assertion about an object.
    /// </summary>
    /// <param name="value">Object under test.</param>
    /// <returns>Assertion about an object.</returns>
    public SingleAssertion That(object value) => new(FailureHandlerFactory.Create(), value);

    private Asserter() { }
}
