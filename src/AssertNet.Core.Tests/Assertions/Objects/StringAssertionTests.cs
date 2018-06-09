using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="StringAssertion"/> class.
    /// </summary>
    /// <seealso cref="ObjectAssertionTests{StringAssertion}" />
    public class StringAssertionTests : ObjectAssertionTests<StringAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringAssertionTests"/> class.
        /// </summary>
        public StringAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new StringAssertion(FailureHandler.Object, "threhterj");
        }
    }
}
