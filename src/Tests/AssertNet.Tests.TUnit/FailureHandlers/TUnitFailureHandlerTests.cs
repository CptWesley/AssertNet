using AssertNet.FailureHandlers;

namespace AssertNet.Tests.TUnit.FailureHandlers;

/// <summary>
/// Test class for the <see cref="TUnitFailureHandler"/> class.
/// </summary>
public class TUnitFailureHandlerTests
{
    private readonly TUnitFailureHandler handler;

    /// <summary>
    /// Initializes a new instance of the <see cref="TUnitFailureHandlerTests"/> class.
    /// </summary>
    public TUnitFailureHandlerTests()
    {
        handler = new TUnitFailureHandler();
    }

    /// <summary>
    /// Checks that the handler is available.
    /// </summary>
    /// <returns>The test task.</returns>
    [Test]
    public async Task AvailableTest()
    {
        await Assert.That(handler.IsAvailable()).IsTrue();
    }

    /// <summary>
    /// Tests that calling a failure throws the correct exception.
    /// </summary>
    /// <returns>The test task.</returns>
    [Test]
    public async Task FailTest()
    {
        var msg = "435h9d 432 0";
        var e = Assert.Throws<global::TUnit.Assertions.Exceptions.AssertionException>(() => handler.Fail(msg));
        await Assert.That(e.Message).IsEqualTo(msg);
    }
}
