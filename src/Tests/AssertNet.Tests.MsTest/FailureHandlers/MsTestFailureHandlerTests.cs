using System;
using AssertNet.FailureHandlers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AssertNet.Tests.MsTest.FailureHandlers;

/// <summary>
/// Test class for the <see cref="MsTestFailureHandler"/> class.
/// </summary>
[TestClass]
public class MsTestFailureHandlerTests
{
    private readonly MsTestFailureHandler handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="MsTestFailureHandlerTests"/> class.
    /// </summary>
    public MsTestFailureHandlerTests()
    {
        handler = new MsTestFailureHandler();
    }

    /// <summary>
    /// Checks that the handler is available.
    /// </summary>
    [TestMethod]
    public void AvailableTest()
    {
        Assert.IsTrue(handler.IsAvailable());
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
            handler.Fail(msg);
        }
        catch (AssertFailedException e)
        {
            exception = e;
        }

        Assert.IsNotNull(exception);
        Assert.AreEqual(msg, exception.Message);
    }
}
