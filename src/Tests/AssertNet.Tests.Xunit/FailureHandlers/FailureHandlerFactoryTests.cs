using AssertNet.FailureHandlers;
using Xunit;

namespace AssertNet.Tests.Xunit.FailureHandlers;

/// <summary>
/// Test class for the <see cref="FailureHandlerFactory"/> class.
/// </summary>
public static class FailureHandlerFactoryTests
{
    /// <summary>
    /// Checks that the factory creates the correct type.
    /// </summary>
    [Fact]
    public static void FactoryTest()
    {
        Assert.IsType<XunitFailureHandler>(FailureHandlerFactory.Create());
    }
}
