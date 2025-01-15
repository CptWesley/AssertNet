using AssertNet.FailureHandlers;

namespace AssertNet.Tests.TUnit.FailureHandlers;

public class FailureHandlerFactoryTests
{
    /// <summary>
    /// Checks that the factory creates the correct type.
    /// </summary>
    /// <returns>The test task.</returns>
    [Test]
    public async Task FactoryTest()
    {
        await Assert.That(FailureHandlerFactory.Create()).IsTypeOf<TUnitFailureHandler>();
    }
}
