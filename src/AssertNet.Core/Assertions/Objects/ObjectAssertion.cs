using System.Collections;
using System.Linq;
using AssertNet.Core.FailureHandlers;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Abstract class representing assertions of objects.
    /// </summary>
    /// <typeparam name="TAssert">Derived type of the assertion.</typeparam>
    /// <seealso cref="Assertion" />
    public abstract class ObjectAssertion<TAssert> : Assertion
        where TAssert : ObjectAssertion<TAssert>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAssertion{TAssert}"/> class.
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
        public TAssert IsEqualTo(object other)
        {
            if (!Target.Equals(other))
            {
                Fail($"'{Target}' is not equal to '{other}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether the object under test is not equal to another object.
        /// </summary>
        /// <param name="other">The other object to compare with.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotEqualTo(object other)
        {
            if (Target.Equals(other))
            {
                Fail($"Expected '{Target}' to not be equal to '{other}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether the object under test is the same as another object.
        /// </summary>
        /// <param name="other">The other to compare with.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsSameAs(object other)
        {
            if (!ReferenceEquals(Target, other))
            {
                Fail($"'{Target}' is not the same object as '{other}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether the object under test is not the same as another object.
        /// </summary>
        /// <param name="other">The other to compare with.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotSameAs(object other)
        {
            if (ReferenceEquals(Target, other))
            {
                Fail($"Expected '{Target}' to not be the same object as '{other}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether this instance is null.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public TAssert IsNull()
        {
            if (Target != null)
            {
                Fail($"Expected '{Target}' to be 'null'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether this instance is not null.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotNull()
        {
            if (Target == null)
            {
                Fail($"Expected '{Target}' not to be 'null'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is an instance of a certain type.
        /// </summary>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsInstanceOf<T>()
        {
            if (!(Target is T))
            {
                Fail($"Expected '{Target}' to be an instance of '{typeof(T)}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is not an instance of a certain type.
        /// </summary>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotInstanceOf<T>()
        {
            if (Target is T)
            {
                Fail($"Expected '{Target}' to not be an instance of '{typeof(T)}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is exactly an instance of a certain type.
        /// </summary>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsExactlyInstanceOf<T>()
        {
            if (Target.GetType() != typeof(T))
            {
                Fail($"Expected '{Target}' to be an instance of exactly '{typeof(T)}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is not exactly an instance of a certain type.
        /// </summary>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotExactlyInstanceOf<T>()
        {
            if (Target.GetType() == typeof(T))
            {
                Fail($"Expected '{Target}' to not be an instance of exactly '{typeof(T)}'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is in an enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable to check in.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsIn(IEnumerable enumerable)
        {
            if (!enumerable.Cast<object>().Contains(Target))
            {
                Fail($"Expected '{Target}' to be in '[{string.Join(", ", enumerable)}]'.");
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is not in an enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable to check in.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotIn(IEnumerable enumerable)
        {
            if (enumerable.Cast<object>().Contains(Target))
            {
                Fail($"Expected '{Target}' to not be in '[{string.Join(", ", enumerable)}]'.");
            }

            return (TAssert)this;
        }
    }
}
