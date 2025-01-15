using AssertNet.Core.AssertionTypes;
using AssertNet.Core.Failures;
using AssertNet.FailureHandlers;
using System.Numerics;
using static AssertNet.Asserter;

namespace AssertNet.Tests;

public class Asserts_That
{
    [Fact]
    public void supports_fluent_syntax()
    {
        Asserts.That(3).IsEqualTo(3);
    }

    [Fact]
    public void is_extendable()
    {
        Asserts.ThatX(6m).IsEven();
    }
}

file static class AssertionExtensions
{
    public static NumberAssertion<TNumber> ThatX<TNumber>(this Asserter _, TNumber value) where TNumber : struct, INumber<TNumber>
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
