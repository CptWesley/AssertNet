using AssertNet.AssertionTypes;
using AssertNet.FailureHandlers;
using AssertNet.Moq.Mocks;
using Xunit.Sdk;

namespace AssertNet.Moq.Tests.Mocks;

/// <summary>
/// Test class for the <see cref="SetPropertyInvocationAssertion{T}"/> class.
/// </summary>
public class SetPropertyInvocationAssertionTests
{
    private readonly SetPropertyInvocationAssertion<IMockable> _assertion;
    private readonly Mock<IMockable> _target;
    private readonly Action<IMockable> _expression;

    /// <summary>
    /// Initializes a new instance of the <see cref="SetPropertyInvocationAssertionTests"/> class.
    /// </summary>
    public SetPropertyInvocationAssertionTests()
    {
        _target = new Mock<IMockable>(MockBehavior.Loose);
        _expression = x => x.Number = It.IsAny<int>();
        _assertion = new SetPropertyInvocationAssertion<IMockable>(
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
    /// Checks that we pass when the set has never occured.
    /// </summary>
    [Fact]
    public void NeverPassTest()
    {
        Assert.Same(_target, _assertion.Never().Subject);
    }

    /// <summary>
    /// Checks that we fail when the set has occured.
    /// </summary>
    [Fact]
    public void NeverFailTest()
    {
        _target.Object.Number = 42;
        Assert.Throws<XunitException>(() => _assertion.Never());
    }

    /// <summary>
    /// Checks that we pass when the set has occured.
    /// </summary>
    [Fact]
    public void OncePassTest()
    {
        _target.Object.Number = 443;
        Assert.Same(_target, _assertion.Once().Subject);
    }

    /// <summary>
    /// Checks that we fail when the set has never occured.
    /// </summary>
    [Fact]
    public void OnceFailTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Once());
        _target.Object.Number = 43564563;
        _target.Object.Number = 43562;
        Assert.Throws<XunitException>(() => _assertion.Once());
    }

    /// <summary>
    /// Checks that we pass when at least 1 set has occured.
    /// </summary>
    [Fact]
    public void AtLeastOnceTest()
    {
        Assert.Throws<XunitException>(() => _assertion.AtLeastOnce());
        _target.Object.Number = 56454;
        Assert.Same(_target, _assertion.AtLeastOnce().Subject);
        _target.Object.Number = 324432;
        Assert.Same(_target, _assertion.AtLeastOnce().Subject);
    }

    /// <summary>
    /// Checks that we pass when at most 1 set has occured.
    /// </summary>
    [Fact]
    public void AtMostOnce()
    {
        Assert.Same(_target, _assertion.AtMostOnce().Subject);
        _target.Object.Number = 11;
        Assert.Same(_target, _assertion.AtMostOnce().Subject);
        _target.Object.Number = 23;
        Assert.Throws<XunitException>(() => _assertion.AtMostOnce());
    }

    /// <summary>
    /// Checks that we pass when at least 1 set has occured.
    /// </summary>
    [Fact]
    public void AtLeastTest()
    {
        Assert.Throws<XunitException>(() => _assertion.AtLeast(1));
        _target.Object.Number = 38;
        Assert.Same(_target, _assertion.AtLeast(1).Subject);
        _target.Object.Number = 27;
        Assert.Same(_target, _assertion.AtLeast(1).Subject);
    }

    /// <summary>
    /// Checks that we pass when at most 2 sets have occured.
    /// </summary>
    [Fact]
    public void AtMostTest()
    {
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _target.Object.Number = 34765;
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _target.Object.Number = 345435;
        Assert.Same(_target, _assertion.AtMost(2).Subject);
        _target.Object.Number = 3457457;
        Assert.Throws<XunitException>(() => _assertion.AtMost(2));
    }

    /// <summary>
    /// Checks that we pass when exactly 2 sets have occured.
    /// </summary>
    [Fact]
    public void ExactlyTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
        _target.Object.Number = 23;
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
        _target.Object.Number = 6455436;
        Assert.Same(_target, _assertion.Exactly(2).Subject);
        _target.Object.Number = 435;
        Assert.Throws<XunitException>(() => _assertion.Exactly(2));
    }

    /// <summary>
    /// Checks that we pass when between 1 and 2 sets have occured.
    /// </summary>
    [Fact]
    public void BetweenTest()
    {
        Assert.Throws<XunitException>(() => _assertion.Between(1, 2));
        _target.Object.Number = 42345;
        Assert.Same(_target, _assertion.Between(1, 2).Subject);
        _target.Object.Number = 345;
        Assert.Same(_target, _assertion.Between(1, 2).Subject);
        _target.Object.Number = 3456543;
        Assert.Throws<XunitException>(() => _assertion.Between(1, 2));
    }
}
