namespace AssertNet.Core
{
    /// <summary>
    /// Class representing assertions made on single objects.
    /// </summary>
    public class SingleAssertion : ObjectAssertion<SingleAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="objs">The object which is under test.</param>
        public SingleAssertion(IFailureHandler failureHandler, object objs)
            : base(failureHandler, objs)
        {
        }
    }
}
