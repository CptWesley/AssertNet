using AssertNet.FailureHandlers;

namespace AssertNet.Tests.Xunit.FailureHandlers;

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
        Assert.That(FailureHandlerFactory.Create(), Is.InstanceOf<NunitFailureHandler>());
    }
}
