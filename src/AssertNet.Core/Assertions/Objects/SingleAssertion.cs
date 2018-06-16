using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made on single objects.
    /// </summary>
    /// <typeparam name="TTarget">Type of the object under test.</typeparam>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    public class SingleAssertion<TTarget> : ObjectAssertion<SingleAssertion<TTarget>, TTarget>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAssertion{TTarget}"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public SingleAssertion(IFailureHandler failureHandler, TTarget target)
            : base(failureHandler, target)
        {
        }
    }
}
