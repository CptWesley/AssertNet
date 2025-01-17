using System.Linq.Expressions;
using AssertNet.AssertionTypes;
using AssertNet.FailureHandlers;
using AssertNet.Moq.Mocks;
using Xunit.Sdk;

namespace AssertNet.Moq.Tests.Mocks;

/// <summary>
/// Test class for the <see cref="MethodInvocationAssertion{T, TProperty}"/> class.
/// </summary>
public class MethodInvocationAssertionTests
{
    private readonly MethodInvocationAssertion<IMockable, int> _assertion;
    private readonly Mock<IMockable> _target;
    private readonly Expression<Func<IMockable, int>> _expression;

    /// <summary>
    /// Initializes a new instance of the <see cref="MethodInvocationAssertionTests"/> class.
    /// </summary>
    public MethodInvocationAssertionTests()
    {
        _target = new Mock<IMockable>(MockBehavior.Loose);
        _expression = x => x.Number;
        _assertion = new MethodInvocationAssertion<IMockable, int>(
            new Assertion<Mock<IMockable>>(FailureHandlerFactory.Create(), _target),
            _expression);
    }

    /// <summary>
    /// Checks that the target is set correctly.
    /// </summary>
    [Fact]
    public void TargetTest()
    {
        Assert.Same(_target, _assertion.Subject);
    }

    /// <summary>
    /// Checks that the target is set correctly.
    /// </summary>
    [Fact]
    public void ExpressionTest()
    {
        Assert.Same(_expression, _assertion.Expression);
    }

    /// <summary>
    /// Checks that we pass when the get has never occured.
    /// </summary>
    [Fact]
    public void NeverPassTest()
    {
        Assert.Same(_target, _assertion.Never().Subject);
    }

    /// <summary>
    /// Checks that we fail when the get has occured.
    /// </summary>
    [Fact]
    public void NeverFailTest()
    {
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.Never());
    }

    /// <summary>
    /// Checks that we pass when the get has occured.
    /// </summary>
    [Fact]
    public void OncePassTest()
    {
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.Once().Subject);
    }

    /// <summary>
    /// Checks that we fail when the get has never occured.
    /// </summary>
    [Fact]
    public void OnceFailTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Once());
        _ = _target.Object.Number;
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.Once());
    }

    /// <summary>
    /// Checks that we pass when at least 1 get has occured.
    /// </summary>
    [Fact]
    public void AtLeastOnceTest()
    {
        Assert.Throws<XunitException>(() => _assertion.AtLeastOnce());
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtLeastOnce().Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtLeastOnce().Subject);
    }

    /// <summary>
    /// Checks that we pass when at most 1 get has occured.
    /// </summary>
    [Fact]
    public void AtMostOnce()
    {
        Assert.Same(_target, _assertion.AtMostOnce().Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtMostOnce().Subject);
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.AtMostOnce());
    }

    /// <summary>
    /// Checks that we pass when at least 1 get has occured.
    /// </summary>
    [Fact]
    public void AtLeastTest()
    {
        Assert.Throws<XunitException>(() => _assertion.AtLeast(1));
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtLeast(1).Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtLeast(1).Subject);
    }

    /// <summary>
    /// Checks that we pass when at most 2 gets have occured.
    /// </summary>
    [Fact]
    public void AtMostTest()
    {
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.AtMost(2));
    }

    /// <summary>
    /// Checks that we pass when exactly 2 gets have occured.
    /// </summary>
    [Fact]
    public void ExactlyTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.Exactly(2).Subject);
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
    }

    /// <summary>
    /// Checks that we pass when between 1 and 2 gets have occured.
    /// </summary>
    [Fact]
    public void BetweenTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Between(1, 2));
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.Between(1, 2).Subject);
        _ = _target.Object.Number;
        Assert.Same(_target, _assertion.Between(1, 2).Subject);
        _ = _target.Object.Number;
        Assert.Throws<XunitException>(() => _assertion.Between(1, 2));
    }
}
