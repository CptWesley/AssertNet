﻿using Moq;

namespace AssertNet.Core.Tests
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
    }
}
