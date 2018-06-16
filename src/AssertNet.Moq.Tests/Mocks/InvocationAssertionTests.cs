using System;
using System.Linq.Expressions;
using AssertNet.Moq.Mocks;
using Moq;
using Xunit;

namespace AssertNet.Moq.Tests.Mocks
{
    /// <summary>
    /// Test class for the <see cref="InvocationAssertion{T}"/> class.
    /// </summary>
    public class InvocationAssertionTests
    {
        private readonly InvocationAssertion<IMockable> _assertion;
        private readonly Mock<IMockable> _target;
        private readonly Expression<Action<IMockable>> _expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="InvocationAssertionTests"/> class.
        /// </summary>
        public InvocationAssertionTests()
        {
            _target = new Mock<IMockable>();
            _expression = x => x.GetInt();
            _assertion = new InvocationAssertion<IMockable>(_target, _expression);
        }

        /// <summary>
        /// Checks that the target is set correctly.
        /// </summary>
        [Fact]
        public void TargetTest()
        {
            Assert.Same(_target, _assertion.Target);
        }

        /// <summary>
        /// Checks that the target is set correctly.
        /// </summary>
        [Fact]
        public void ExpressionTest()
        {
            Assert.Same(_expression, _assertion.Expression);
        }
    }
}
