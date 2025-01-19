using AssertNet.AssertionTypes;

namespace AssertNet.Tests;

/// <summary>
/// Test class for the <see cref="Assertions"/> class.
/// </summary>
public static class AssertionsTests
{
    /// <summary>
    /// Checks that void assertions are created correctly.
    /// </summary>
    [Fact]
    public static void VoidAssertionTest()
    {
        IAssertion assertion = Asserts.That(() => { });
        Assert.NotNull(assertion);
        Assert.IsType<Sut<Action>>(assertion);
    }

    /// <summary>
    /// Checks that exception assertions are created correctly.
    /// </summary>
    [Fact]
    public static void ExceptionAssertionTest()
    {
        IAssertion assertion = Asserts.That(new Exception());
        Assert.NotNull(assertion);
        Assert.IsType<Sut<Exception>>(assertion);
    }

    /// <summary>
    /// Checks that boolean assertions are created correctly.
    /// </summary>
    [Fact]
    public static void BooleanAssertionTest()
    {
        IAssertion assertion = Asserts.That(true);
        Assert.NotNull(assertion);
        Assert.IsType<Sut<bool>>(assertion);
    }

    /// <summary>
    /// Checks that double assertions are created correctly.
    /// </summary>
    [Fact]
    public static void DoubleAssertionTest()
    {
        IAssertion assertion = Asserts.That(4.5);
        Assert.NotNull(assertion);
        Assert.IsType<Sut<double>>(assertion);
    }

    /// <summary>
    /// Checks that string assertions are created correctly.
    /// </summary>
    [Fact]
    public static void StringAssertionTest()
    {
        IAssertion assertion = Asserts.That(string.Empty);
        Assert.NotNull(assertion);
        Assert.IsType<Sut<string>>(assertion);
    }

    /// <summary>
    /// Checks that collection assertions are created correctly.
    /// </summary>
    [Fact]
    public static void CollectionAssertionTest()
    {
        IAssertion assertion = Asserts.That(Array.Empty<int>());
        Assert.NotNull(assertion);
        Assert.IsType<Sut<int[]>>(assertion);
    }

    /// <summary>
    /// Checks that single object assertions are created correctly.
    /// </summary>
    [Fact]
    public static void SingleAssertionTest()
    {
        IAssertion assertion = Asserts.That(new object());
        Assert.NotNull(assertion);
        Assert.IsType<Sut<object?>>(assertion);
    }
}
