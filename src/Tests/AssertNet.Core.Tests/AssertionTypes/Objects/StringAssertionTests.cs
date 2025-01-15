using AssertNet.Core.AssertionTypes.Objects;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Tests.AssertionTypes.Objects;

/// <summary>
/// Test class for the <see cref="StringAssertion"/> class.
/// </summary>
/// <seealso cref="ObjectAssertionTests{TAssert, TTarget}" />
public class StringAssertionTests : ObjectAssertionTests<StringAssertion, string>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="StringAssertionTests"/> class.
    /// </summary>
    public StringAssertionTests()
    {
        FailureHandler = new Mock<IFailureHandler>();
        Assertion = new StringAssertion(FailureHandler.Object, "threhterj");
    }

    private StringAssertion StringAssertion => (StringAssertion)Assertion;

    /// <summary>
    /// Checks that the assertion passes if the value is equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsEqualToIgnoringCasePassTest()
    {
        StringAssertion.IsEqualToIgnoringCase("Threhterj");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is not equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsEqualToIgnoringCaseFailTest()
    {
        StringAssertion.IsEqualToIgnoringCase("fdsdFSD");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value is not equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsNotEqualToIgnoringCasePassTest()
    {
        StringAssertion.IsNotEqualToIgnoringCase("rey");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value is equal to the given value while ignoring cases.
    /// </summary>
    [Fact]
    public void IsNotEqualToIgnoringCaseFailTest()
    {
        StringAssertion.IsNotEqualToIgnoringCase("ThrehteRj");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a substring.
    /// </summary>
    [Fact]
    public void ContainsPassTest()
    {
        StringAssertion.Contains("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a substring.
    /// </summary>
    [Fact]
    public void ContainsFailTest()
    {
        StringAssertion.Contains("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a substring.
    /// </summary>
    [Fact]
    public void DoesNotContainPassTest()
    {
        StringAssertion.DoesNotContain("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a substring.
    /// </summary>
    [Fact]
    public void DoesNotContainFailTest()
    {
        StringAssertion.DoesNotContain("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a pattern.
    /// </summary>
    [Fact]
    public void ContainsPatternPassTest()
    {
        StringAssertion.ContainsPattern("[a-zA-Z]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a pattern.
    /// </summary>
    [Fact]
    public void ContainsPatternFailTest()
    {
        StringAssertion.ContainsPattern("[0-9]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a pattern.
    /// </summary>
    [Fact]
    public void DoesNotContainPatternPassTest()
    {
        StringAssertion.DoesNotContainPattern("[0-9]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a pattern.
    /// </summary>
    [Fact]
    public void DoesNotContainPatternFailTest()
    {
        StringAssertion.DoesNotContainPattern("[a-zA-Z]+");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value contains a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void ContainsIgnoringCasePassTest()
    {
        StringAssertion.ContainsIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not contain a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void ContainsIgnoringCaseFailTest()
    {
        StringAssertion.ContainsIgnoringCase("5ft5fre453f34");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not contain a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotContainIgnoringCasePassTest()
    {
        StringAssertion.DoesNotContainIgnoringCase("f457h905f435nh9mfht5");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value contains a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotContainIgnoringCaseFailTest()
    {
        StringAssertion.DoesNotContainIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value starts with a substring.
    /// </summary>
    [Fact]
    public void StartsWithPassTest()
    {
        StringAssertion.StartsWith("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not start with a substring.
    /// </summary>
    [Fact]
    public void StartsWithFailTest()
    {
        StringAssertion.StartsWith("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not start with a substring.
    /// </summary>
    [Fact]
    public void DoesNotStartWithPassTest()
    {
        StringAssertion.DoesNotStartWith("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value starts with a substring.
    /// </summary>
    [Fact]
    public void DoesNotStartWithFailTest()
    {
        StringAssertion.DoesNotStartWith("t");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value starts with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void StartsWithIgnoringCasePassTest()
    {
        StringAssertion.StartsWithIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not start with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void StartsWithIgnoringCaseFailTest()
    {
        StringAssertion.StartsWithIgnoringCase("5ft5fre453f34");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not start with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotStartWithIgnoringCasePassTest()
    {
        StringAssertion.DoesNotStartWithIgnoringCase("f457h905f435nh9mfht5");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value starts with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotStartWithIgnoringCaseFailTest()
    {
        StringAssertion.DoesNotStartWithIgnoringCase("T");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value ends with a substring.
    /// </summary>
    [Fact]
    public void EndsWithPassTest()
    {
        StringAssertion.EndsWith("j");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not end with a substring.
    /// </summary>
    [Fact]
    public void EndsWithFailTest()
    {
        StringAssertion.EndsWith("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not end with a substring.
    /// </summary>
    [Fact]
    public void DoesNotEndWithPassTest()
    {
        StringAssertion.DoesNotEndWith("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value ends with a substring.
    /// </summary>
    [Fact]
    public void DoesNotEndWithFailTest()
    {
        StringAssertion.DoesNotEndWith("j");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value ends with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void EndsWithIgnoringCasePassTest()
    {
        StringAssertion.EndsWithIgnoringCase("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value does not end with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void EndsWithIgnoringCaseFailTest()
    {
        StringAssertion.EndsWithIgnoringCase("6435f");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the value does not end with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotEndWithIgnoringCasePassTest()
    {
        StringAssertion.DoesNotEndWithIgnoringCase("4356f4356r");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the value ends with a substring while ignoring cases.
    /// </summary>
    [Fact]
    public void DoesNotEndWithIgnoringCaseFailTest()
    {
        StringAssertion.DoesNotEndWithIgnoringCase("J");
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is empty.
    /// </summary>
    [Fact]
    public void IsEmptyPassTest()
    {
        new StringAssertion(FailureHandler.Object, string.Empty).IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is not empty.
    /// </summary>
    [Fact]
    public void IsEmptyFailTest()
    {
        StringAssertion.IsEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyPassTest()
    {
        StringAssertion.IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is empty.
    /// </summary>
    [Fact]
    public void IsNotEmptyFailTest()
    {
        new StringAssertion(FailureHandler.Object, string.Empty).IsNotEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is empty.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyEmptyPassTest()
    {
        new StringAssertion(FailureHandler.Object, string.Empty).IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is null.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyNullPassTest()
    {
        new StringAssertion(FailureHandler.Object, null).IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNullOrEmptyFailTest()
    {
        StringAssertion.IsNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion passes if the string is not empty.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyPassTest()
    {
        StringAssertion.IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is empty.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyEmptyFailTest()
    {
        new StringAssertion(FailureHandler.Object, string.Empty).IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion fails if the string is null.
    /// </summary>
    [Fact]
    public void IsNullOrNotEmptyNullFailTest()
    {
        new StringAssertion(FailureHandler.Object, null).IsNotNullOrEmpty();
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Once());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has the correct size.
    /// </summary>
    [Fact]
    public void HasSizePassTest()
    {
        new StringAssertion(FailureHandler.Object, "abc").HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string has the incorrect size.
    /// </summary>
    [Fact]
    public void HasSizeFailTest()
    {
        new StringAssertion(FailureHandler.Object, "ab").HasSize(3);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizePassTest()
    {
        new StringAssertion(FailureHandler.Object, "abcd").HasAtLeastSize(2);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string does not have the minimum size.
    /// </summary>
    [Fact]
    public void HasAtLeastSizeFailTest()
    {
        new StringAssertion(FailureHandler.Object, "c").HasAtLeastSize(10);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }

    /// <summary>
    /// Checks that the assertion does not fail if the string has less than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizePassTest()
    {
        new StringAssertion(FailureHandler.Object, "4534").HasAtMostSize(4);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.Never());
    }

    /// <summary>
    /// Checks that the assertion fails if the string has more than the maximum size.
    /// </summary>
    [Fact]
    public void HasAtMostSizeFailTest()
    {
        new StringAssertion(FailureHandler.Object, "ab").HasAtMostSize(1);
        FailureHandler.Verify(x => x.Fail(It.IsAny<string>()), Times.AtLeastOnce());
    }
}
