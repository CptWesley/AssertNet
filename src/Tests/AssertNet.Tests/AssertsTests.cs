using AssertNet.Core.AssertionTypes;
using AssertNet.Core.Failures;
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
    public void supports_generics_with()
    {
        var assertion = new Assertion<int[]>([1, 2, 3, 4], FailureHandlerFactory.Create());
        assertion.Contains(4);
    }

    [Fact]
    public void is_extendable()
    {
        Asserts.That(6m).IsEven();
    }
}

file static class AssertionExtensions
{
    public static NumberAssertion<TNumber> That<TNumber>(this AssertionBuilder _, TNumber value) where TNumber : struct, INumber<TNumber>
    {
        return new(FailureHandlerFactory.Create(), value);
    }
}

file sealed class NumberAssertion<TNumber>(IFailureHandler failureHandler, TNumber value) : Assertion(failureHandler) where TNumber : struct, INumber<TNumber>
{
    public void IsEven()
    {
        var two = TNumber.One + TNumber.One;
        if (value % two != TNumber.Zero)
        {
            Fail($"{value} is odd.");
        }
    }
}
