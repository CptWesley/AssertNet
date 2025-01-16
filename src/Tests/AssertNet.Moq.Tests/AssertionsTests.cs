using AssertNet.Moq.Mocks;
using static AssertNet.AssertionBuilder;

namespace AssertNet.Moq.Tests;

/// <summary>
/// Test class for the <see cref="Assertions"/> class.
/// </summary>
public static class AssertionsTests
{
    /// <summary>
    /// Checks that the assertion is created correctly.
    /// </summary>
    [Fact]
    public static void AssertThatTest()
    {
        var target = new Mock<object>();
        var assertion = Asserts.That(target);
        Assert.NotNull(assertion);
        Assert.Same(target, assertion.Subject);
    }
}
