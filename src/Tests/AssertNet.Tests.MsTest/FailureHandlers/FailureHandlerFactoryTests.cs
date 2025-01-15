using AssertNet.FailureHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertNet.Tests.MsTest.FailureHandlers;

/// <summary>
/// Test class for the <see cref="FailureHandlerFactory"/> class.
/// </summary>
[TestClass]
public class FailureHandlerFactoryTests
{
    /// <summary>
    /// Checks that the factory creates the correct type.
    /// </summary>
    [TestMethod]
    public void FactoryTest()
    {
        Assert.IsInstanceOfType(FailureHandlerFactory.Create(), typeof(MsTestFailureHandler));
    }
}
