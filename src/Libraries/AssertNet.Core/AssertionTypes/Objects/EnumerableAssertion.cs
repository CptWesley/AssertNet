namespace AssertNet.Core.AssertionTypes.Objects;

/// <summary>
/// Class representing assertions made on collection objects.
/// </summary>
/// <typeparam name="TElement">Element type of the enumerable.</typeparam>
/// <seealso cref="Assertion{TAssert, TTarget}" />
public class EnumerableAssertion<TElement> : Assertion<EnumerableAssertion<TElement>, IEnumerable<TElement>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerableAssertion{TElement}"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="target">The object which is under test.</param>
    public EnumerableAssertion(IFailureHandler failureHandler, IEnumerable<TElement> target)
        : base(failureHandler, target)
    {
    }

    /// <summary>
    /// Checks that a condition holds for all elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for all elements.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> AllSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            this.Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To all satisfy", condition)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> failed = Subject.Where(x => !condition.Invoke(x));

        if (failed.Any())
        {
            this.Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("To all satisfy", condition)
                .AppendEnumerable("But did not hold for", failed)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks that a condition holds for some element in the enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for some element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> SomeSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            this.Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have any element satisfying", condition)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> holds = Subject.Where(condition);

        if (!holds.Any())
        {
            this.Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("To have any element satisfying", condition)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks that a condition holds for none of the elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which may not hold for each element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> NoneSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        IEnumerable<TElement> holds = Subject.Where(condition);

        if (holds.Any())
        {
            this.Fail(new FailureBuilder("NoneSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("Not to have elements satisfying", condition)
                .AppendEnumerable("But found", holds)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Creates a new assertion for a filtered version of the target enumerable.
    /// </summary>
    /// <param name="condition">The condition to filter on.</param>
    /// <returns>A new assertion for a filtered version of the target enumerable.</returns>
    public EnumerableAssertion<TElement> Where(Func<TElement, bool> condition) => new EnumerableAssertion<TElement>(FailureHandler, Subject.Where(condition));

    /// <summary>
    /// Creates a new assertion for a projected version of the target enumerable.
    /// </summary>
    /// <typeparam name="T">The output type of the projection.</typeparam>
    /// <param name="selector">The selector for the projection.</param>
    /// <returns>A new assertion for a projected version of the target enumerable.</returns>
    public EnumerableAssertion<T> Select<T>(Func<TElement, T> selector) => new EnumerableAssertion<T>(FailureHandler, Subject.Select(selector));
}
