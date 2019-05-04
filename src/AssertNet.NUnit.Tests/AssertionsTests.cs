using System;
using AssertNet.Core.AssertionTypes;
using AssertNet.Core.AssertionTypes.Objects;
using AssertNet.Core.AssertionTypes.Void;
using AssertNet.NUnit;
using NUnit.Framework;
using static AssertNet.NUnit.Assertions;

namespace AssertNet.Nunit.Tests
{
    /// <summary>
    /// Test class for the <see cref="Assertions"/> class.
    /// </summary>
    [TestFixture]
    public static class AssertionsTests
    {
        /// <summary>
        /// Checks that void assertions are created correctly.
        /// </summary>
        [Test]
        public static void VoidAssertionTest()
        {
            Assertion assertion = AssertThat(() => { });
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<VoidAssertion>(assertion);
        }

        /// <summary>
        /// Checks that exception assertions are created correctly.
        /// </summary>
        [Test]
        public static void ExceptionAssertionTest()
        {
            Assertion assertion = AssertThat(new Exception());
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<ExceptionAssertion>(assertion);
        }

        /// <summary>
        /// Checks that boolean assertions are created correctly.
        /// </summary>
        [Test]
        public static void BooleanAssertionTest()
        {
            Assertion assertion = AssertThat(true);
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<BooleanAssertion>(assertion);
        }

        /// <summary>
        /// Checks that double assertions are created correctly.
        /// </summary>
        [Test]
        public static void DoubleAssertionTest()
        {
            Assertion assertion = AssertThat(4.5);
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<DoubleAssertion>(assertion);
        }

        /// <summary>
        /// Checks that string assertions are created correctly.
        /// </summary>
        [Test]
        public static void StringAssertionTest()
        {
            Assertion assertion = AssertThat(string.Empty);
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<StringAssertion>(assertion);
        }

        /// <summary>
        /// Checks that collection assertions are created correctly.
        /// </summary>
        [Test]
        public static void CollectionAssertionTest()
        {
            Assertion assertion = AssertThat(Array.Empty<int>());
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<EnumerableAssertion<int>>(assertion);
        }

        /// <summary>
        /// Checks that single object assertions are created correctly.
        /// </summary>
        [Test]
        public static void SingleAssertionTest()
        {
            Assertion assertion = AssertThat(new object());
            Assert.NotNull(assertion);
            Assert.IsInstanceOf<SingleAssertion>(assertion);
        }
    }
}
