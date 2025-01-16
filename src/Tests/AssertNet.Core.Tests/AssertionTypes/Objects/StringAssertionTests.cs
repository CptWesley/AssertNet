using AssertNet.Core.AssertionTypes;
using AssertNet.Core.AssertionTypes.Extensions;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="IAssertion"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{TAssert, TTarget}" />
public class AssertionTests : ObjectAssertionTests<Assertion<string>, string?>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="AssertionTests"/> class.
    /// </summary>
    public AssertionTests()
        : base("threhterj")
    {
    }

    /// <summary>
    /// Checks that the assertion passes if the value is equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsEqualToIgnoringCasePassTest()
    {
        Assertion.IsEqualToIgnoringCase("Threhterj");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsEqualToIgnoringCaseFailTest()
    {
        Assertion.IsEqualToIgnoringCase("fdsdFSD");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsNotEqualToIgnoringCasePassTest()
    {
        Assertion.IsNotEqualToIgnoringCase("rey");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsNotEqualToIgnoringCaseFailTest()
    {
        Assertion.IsNotEqualToIgnoringCase("ThrehteRj");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a substring.
    /// </summary>
    [Fact]
    public void ContainsPassTest()
    {
        Assertion.Contains("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a substring.
    /// </summary>
    [Fact]
    public void ContainsFailTest()
    {
        Assertion.Contains("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a substring.
    /// </summary>
    [Fact]
    public void DoesNotContainPassTest()
    {
        Assertion.DoesNotContain("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a substring.
    /// </summary>
    [Fact]
    public void DoesNotContainFailTest()
    {
        Assertion.DoesNotContain("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a pattern.
    /// </summary>
    [Fact]
    public void ContainsPatternPassTest()
    {
        Assertion.ContainsPattern("[a-zA-Z]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a pattern.
    /// </summary>
    [Fact]
    public void ContainsPatternFailTest()
    {
        Assertion.ContainsPattern("[0-9]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a pattern.
    /// </summary>
    [Fact]
    public void DoesNotContainPatternPassTest()
    {
        Assertion.DoesNotContainPattern("[0-9]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a pattern.
    /// </summary>
    [Fact]
    public void DoesNotContainPatternFailTest()
    {
        Assertion.DoesNotContainPattern("[a-zA-Z]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void ContainsIgnoringCasePassTest()
    {
        Assertion.ContainsIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void ContainsIgnoringCaseFailTest()
    {
        Assertion.ContainsIgnoringCase("5ft5fre453f34");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotContainIgnoringCasePassTest()
    {
        Assertion.DoesNotContainIgnoringCase("f457h905f435nh9mfht5");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotContainIgnoringCaseFailTest()
    {
        Assertion.DoesNotContainIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value starts with a substring.
    /// </summary>
    [Fact]
    public void StartsWithPassTest()
    {
        Assertion.StartsWith("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not start with a substring.
    /// </summary>
    [Fact]
    public void StartsWithFailTest()
    {
        Assertion.StartsWith("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not start with a substring.
    /// </summary>
    [Fact]
    public void DoesNotStartWithPassTest()
    {
        Assertion.DoesNotStartWith("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value starts with a substring.
    /// </summary>
    [Fact]
    public void DoesNotStartWithFailTest()
    {
        Assertion.DoesNotStartWith("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value starts with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void StartsWithIgnoringCasePassTest()
    {
        Assertion.StartsWithIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not start with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void StartsWithIgnoringCaseFailTest()
    {
        Assertion.StartsWithIgnoringCase("5ft5fre453f34");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not start with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotStartWithIgnoringCasePassTest()
    {
        Assertion.DoesNotStartWithIgnoringCase("f457h905f435nh9mfht5");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value starts with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotStartWithIgnoringCaseFailTest()
    {
        Assertion.DoesNotStartWithIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value ends with a substring.
    /// </summary>
    [Fact]
    public void EndsWithPassTest()
    {
        Assertion.EndsWith("j");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not end with a substring.
    /// </summary>
    [Fact]
    public void EndsWithFailTest()
    {
        Assertion.EndsWith("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not end with a substring.
    /// </summary>
    [Fact]
    public void DoesNotEndWithPassTest()
    {
        Assertion.DoesNotEndWith("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value ends with a substring.
    /// </summary>
    [Fact]
    public void DoesNotEndWithFailTest()
    {
        Assertion.DoesNotEndWith("j");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value ends with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void EndsWithIgnoringCasePassTest()
    {
        Assertion.EndsWithIgnoringCase("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not end with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void EndsWithIgnoringCaseFailTest()
    {
        Assertion.EndsWithIgnoringCase("6435f");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not end with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotEndWithIgnoringCasePassTest()
    {
        Assertion.DoesNotEndWithIgnoringCase("4356f4356r");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value ends with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotEndWithIgnoringCaseFailTest()
    {
        Assertion.DoesNotEndWithIgnoringCase("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is empty.
    /// </summary>
    [Fact]
    public void IsEmptyPassTest()
    {
        CreateAssertion(string.Empty).IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is not empty.
    /// </summary>
    [Fact]
    public void IsEmptyFailTest()
    {
        Assertion.IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyPassTest()
    {
        Assertion.IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyFailTest()
    {
        CreateAssertion(string.Empty).IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is empty.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyEmptyPassTest()
    {
        CreateAssertion(string.Empty).IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is null.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyNullPassTest()
    {
        CreateAssertion(null).IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyFailTest()
    {
        Assertion.IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyPassTest()
    {
        Assertion.IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is empty.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyEmptyFailTest()
    {
        CreateAssertion(string.Empty).IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is null.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyNullFailTest()
    {
        CreateAssertion(null).IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has the correct size.
    /// </summary>
    [Fact]
    public void HasSizePassTest()
    {
        CreateAssertion("abc").HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string has the incorrect size.
    /// </summary>
    [Fact]
    public void HasSizeFailTest()
    {
        CreateAssertion("ab").HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizePassTest()
    {
        CreateAssertion("abcd").HasAtLeastSize(2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string does not have the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizeFailTest()
    {
        CreateAssertion("c").HasAtLeastSize(10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has less than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizePassTest()
    {
        CreateAssertion("4534").HasAtMostSize(4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string has more than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizeFailTest()
    {
        CreateAssertion("ab").HasAtMostSize(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }
}
