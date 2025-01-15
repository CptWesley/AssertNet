﻿using System;
using System.Linq.Expressions;
using AssertNet.Moq.Mocks;
using Moq;
using Xunit;

namespace AssertNet.Moq.Tests.Mocks
{
    /// <summary>
    /// Test class for the <see cref="MethodInvocationAssertion{T, TProperty}"/> class.
    /// </summary>
    public class MethodInvocationAssertionTests
    {
        private readonly MethodInvocationAssertion<IMockable, int> _assertion;
        private readonly Mock<IMockable> _target;
        private readonly Expression<Func<IMockable, int>> _expression;

        private int _val;

        /// <summary>
        /// Initializes a new instance of the <see cref="MethodInvocationAssertionTests"/> class.
        /// </summary>
        public MethodInvocationAssertionTests()
        {
            _target = new Mock<IMockable>();
            _expression = x => x.Number;
            _assertion = new MethodInvocationAssertion<IMockable, int>(_target, _expression);
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
        /// Checks that we pass when the get has never occured.
        /// </summary>
        [Fact]
        public void NeverPassTest()
        {
            Assert.Same(_target, _assertion.Never().Target);
        }

        /// <summary>
        /// Checks that we fail when the get has occured.
        /// </summary>
        [Fact]
        public void NeverFailTest()
        {
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.Never());
        }

        /// <summary>
        /// Checks that we pass when the get has occured.
        /// </summary>
        [Fact]
        public void OncePassTest()
        {
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.Once().Target);
        }

        /// <summary>
        /// Checks that we fail when the get has never occured.
        /// </summary>
        [Fact]
        public void OnceFailTest()
        {
            Assert.Throws<MockException>(() => _assertion.Once());
            _val = _target.Object.Number;
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.Once());
        }

        /// <summary>
        /// Checks that we pass when at least 1 get has occured.
        /// </summary>
        [Fact]
        public void AtLeastOnceTest()
        {
            Assert.Throws<MockException>(() => _assertion.AtLeastOnce());
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtLeastOnce().Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtLeastOnce().Target);
        }

        /// <summary>
        /// Checks that we pass when at most 1 get has occured.
        /// </summary>
        [Fact]
        public void AtMostOnce()
        {
            Assert.Same(_target, _assertion.AtMostOnce().Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtMostOnce().Target);
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.AtMostOnce());
        }

        /// <summary>
        /// Checks that we pass when at least 1 get has occured.
        /// </summary>
        [Fact]
        public void AtLeastTest()
        {
            Assert.Throws<MockException>(() => _assertion.AtLeast(1));
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtLeast(1).Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtLeast(1).Target);
        }

        /// <summary>
        /// Checks that we pass when at most 2 gets have occured.
        /// </summary>
        [Fact]
        public void AtMostTest()
        {
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.AtMost(2).Target);
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.AtMost(2));
        }

        /// <summary>
        /// Checks that we pass when exactly 2 gets have occured.
        /// </summary>
        [Fact]
        public void ExactlyTest()
        {
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.Exactly(2).Target);
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.Exactly(2));
        }

        /// <summary>
        /// Checks that we pass when between 1 and 2 gets have occured.
        /// </summary>
        [Fact]
        public void BetweenTest()
        {
            Assert.Throws<MockException>(() => _assertion.Between(1, 2));
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.Between(1, 2).Target);
            _val = _target.Object.Number;
            Assert.Same(_target, _assertion.Between(1, 2).Target);
            _val = _target.Object.Number;
            Assert.Throws<MockException>(() => _assertion.Between(1, 2));
        }
    }
}
