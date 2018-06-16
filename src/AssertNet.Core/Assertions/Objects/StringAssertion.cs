using System.Globalization;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made about strings.
    /// </summary>
    /// <seealso cref="ObjectAssertion{StringAssertion}" />
    public class StringAssertion : ObjectAssertion<StringAssertion>
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
        /// Gets the string under test.
        /// </summary>
        /// <value>
        /// The string under test.
        /// </value>
        public string Value => (string)Target;

        /// <summary>
        /// Asserts if a string contains a certain substring.
        /// </summary>
        /// <param name="substring">Substring which needs to be contained.</param>
        /// <returns>The current assertion.</returns>
        public StringAssertion Contains(string substring)
        {
            if (!Value.Contains(substring))
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
            if (Value.Contains(substring))
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
            if (!Value.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
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
            if (Value.ToUpperInvariant().Contains(substring.ToUpperInvariant()))
            {
                Fail(new FailureBuilder("DoesNotContainIgnoringCase()")
                    .Append("Expecting", Target)
                    .Append("Not to contain ignoring case", substring)
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
            if (!Value.StartsWith(substring, false, CultureInfo.InvariantCulture))
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
            if (Value.StartsWith(substring, false, CultureInfo.InvariantCulture))
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
            if (!Value.StartsWith(substring, true, CultureInfo.InvariantCulture))
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
            if (Value.StartsWith(substring, true, CultureInfo.InvariantCulture))
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
            if (!Value.EndsWith(substring, false, CultureInfo.InvariantCulture))
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
            if (Value.EndsWith(substring, false, CultureInfo.InvariantCulture))
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
            if (!Value.EndsWith(substring, true, CultureInfo.InvariantCulture))
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
            if (Value.EndsWith(substring, true, CultureInfo.InvariantCulture))
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
            if (Value.Length > 0)
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
            if (Value.Length <= 0)
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
            if (!string.IsNullOrEmpty(Value))
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
            if (string.IsNullOrEmpty(Value))
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
            if (Value.Length != size)
            {
                Fail(new FailureBuilder("HasSize()")
                    .Append("Expecting", Target)
                    .Append("To have a length of", size)
                    .Append("But has a length of", Value.Length)
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
            if (Value.Length < size)
            {
                Fail(new FailureBuilder("HasAtLeastSize()")
                    .Append("Expecting", Target)
                    .Append("To have at least a length of", size)
                    .Append("But has length of", Value.Length)
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
            if (Value.Length > size)
            {
                Fail(new FailureBuilder("HasAtMostSize()")
                    .Append("Expecting", Target)
                    .Append("To have at most a length of", size)
                    .Append("But has length of", Value.Length)
                    .Finish());
            }

            return this;
        }
    }
}
