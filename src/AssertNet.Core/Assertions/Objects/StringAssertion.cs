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
    }
}
