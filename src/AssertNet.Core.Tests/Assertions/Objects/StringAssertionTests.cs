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

        private StringAssertion StringAssertion => (StringAssertion)Assertion;

        /// <summary>
        /// Checks that the assertion passes if the value contains a substring.
        /// </summary>
        [Fact]
        public void ContainsPassTest()
        {
            StringAssertion.Contains("t");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value does not contain a substring.
        /// </summary>
        [Fact]
        public void ContainsFailTest()
        {
            StringAssertion.Contains("T");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value does not contain a substring.
        /// </summary>
        [Fact]
        public void DoesNotContainPassTest()
        {
            StringAssertion.DoesNotContain("T");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value contains a substring.
        /// </summary>
        [Fact]
        public void DoesNotContainFailTest()
        {
            StringAssertion.DoesNotContain("t");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value contains a substring while ignoring cases.
        /// </summary>
        [Fact]
        public void ContainsIgnoringCasePassTest()
        {
            StringAssertion.ContainsIgnoringCase("T");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value does not contain a substring while ignoring cases.
        /// </summary>
        [Fact]
        public void ContainsIgnoringCaseFailTest()
        {
            StringAssertion.ContainsIgnoringCase("5ft5fre453f34");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that the assertion passes if the value does not contain a substring while ignoring cases.
        /// </summary>
        [Fact]
        public void DoesNotContainIgnoringCasePassTest()
        {
            StringAssertion.DoesNotContainIgnoringCase("f457h905f435nh9mfht5");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that the assertion fails if the value contains a substring while ignoring cases.
        /// </summary>
        [Fact]
        public void DoesNotContainIgnoringCaseFailTest()
        {
            StringAssertion.DoesNotContainIgnoringCase("T");
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
