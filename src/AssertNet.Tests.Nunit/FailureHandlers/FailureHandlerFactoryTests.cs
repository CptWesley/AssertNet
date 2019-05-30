using AssertNet.FailureHandlers;
using NUnit.Framework;

namespace AssertNet.Tests.Xunit.FailureHandlers
{
    /// <summary>
    /// Test class for the <see cref="FailureHandlerFactory"/> class.
    /// </summary>
    [TestFixture]
    public static class FailureHandlerFactoryTests
    {
        /// <summary>
        /// Checks that the factory creates the correct type.
        /// </summary>
        [Test]
        public static void FactoryTest()
        {
            Assert.IsInstanceOf<NunitFailureHandler>(FailureHandlerFactory.Create());
        }
    }
}
