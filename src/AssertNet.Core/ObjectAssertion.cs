namespace AssertNet.Core
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
        /// <param name="objs">The object which is under test.</param>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        public ObjectAssertion(IFailureHandler failureHandler, object objs)
            : base(failureHandler)
        {
            Target = objs;
        }

        /// <summary>
        /// Gets the object under test.
        /// </summary>
        /// <value>
        /// The object under test.
        /// </value>
        public object Target { get; }

        /// <summary>
        /// Determines whether the object under test is equal to another object.
        /// </summary>
        /// <param name="other">The other.</param>
        /// <returns>The original assertion.</returns>
        public T IsEqualTo(object other)
        {
            if (!Target.Equals(other))
            {
                Fail($"'{Target}' is not equal to '{other}'.");
            }

            return (T)this;
        }
    }
}
