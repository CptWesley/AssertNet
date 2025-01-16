using AssertNet.Core.AssertionTypes;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="Assertion{TAssert, TTarget}"/> class.
/// </summary>
/// <typeparam name="T1">Type of the assertion.</typeparam>
/// <typeparam name="T2">Type of the object under test.</typeparam>
[Mutable]
public abstract class ObjectAssertionTests<T1, T2>
    where T1 : Assertion<T1, T2>
{
    protected ObjectAssertionTests()
    {
        Assertion = null!;
        FailureHandler = null!;
    }

    protected ObjectAssertionTests(T2 subject)
    {
        FailureHandler = new Mock<IFailureHandler>(MockBehavior.Loose);
        Assertion = (T1)(object)CreateAssertion(subject);
    }

    /// <summary>
    /// Gets or sets the assertion under test.
    /// </summary>
    /// <value>
    /// The assertion under test.
    /// </value>
    protected T1 Assertion { get; set; }

    /// <summary>
    /// Gets or sets the failure handler.
    /// </summary>
    /// <value>
    /// The failure handler.
    /// </value>
    protected Mock<IFailureHandler> FailureHandler { get; set; }

    public IAssertion<TSubject> CreateAssertion<TSubject>(TSubject subject)
        => new Assertion<TSubject>(FailureHandler.Object, subject);

    /// <summary>
    /// Checks that there are no failures if the objects are equal.
    /// </summary>
    [Fact]
    public void IsEqualToTrueTest()
    {
        Assertion.IsEqualTo(Assertion.Subject);
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
    /// Checks that there are no failures if the objects are equal.
    /// </summary>
    [Fact]
    public void IsEquivalentToTrueTest()
    {
        Assertion.IsEquivalentTo(Assertion.Subject);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the objects are not equal.
    /// </summary>
    [Fact]
    public void IsEquivalentToFalseTest()
    {
        Assertion.IsEquivalentTo(null);
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
        Assertion.IsNotEqualTo(Assertion.Subject);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the objects are the same.
    /// </summary>
    [Fact]
    public void IsSameAsTrueTest()
    {
        Assertion.IsSameAs(Assertion.Subject);
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
        Assertion.IsNotSameAs(Assertion.Subject);
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
        Assertion.IsInstanceOf(Assertion.Subject!.GetType());
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
        Assertion.IsNotInstanceOf(Assertion.Subject!.GetType());
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
        Assertion.IsIn(new object[] { 1, 2, Assertion.Subject!, 3 });
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
        Assertion.IsNotIn(new object[] { 1, 2, Assertion.Subject!, 3 });
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the condition holds for the object.
    /// </summary>
    [Fact]
    public void SatisfiesPassTest()
    {
        Assertion.Satisfies(x => x is not null);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the condition does not hold for the object.
    /// </summary>
    [Fact]
    public void SatisfiesFailTest()
    {
        Assertion.Satisfies(x => x is null);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the condition does not hold for the object.
    /// </summary>
    [Fact]
    public void DoesNotSatisfyPassTest()
    {
        Assertion.DoesNotSatisfy(x => x is null);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the condition holds for the object.
    /// </summary>
    [Fact]
    public void DoesNotSatisfyFailTest()
    {
        Assertion.DoesNotSatisfy(x => x is not null);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the object has the right hash code.
    /// </summary>
    [Fact]
    public void HasHashCodePassTest()
    {
        Assertion.HasHashCode(Assertion.Subject!.GetHashCode());
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the object has a different hash code.
    /// </summary>
    [Fact]
    public void HasHashCodeFailTest()
    {
        Assertion.HasHashCode(Assertion.Subject!.GetHashCode() + 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the object has a different hash code.
    /// </summary>
    [Fact]
    public void DoesNotHaveHashCodePassTest()
    {
        Assertion.DoesNotHaveHashCode(Assertion.Subject!.GetHashCode() - 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the object has the given hash code.
    /// </summary>
    [Fact]
    public void DoesNotHaveHashCodeFailTest()
    {
        Assertion.DoesNotHaveHashCode(Assertion.Subject!.GetHashCode());
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the object has the right hash code.
    /// </summary>
    [Fact]
    public void HasSameHashCodeAsPassTest()
    {
        Assertion.HasSameHashCodeAs(Assertion.Subject);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the object has a different hash code.
    /// </summary>
    [Fact]
    public void HasSameHashCodeAsFailTest()
    {
        Assertion.HasSameHashCodeAs(432545324);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the object has a different hash code.
    /// </summary>
    [Fact]
    public void DoesNotHaveSameHashCodeAsPassTest()
    {
        Assertion.DoesNotHaveSameHashCodeAs(Assertion.Subject!.GetHashCode() - 1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the object has the given hash code.
    /// </summary>
    [Fact]
    public void DoesNotHaveSameHashCodeAsFailTest()
    {
        Assertion.DoesNotHaveSameHashCodeAs(Assertion.Subject);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that there are no failures if the ToString() returns the correct thing.
    /// </summary>
    [Fact]
    public void ToStringYieldsPassTest()
    {
        Assertion.ToStringYields(Assertion.Subject!.ToString());
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that there are failures if the object has a different ToString() result.
    /// </summary>
    [Fact]
    public void ToStringYieldsFailTest()
    {
        Assertion.ToStringYields(Assertion.Subject + "ft2gr");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }
}
