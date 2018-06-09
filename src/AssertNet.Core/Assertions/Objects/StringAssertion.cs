using AssertNet.Core.FailureHandlers;

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
    }
}
