using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertNet.MSTest.Tests
{
    /// <summary>
    /// Test class for the <see cref="MSTestFailureHandler"/> class.
    /// </summary>
    [TestClass]
    public class MSTestFailureHandlerTests
    {
        private MSTestFailureHandler _handler;

        /// <summary>
        /// Initializes a new instance of the <see cref="MSTestFailureHandlerTests"/> class.
        /// </summary>
        public MSTestFailureHandlerTests()
        {
            _handler = new MSTestFailureHandler();
        }

        /// <summary>
        /// Tests that calling a failure throws the correct exception.
        /// </summary>
        [TestMethod]
        public void FailTest()
        {
            string msg = "f4357gn48gm";
            Exception exception = null;
            try
            {
                _handler.Fail(msg);
            }
            catch (AssertFailedException e)
            {
                exception = e;
            }

            Assert.IsNotNull(exception);
            Assert.AreEqual(msg, exception.Message);
        }
    }
}
