using AssertNet.Core.Failures;

namespace AssertNet.Core.AssertionTypes.Objects
{
    /// <summary>
    /// Class representing assertions made on single objects.
    /// </summary>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    public class SingleAssertion : ObjectAssertion<SingleAssertion, object>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public SingleAssertion(IFailureHandler failureHandler, object target)
            : base(failureHandler, target)
        {
        }
    }
}
