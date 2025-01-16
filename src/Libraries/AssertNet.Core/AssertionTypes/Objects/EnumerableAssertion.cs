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
}
