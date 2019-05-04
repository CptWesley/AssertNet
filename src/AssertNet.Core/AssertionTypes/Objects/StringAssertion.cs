using System;
using System.Diagnostics.CodeAnalysis;
using System.Globalization;
using System.Text.RegularExpressions;
using AssertNet.Core.Failures;

namespace AssertNet.Core.AssertionTypes.Objects
{
    /// <summary>
    /// Class representing assertions made about strings.
    /// </summary>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    [SuppressMessage("Globalization", "CA1307", Justification = "Build target netstandard2.0 does not support suggested function and invariants are already being used.")]
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
        /// Asserts if a string is equal to a given other string if cases are ignored.
        /// </summary>
        /// <param name="other">The other string to compare with.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsEqualToIgnoringCase(string other, string message = null)
        {
            if (!Target.ToUpperInvariant().Equals(other.ToUpperInvariant(), StringComparison.InvariantCultureIgnoreCase))
            {
                Fail(new FailureBuilder("IsEqualToIgnoringCase()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be equal to while ignoring cases", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string is not equal to a given other string if cases are ignored.
        /// </summary>
        /// <param name="other">The other string to compare with.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNotEqualToIgnoringCase(string other, string message = null)
        {
            if (Target.ToUpperInvariant().Equals(other.ToUpperInvariant(), StringComparison.InvariantCultureIgnoreCase))
            {
                Fail(new FailureBuilder("IsNotEqualToIgnoringCase()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be equal to while ignoring cases", other)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts if a string contains a certain substring.
        /// </summary>
        /// <param name="substring">Substring which needs to be contained.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion Contains(string substring, string message = null)
        {
            if (!Target.Contains(substring))
            {
                Fail(new FailureBuilder("Contains()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContain(string substring, string message = null)
        {
            if (Target.Contains(substring))
            {
                Fail(new FailureBuilder("DoesNotContain()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion ContainsIgnoringCase(string substring, string message = null)
        {
            if (!Target.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
            {
                Fail(new FailureBuilder("ContainsIgnoringCase()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContainIgnoringCase(string substring, string message = null)
        {
            if (Target.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
            {
                Fail(new FailureBuilder("DoesNotContainIgnoringCase()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion ContainsPattern(string pattern, string message = null)
        {
            if (!Regex.IsMatch(Target, pattern))
            {
                Fail(new FailureBuilder("ContainsPattern()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotContainPattern(string pattern, string message = null)
        {
            if (Regex.IsMatch(Target, pattern))
            {
                Fail(new FailureBuilder("DoesNotContainPattern()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion StartsWith(string substring, string message = null)
        {
            if (!Target.StartsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("StartsWith()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotStartWith(string substring, string message = null)
        {
            if (Target.StartsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotStartWith()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion StartsWithIgnoringCase(string substring, string message = null)
        {
            if (!Target.StartsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("StartsWithIgnoringCase()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotStartWithIgnoringCase(string substring, string message = null)
        {
            if (Target.StartsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotStartWithIgnoringCase()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion EndsWith(string substring, string message = null)
        {
            if (!Target.EndsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("EndsWith()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotEndWith(string substring, string message = null)
        {
            if (Target.EndsWith(substring, false, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotEndWith()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion EndsWithIgnoringCase(string substring, string message = null)
        {
            if (!Target.EndsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("EndsWithIgnoringCase()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion DoesNotEndWithIgnoringCase(string substring, string message = null)
        {
            if (Target.EndsWith(substring, true, CultureInfo.InvariantCulture))
            {
                Fail(new FailureBuilder("DoesNotEndWithIgnoringCase()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to end with ignoring case", substring)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is empty.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsEmpty(string message = null)
        {
            if (Target.Length > 0)
            {
                Fail(new FailureBuilder("IsEmpty()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is not empty.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNotEmpty(string message = null)
        {
            if (Target.Length <= 0)
            {
                Fail(new FailureBuilder("IsNotEmpty()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is null or empty.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNullOrEmpty(string message = null)
        {
            if (!string.IsNullOrEmpty(Target))
            {
                Fail(new FailureBuilder("IsNullOrEmpty()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be null or empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the string is not empty or null.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion IsNotNullOrEmpty(string message = null)
        {
            if (string.IsNullOrEmpty(Target))
            {
                Fail(new FailureBuilder("IsNotNullOrEmpty()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasSize(int size, string message = null)
        {
            if (Target.Length != size)
            {
                Fail(new FailureBuilder("HasSize()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasAtLeastSize(int size, string message = null)
        {
            if (Target.Length < size)
            {
                Fail(new FailureBuilder("HasAtLeastSize()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion HasAtMostSize(int size, string message = null)
        {
            if (Target.Length > size)
            {
                Fail(new FailureBuilder("HasAtMostSize()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To have at most a length of", size)
                    .Append("But has length of", Target.Length)
                    .Finish());
            }

            return this;
        }
    }
}
