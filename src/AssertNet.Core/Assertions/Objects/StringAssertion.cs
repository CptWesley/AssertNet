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
                Fail($"Expected '{Value}' to contain '{substring}'.");
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
                Fail($"Expected '{Value}' to not contain '{substring}'.");
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
                Fail($"Expected '{Value}' to contain '{substring}' while ignoring case.");
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
                Fail($"Expected '{Value}' to not contain '{substring}' while ignoring case.");
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
                Fail($"Expected '{Value}' to start with '{substring}'.");
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
                Fail($"Expected '{Value}' to not start with '{substring}'.");
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
                Fail($"Expected '{Value}' to start with '{substring}' while ignoring cases.");
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
                Fail($"Expected '{Value}' to not start with '{substring}' while ignoring cases.");
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
                Fail($"Expected '{Value}' to end with '{substring}'.");
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
                Fail($"Expected '{Value}' to not end with '{substring}'.");
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
                Fail($"Expected '{Value}' to end with '{substring}' while ignoring cases.");
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
                Fail($"Expected '{Value}' to not end with '{substring}' while ignoring cases.");
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
                Fail($"Expected '{Value}' to be empty.");
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
                Fail($"Expected string to contain at least 1 element.");
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
                Fail($"Expected '{Value}' to be null or empty.");
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
                Fail($"Expected string to contain at least 1 element, but was '{Value}'.");
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
                Fail($"Expected '{Value}' to have a length of '{size}', while it was '{Value.Length}'.");
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
                Fail($"Expected '{Value}' to have at least a length of '{size}', while it was '{Value.Length}'.");
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
                Fail($"Expected '{Value}' to have at most a length of '{size}', while it was '{Value.Length}'.");
            }

            return this;
        }
    }
}
