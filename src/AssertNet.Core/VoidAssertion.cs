using System;

namespace AssertNet.Core
{
    /// <summary>
    /// Class representing assertions made on actions.
    /// </summary>
    /// <seealso cref="Assertion" />
    public class VoidAssertion : Assertion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoidAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="action">The action under test.</param>
        public VoidAssertion(IFailureHandler failureHandler, Action action)
            : base(failureHandler)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action under test.
        /// </summary>
        /// <value>
        /// The action under test.
        /// </value>
        public Action Action { get; }
    }
}
