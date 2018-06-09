using AssertNet.Core.Assertions;
using AssertNet.Core.FailureHandlers;
using Moq;

namespace AssertNet.Core.Tests.Assertions
{
    /// <summary>
    /// Test class for the <see cref="CollectionAssertion"/> class.
    /// </summary>
    public class CollectionAssertionTests : ObjectAssertionTests<CollectionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertionTests"/> class.
        /// </summary>
        public CollectionAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new CollectionAssertion(FailureHandler.Object, new int[] { 1, 2, 3 });
        }
    }
}
