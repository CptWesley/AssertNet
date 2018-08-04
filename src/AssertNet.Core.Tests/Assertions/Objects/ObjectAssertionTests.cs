using AssertNet.Core.Assertions.Objects;
using AssertNet.Core.Failures;
using Moq;
using Xunit;

namespace AssertNet.Core.Tests.Assertions.Objects
{
    /// <summary>
    /// Test class for the <see cref="ObjectAssertion{TAssert, TTarget}"/> class.
    /// </summary>
    /// <typeparam name="T1">Type of the assertion.</typeparam>
    /// <typeparam name="T2">Type of the object under test.</typeparam>
    public abstract class ObjectAssertionTests<T1, T2>
        where T1 : ObjectAssertion<T1, T2>
    {
        /// <summary>
        /// Gets or sets the assertion under test.
        /// </summary>
        /// <value>
        /// The assertion under test.
        /// </value>
        protected ObjectAssertion<T1, T2> Assertion { get; set; }

        /// <summary>
        /// Gets or sets the failure handler.
        /// </summary>
        /// <value>
        /// The failure handler.
        /// </value>
        protected Mock<IFailureHandler> FailureHandler { get; set; }

        /// <summary>
        /// Checks that there are no failures if the objects are equal.
        /// </summary>
        [Fact]
        public void IsEqualToTrueTest()
        {
            Assertion.IsEqualTo(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are not equal.
        /// </summary>
        [Fact]
        public void IsEqualToFalseTest()
        {
            Assertion.IsEqualTo(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the objects are not equal.
        /// </summary>
        [Fact]
        public void IsNotEqualToTrueTest()
        {
            Assertion.IsNotEqualTo(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are equal.
        /// </summary>
        [Fact]
        public void IsNotEqualToFalseTest()
        {
            Assertion.IsNotEqualTo(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the objects are the same.
        /// </summary>
        [Fact]
        public void IsSameAsTrueTest()
        {
            Assertion.IsSameAs(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are not the same.
        /// </summary>
        [Fact]
        public void IsSameAsFalseTest()
        {
            Assertion.IsSameAs(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the objects are not the same.
        /// </summary>
        [Fact]
        public void IsNotSameAsTrueTest()
        {
            Assertion.IsNotSameAs(null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the objects are the same.
        /// </summary>
        [Fact]
        public void IsNotSameAsFalseTest()
        {
            Assertion.IsNotSameAs(Assertion.Target);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the object is correctly not null.
        /// </summary>
        [Fact]
        public void IsNotNullPassTest()
        {
            Assertion.IsNotNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the object is incorrectly not null.
        /// </summary>
        [Fact]
        public void IsNullFailTest()
        {
            Assertion.IsNull();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if an object is an instance of a type.
        /// </summary>
        [Fact]
        public void IsInstanceOfPassTest()
        {
            Assertion.IsInstanceOf<object>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are no failures if an object is an instance of a type.
        /// </summary>
        [Fact]
        public void IsInstanceOfPassSameTest()
        {
            Assertion.IsInstanceOf(Assertion.Target.GetType());
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if an object is not an instance of a type.
        /// </summary>
        [Fact]
        public void IsInstanceOfFailTest()
        {
            Assertion.IsInstanceOf<int>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if an object is not an instance of a type.
        /// </summary>
        [Fact]
        public void IsNotInstanceOfPassTest()
        {
            Assertion.IsNotInstanceOf<int>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if an object is an instance of a type.
        /// </summary>
        [Fact]
        public void IsNotInstanceOfFailTest()
        {
            Assertion.IsNotInstanceOf<object>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are failures if an object is an instance of a type.
        /// </summary>
        [Fact]
        public void IsNotInstanceOfFailSameTest()
        {
            Assertion.IsNotInstanceOf(Assertion.Target.GetType());
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are failures if an object is not exactly an instance of a type.
        /// </summary>
        [Fact]
        public void IsExactlyInstanceOfFailTest()
        {
            Assertion.IsExactlyInstanceOf<int>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if an object is not exactly an instance of a type.
        /// </summary>
        [Fact]
        public void IsNotExactlyInstanceOfPassTest()
        {
            Assertion.IsNotExactlyInstanceOf<object>();
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are no failures if an object is in an enumerable.
        /// </summary>
        [Fact]
        public void IsInPassTest()
        {
            Assertion.IsIn(new object[] { 1, 2, Assertion.Target, 3 });
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if an object is not an an enumerable.
        /// </summary>
        [Fact]
        public void IsInFailTest()
        {
            Assertion.IsIn(new object[] { 1, 2, 3 });
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if an object is not in an enumerable.
        /// </summary>
        [Fact]
        public void IsNotInPassTest()
        {
            Assertion.IsNotIn(new object[] { 1, 2, 3 });
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if an object is in an enumerable.
        /// </summary>
        [Fact]
        public void IsNotInFailTest()
        {
            Assertion.IsNotIn(new object[] { 1, 2, Assertion.Target, 3 });
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the condition holds for the object.
        /// </summary>
        [Fact]
        public void SatisfiesPassTest()
        {
            Assertion.Satisfies(x => x != null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the condition does not hold for the object.
        /// </summary>
        [Fact]
        public void SatisfiesFailTest()
        {
            Assertion.Satisfies(x => x == null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the condition does not hold for the object.
        /// </summary>
        [Fact]
        public void DoesNotSatisfyPassTest()
        {
            Assertion.DoesNotSatisfy(x => x == null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the condition holds for the object.
        /// </summary>
        [Fact]
        public void DoesNotSatisfyFailTest()
        {
            Assertion.DoesNotSatisfy(x => x != null);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the object has the right hash code.
        /// </summary>
        [Fact]
        public void HasHashCodePassTest()
        {
            Assertion.HasHashCode(Assertion.Target.GetHashCode());
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the object has a different hash code.
        /// </summary>
        [Fact]
        public void HasHashCodeFailTest()
        {
            Assertion.HasHashCode(Assertion.Target.GetHashCode() + 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }

        /// <summary>
        /// Checks that there are no failures if the object has a different hash code.
        /// </summary>
        [Fact]
        public void DoesNotHaveHashCodePassTest()
        {
            Assertion.DoesNotHaveHashCode(Assertion.Target.GetHashCode() - 1);
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
        }

        /// <summary>
        /// Checks that there are failures if the object has the given hash code.
        /// </summary>
        [Fact]
        public void DoesNotHaveHashCodeFailTest()
        {
            Assertion.DoesNotHaveHashCode(Assertion.Target.GetHashCode());
            FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
        }
    }
}
