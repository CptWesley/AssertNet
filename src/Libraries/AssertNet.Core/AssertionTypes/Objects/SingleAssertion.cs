namespace AssertNet.Core.AssertionTypes.Objects;

/// <summary>
/// Class representing assertions made on single objects.
/// </summary>
/// <seealso cref="Assertion{TAssert, TTarget}" />
public class SingleAssertion<T> : Assertion<SingleAssertion<T>, T>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="SingleAssertion"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="target">The object which is under test.</param>
    public SingleAssertion(IFailureHandler failureHandler, T target)
        : base(failureHandler, target)
    {
    }
}
