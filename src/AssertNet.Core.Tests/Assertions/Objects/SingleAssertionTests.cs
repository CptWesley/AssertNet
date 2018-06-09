﻿using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.FailureHandlers;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="SingleAssertion"/> class.
    /// </summary>
    public class SingleAssertionTests : ObjectAssertionTests<SingleAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="SingleAssertionTests"/> class.
        /// </summary>
        public SingleAssertionTests()
        {
            FailureHandler = new Mock<IFailureHandler>();
            Assertion = new SingleAssertion(FailureHandler.Object, "bery43566435fgdtfg");
        }

        /// <summary>
        /// Checks that there are no failures if the object is incorrectly null.
        /// </summary>
        [Fact]
        public void IsNotNullFailTest()
        {
            Assertion = new SingleAssertion(FailureHandler.Object, null);
            Assertion.IsNotNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are failures if the object is correctly null.
        /// </summary>
        [Fact]
        public void IsNullPassTest()
        {
            Assertion = new SingleAssertion(FailureHandler.Object, null);
            Assertion.IsNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }
    }
}
