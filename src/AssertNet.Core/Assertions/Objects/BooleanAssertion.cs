using System.Diagnostics.CodeAnalysis;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made on boolean items.
    /// </summary>
    /// <seealso cref="ObjectAssertion{BooleanAssertion}" />
    public class BooleanAssertion : ObjectAssertion<BooleanAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BooleanAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public BooleanAssertion(IFailureHandler failureHandler, bool target)
            : base(failureHandler, target)
        {
        }

        /// <summary>
        /// Gets the boolean value under test.
        /// </summary>
        /// <value>
        /// The boolean value under test.
        /// </value>
        [SuppressMessage("StyleCop.CSharp.DocumentationRules", "SA1623:Property summary documentation must match accessors", Justification = "Does not indicate the state of the object.")]
        public bool Value => (bool)Target;

        /// <summary>
        /// Asserts that the boolean value is true.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public BooleanAssertion IsTrue()
        {
            if (Value == false)
            {
                Fail($"Expected 'true', but was 'false'.");
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value is false.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public BooleanAssertion IsFalse()
        {
            if (Value == true)
            {
                Fail($"Expected 'false', but was 'true'.");
            }

            return this;
        }
    }
}
