﻿using System;
using System.Linq.Expressions;
using AssertNet.Moq.Mocks;
using Moq;
using Xunit;

namespace AssertNet.Moq.Tests.Mocks
{
    /// <summary>
    /// Test class for the <see cref="MockAssertion{T}"/> class.
    /// </summary>
    public class MockAssertionTests
    {
        private readonly MockAssertion<IMockable> _assertion;
        private readonly Mock<IMockable> _target;

        /// <summary>
        /// Initializes a new instance of the <see cref="MockAssertionTests"/> class.
        /// </summary>
        public MockAssertionTests()
        {
            _target = new Mock<IMockable>();
            _assertion = new MockAssertion<IMockable>(_target);
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
        /// Checks that a correct assertion is created when we make an assertion about an invocation.
        /// </summary>
        [Fact]
        public void HasInvokedTest()
        {
            Expression<Action<IMockable>> expression = x => x.GetInt();
            InvocationAssertion<IMockable> assertion = _assertion.HasInvoked(expression);
            Assert.NotNull(assertion);
            Assert.IsType<VoidMethodInvocationAssertion<IMockable>>(assertion);
            Assert.Same(_target, assertion.Target);
            Assert.Same(expression, ((VoidMethodInvocationAssertion<IMockable>)assertion).Expression);
        }

        /// <summary>
        /// Checks that a correct assertion is created when we make an assertion about a property request.
        /// </summary>
        [Fact]
        public void HasInvokedPropertyGetTest()
        {
            Expression<Func<IMockable, int>> expression = x => x.Number;
            InvocationAssertion<IMockable> assertion = _assertion.HasInvoked(expression);
            Assert.NotNull(assertion);
            Assert.IsType<MethodInvocationAssertion<IMockable, int>>(assertion);
            Assert.Same(_target, assertion.Target);
            Assert.Same(expression, ((MethodInvocationAssertion<IMockable, int>)assertion).Expression);
        }

        /// <summary>
        /// Checks that a correct assertion is created when we make an assertion about a property set expression.
        /// </summary>
        [Fact]
        public void HasInvokedPropertySetTest()
        {
            Action<IMockable> expression = x => x.Number = 3;
            InvocationAssertion<IMockable> assertion = _assertion.HasAssigned(expression);
            Assert.NotNull(assertion);
            Assert.IsType<SetPropertyInvocationAssertion<IMockable>>(assertion);
            Assert.Same(_target, assertion.Target);
            Assert.Same(expression, ((SetPropertyInvocationAssertion<IMockable>)assertion).Expression);
        }

        /// <summary>
        /// Checks that we can correctly verify that no other calls have been made on the mock object.
        /// </summary>
        [Fact]
        public void HasNotPerformedOtherInvocationsTest()
        {
            Assert.Same(_target, _assertion.HasNotPerformedOtherInvocations().Target);
        }
    }
}
