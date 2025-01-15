using System;
using System.Linq.Expressions;
using AssertNet.Moq.Mocks;
using Moq;
using Xunit;

namespace AssertNet.Moq.Tests.Mocks
{
    /// <summary>
    /// Test class for the <see cref="VoidMethodInvocationAssertion{T}"/> class.
    /// </summary>
    public class VoidMethodInvocationAssertionTests
    {
        private readonly VoidMethodInvocationAssertion<IMockable> _assertion;
        private readonly Mock<IMockable> _target;
        private readonly Expression<Action<IMockable>> _expression;

        /// <summary>
        /// Initializes a new instance of the <see cref="VoidMethodInvocationAssertionTests"/> class.
        /// </summary>
        public VoidMethodInvocationAssertionTests()
        {
            _target = new Mock<IMockable>();
            _expression = x => x.GetInt();
            _assertion = new VoidMethodInvocationAssertion<IMockable>(_target, _expression);
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

        /// <summary>
        /// Checks that we pass when the invocation has never occured.
        /// </summary>
        [Fact]
        public void NeverPassTest()
        {
            Assert.Same(_target, _assertion.Never().Target);
        }

        /// <summary>
        /// Checks that we fail when the invocation has occured.
        /// </summary>
        [Fact]
        public void NeverFailTest()
        {
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.Never());
        }

        /// <summary>
        /// Checks that we pass when the invocation has occured.
        /// </summary>
        [Fact]
        public void OncePassTest()
        {
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.Once().Target);
        }

        /// <summary>
        /// Checks that we fail when the invocation has never occured.
        /// </summary>
        [Fact]
        public void OnceFailTest()
        {
            Assert.Throws<MockException>(() => _assertion.Once());
            _target.Object.GetInt();
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.Once());
        }

        /// <summary>
        /// Checks that we pass when at least 1 invocation has occured.
        /// </summary>
        [Fact]
        public void AtLeastOnceTest()
        {
            Assert.Throws<MockException>(() => _assertion.AtLeastOnce());
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtLeastOnce().Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtLeastOnce().Target);
        }

        /// <summary>
        /// Checks that we pass when at most 1 invocation has occured.
        /// </summary>
        [Fact]
        public void AtMostOnce()
        {
            Assert.Same(_target, _assertion.AtMostOnce().Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtMostOnce().Target);
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.AtMostOnce());
        }

        /// <summary>
        /// Checks that we pass when at least 1 invocation has occured.
        /// </summary>
        [Fact]
        public void AtLeastTest()
        {
            Assert.Throws<MockException>(() => _assertion.AtLeast(1));
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtLeast(1).Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtLeast(1).Target);
        }

        /// <summary>
        /// Checks that we pass when at most 2 invocations have occured.
        /// </summary>
        [Fact]
        public void AtMostTest()
        {
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.AtMost(2));
        }

        /// <summary>
        /// Checks that we pass when exactly 2 invocation have occured.
        /// </summary>
        [Fact]
        public void ExactlyTest()
        {
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.Exactly(2).Target);
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
        }

        /// <summary>
        /// Checks that we pass when between 1 and 2 invocation have occured.
        /// </summary>
        [Fact]
        public void BetweenTest()
        {
            Assert.Throws<MockException>(() => _assertion.Between(1, 2));
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.Between(1, 2).Target);
            _target.Object.GetInt();
            Assert.Same(_target, _assertion.Between(1, 2).Target);
            _target.Object.GetInt();
            Assert.Throws<MockException>(() => _assertion.Between(1, 2));
        }
    }
}
