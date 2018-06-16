using System.Globalization;
using System.Text.RegularExpressions;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made about strings.
    /// </summary>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    public class StringAssertion : ObjectAssertion<StringAssertion, string>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="StringAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler.</param>
        /// <param name="target">The target.</param>
        public StringAssertion(IFailureHandler failureHandler, string target)
            : base(failureHandler, target)
        {
        }

        /// <summary>
        /// Asserts if a string contains a certain substring.
        /// </summary>
        /// <param name="substring">Substring which needs to be contained.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion Contains(string substring)
        {
            if (!Target.Contains(substring))
            {
                Fail(new FailureBuilder("Contains()")
                    .Append("Expecting", Target)
                    .Append("To contain", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not contain a certain substring.
        /// </summary>
        /// <param name="substring">Substring may not be contained.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContain(string substring)
        {
            if (Target.Contains(substring))
            {
                Fail(new FailureBuilder("DoesNotContain()")
                    .Append("Expecting", Target)
                    .Append("Not to contain", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string contains a certain substring.
        /// </summary>
        /// <param name="substring">Substring which needs to be contained.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion ContainsIgnoringCase(string substring)
        {
            if (!Target.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
            {
                Fail(new FailureBuilder("ContainsIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("To contain ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not contain a certain substring.
        /// </summary>
        /// <param name="substring">Substring may not be contained.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContainIgnoringCase(string substring)
        {
            if (Target.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
            {
                Fail(new FailureBuilder("DoesNotContainIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("Not to contain ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Determines whether the string under test contains a given pattern.
        /// </summary>
        /// <param name="pattern">The pattern to check for.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion ContainsPattern(string pattern)
        {
            if (!Regex.IsMatch(Target, pattern))
            {
                Fail(new FailureBuilder("ContainsPattern()")
                    .Append("Expecting", Target)
                    .Append("To contain the pattern", pattern)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Determines whether the string under test does not contain a given pattern.
        /// </summary>
        /// <param name="pattern">The pattern to check for.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContainPattern(string pattern)
        {
            if (Regex.IsMatch(Target, pattern))
            {
                Fail(new FailureBuilder("DoesNotContainPattern()")
                    .Append("Expecting", Target)
                    .Append("Not to contain the pattern", pattern)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string starts with a certain substring.
        /// </summary>
        /// <param name="substring">Substring which the string must start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion StartsWith(string substring)
        {
            if (!Target.StartsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("StartsWith()")
                    .Append("Expecting", Target)
                    .Append("To start with", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not start with a certain substring.
        /// </summary>
        /// <param name="substring">Substring which the string may not start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotStartWith(string substring)
        {
            if (Target.StartsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotStartWith()")
                    .Append("Expecting", Target)
                    .Append("Not to start with", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string starts with a certain substring while ignoring case.
        /// </summary>
        /// <param name="substring">Substring which the string must start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion StartsWithIgnoringCase(string substring)
        {
            if (!Target.StartsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("StartsWithIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("To start with ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not start with a certain substring while ignoring case.
        /// </summary>
        /// <param name="substring">Substring which the string may not start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotStartWithIgnoringCase(string substring)
        {
            if (Target.StartsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotStartWithIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("Not to start with ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string ends with a certain substring.
        /// </summary>
        /// <param name="substring">Substring which the string must start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion EndsWith(string substring)
        {
            if (!Target.EndsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("EndsWith()")
                    .Append("Expecting", Target)
                    .Append("To end with", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not end with a certain substring.
        /// </summary>
        /// <param name="substring">Substring which the string may not start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotEndWith(string substring)
        {
            if (Target.EndsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotEndWith()")
                    .Append("Expecting", Target)
                    .Append("Not to end with", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string ends with a certain substring while ignoring case.
        /// </summary>
        /// <param name="substring">Substring which the string must start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion EndsWithIgnoringCase(string substring)
        {
            if (!Target.EndsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("EndsWithIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("To end with ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string does not end with a certain substring while ignoring case.
        /// </summary>
        /// <param name="substring">Substring which the string may not start with.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotEndWithIgnoringCase(string substring)
        {
            if (Target.EndsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotEndWithIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("Not to end with ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsEmpty()
        {
            if (Target.Length > 0)
            {
                Fail(new FailureBuilder("IsEmpty()")
                    .Append("Expecting", Target)
                    .Append("To be empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is not empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNotEmpty()
        {
            if (Target.Length <= 0)
            {
                Fail(new FailureBuilder("IsNotEmpty()")
                    .Append("Expecting", Target)
                    .Append("Not to be empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is null or empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNullOrEmpty()
        {
            if (!string.IsNullOrEmpty(Target))
            {
                Fail(new FailureBuilder("IsNullOrEmpty()")
                    .Append("Expecting", Target)
                    .Append("To be null or empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is not empty or null.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNotNullOrEmpty()
        {
            if (string.IsNullOrEmpty(Target))
            {
                Fail(new FailureBuilder("IsNotNullOrEmpty()")
                    .Append("Expecting", Target)
                    .Append("Not to be null or empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string has a certain size.
        /// </summary>
        /// <param name="size">The size the string should have.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasSize(int size)
        {
            if (Target.Length != size)
            {
                Fail(new FailureBuilder("HasSize()")
                    .Append("Expecting", Target)
                    .Append("To have a length of", size)
                    .Append("But has a length of", Target.Length)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string has at least a certain size.
        /// </summary>
        /// <param name="size">The size the string should have.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasAtLeastSize(int size)
        {
            if (Target.Length < size)
            {
                Fail(new FailureBuilder("HasAtLeastSize()")
                    .Append("Expecting", Target)
                    .Append("To have at least a length of", size)
                    .Append("But has length of", Target.Length)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string has at most a certain size.
        /// </summary>
        /// <param name="size">The size the string should have.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasAtMostSize(int size)
        {
            if (Target.Length > size)
            {
                Fail(new FailureBuilder("HasAtMostSize()")
                    .Append("Expecting", Target)
                    .Append("To have at most a length of", size)
                    .Append("But has length of", Target.Length)
                    .Finish());
            }

            return this;
        }
    }
}
