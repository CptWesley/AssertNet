using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made on boolean items.
    /// </summary>
    /// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
    public class BooleanAssertion : ObjectAssertion<BooleanAssertion, bool>
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
        /// Asserts that the boolean value is true.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public BooleanAssertion IsTrue()
        {
            if (Target == false)
            {
                Fail(new FailureBuilder("IsTrue()")
                    .Append("Expecting", Target)
                    .Append("To be equal to", true)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Asserts that the boolean value is false.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public BooleanAssertion IsFalse()
        {
            if (Target == true)
            {
                Fail(new FailureBuilder("IsFalse()")
                    .Append("Expecting", Target)
                    .Append("To be equal to", false)
                    .Finish());
            }

            return this;
        }
    }
}
