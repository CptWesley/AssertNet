using System;
using AssertNet.Core.Assertions;
using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.Assertions.Void;
using AssertNet.MSTest;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using static AssertNet.MSTest.Assertions;

namespace AssertNet.Nunit.Tests
{
    /// <summary>
    /// Test class for the <see cref="Assertions"/> class.
    /// </summary>
    [TestClass]
    public class AssertionsTests
    {
        /// <summary>
        /// Checks that void assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void VoidAssertionTest()
        {
            Assertion assertion = AssertThat(() => { });
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(VoidAssertion));
        }

        /// <summary>
        /// Checks that exception assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void ExceptionAssertionTest()
        {
            Assertion assertion = AssertThat(new Exception());
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(ExceptionAssertion));
        }

        /// <summary>
        /// Checks that boolean assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void BooleanAssertionTest()
        {
            Assertion assertion = AssertThat(true);
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(BooleanAssertion));
        }

        /// <summary>
        /// Checks that double assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void DoubleAssertionTest()
        {
            Assertion assertion = AssertThat(4.5);
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(DoubleAssertion));
        }

        /// <summary>
        /// Checks that string assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void StringAssertionTest()
        {
            Assertion assertion = AssertThat(string.Empty);
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(StringAssertion));
        }

        /// <summary>
        /// Checks that collection assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void CollectionAssertionTest()
        {
            Assertion assertion = AssertThat(Array.Empty<int>());
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(CollectionAssertion));
        }

        /// <summary>
        /// Checks that single object assertions are created correctly.
        /// </summary>
        [TestMethod]
        public void SingleAssertionTest()
        {
            Assertion assertion = AssertThat(new object());
            Assert.IsNotNull(assertion);
            Assert.IsInstanceOfType(assertion, typeof(SingleAssertion));
        }
    }
}
