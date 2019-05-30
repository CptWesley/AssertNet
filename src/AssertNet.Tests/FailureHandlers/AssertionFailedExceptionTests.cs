using System;
using AssertNet.FailureHandlers;
using Xunit;

namespace AssertNet.Tests.FailureHandlers
{
    /// <summary>
    /// Test class for the <see cref="AssertionFailedException"/> class.
    /// </summary>
    public static class AssertionFailedExceptionTests
    {
        /// <summary>
        /// Checks that the normal exception works correctly.
        /// </summary>
        [Fact]
        public static void NormalTest()
        {
            Exception e = new AssertionFailedException();
            Assert.Null(e.InnerException);
            Assert.Equal("Exception of type 'AssertNet.FailureHandlers.AssertionFailedException' was thrown.", e.Message);
        }

        /// <summary>
        /// Checks that the exception with message works correctly.
        /// </summary>
        [Fact]
        public static void MessageTest()
        {
            Exception e = new AssertionFailedException("bla");
            Assert.Null(e.InnerException);
            Assert.Equal("bla", e.Message);
        }

        /// <summary>
        /// Checks that the exception with message works correctly.
        /// </summary>
        [Fact]
        public static void InnerTest()
        {
            Exception inner = new ArgumentException(string.Empty);
            Exception e = new AssertionFailedException("blu", inner);
            Assert.Same(inner, e.InnerException);
            Assert.Equal("blu", e.Message);
        }
    }
}
