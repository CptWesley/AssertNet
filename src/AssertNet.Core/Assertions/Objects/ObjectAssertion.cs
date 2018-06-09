using AssertNet.Core.FailureHandlers;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Abstract class representing assertions of objects.
    /// </summary>
    /// <typeparam name="T">Derived type of the assertion.</typeparam>
    /// <seealso cref="Assertion" />
    public abstract class ObjectAssertion<T> : Assertion
        where T : ObjectAssertion<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAssertion{T}"/> class.
        /// </summary>
        /// <param name="target">The object which is under test.</param>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        public ObjectAssertion(IFailureHandler failureHandler, object target)
            : base(failureHandler)
        {
            Target = target;
        }

        /// <summary>
        /// Gets the object under test.
        /// </summary>
        /// <value>
        /// The object under test.
        /// </value>
        public object Target { get; }

        /// <summary>
        /// Checks whether the object under test is equal to another object.
        /// </summary>
        /// <param name="other">The other object to compare with.</param>
        /// <returns>The current assertion.</returns>
        public T IsEqualTo(object other)
        {
            if (!Target.Equals(other))
            {
                Fail($"'{Target}' is not equal to '{other}'.");
            }

            return (T)this;
        }

        /// <summary>
        /// Checks whether the object under test is the same as another object.
        /// </summary>
        /// <param name="other">The other to compare with.</param>
        /// <returns>The current assertion.</returns>
        public T IsSameAs(object other)
        {
            if (!ReferenceEquals(Target, other))
            {
                Fail($"'{Target}' is not the same object as '{other}'.");
            }

            return (T)this;
        }
    }
}
