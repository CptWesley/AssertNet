using AssertNet.AssertionTypes;
using AssertNet.Failures;
using AssertNet.FailureHandlers;
using System.Numerics;

namespace AssertNet.Tests;

public class Asserts_That
{
    [Fact]
    public void supports_fluent_syntax()
    {
        Asserts.That("123").Contains("2");
    }

    [Fact]
    public void is_extendable()
    {
        Asserts.That(6.0).IsFinite();
    }
}
