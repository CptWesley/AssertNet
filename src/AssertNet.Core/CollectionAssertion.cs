using System.Collections;

namespace AssertNet.Core
{
    /// <summary>
    /// Class representing assertions made on collection objects.
    /// </summary>
    /// <seealso cref="ObjectAssertion{CollectionAssertion}" />
    public class CollectionAssertion : ObjectAssertion<CollectionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public CollectionAssertion(IFailureHandler failureHandler, IEnumerable target)
            : base(failureHandler, target)
        {
        }
    }
}
