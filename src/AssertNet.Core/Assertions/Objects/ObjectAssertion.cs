using System.Collections;
using System.Linq;
using AssertNet.Core.Failures;

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
                Fail(new FailureBuilder("IsEqualTo()")
                    .Append("Expecting", Target)
                    .Append("To be equal to", other)
                    .Finish());
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
                Fail(new FailureBuilder("IsNotEqualTo()")
                    .Append("Expecting", Target)
                    .Append("Not to be equal to", other)
                    .Finish());
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
                Fail(new FailureBuilder("IsSameAs()")
                    .Append("Expecting", Target)
                    .Append("To be the same object as", other)
                    .Finish());
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
                Fail(new FailureBuilder("IsNotSameAs()")
                    .Append("Expecting", Target)
                    .Append("Not to be the same object as", other)
                    .Finish());
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
                Fail(new FailureBuilder("IsNull()")
                    .Append("Expecting", Target)
                    .Append<object>("To be", null)
                    .Finish());
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
                Fail(new FailureBuilder("IsNotNull()")
                    .Append("Expecting", Target)
                    .Append<object>("Not to be", null)
                    .Finish());
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
                Fail(new FailureBuilder("IsInstanceOf()")
                    .Append("Expecting", Target)
                    .Append("To be an instance of", typeof(T))
                    .Append("But is an instance of", Target.GetType())
                    .Finish());
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
                Fail(new FailureBuilder("IsNotInstanceOf()")
                    .Append("Expecting", Target)
                    .Append("Not to be an instance of", typeof(T))
                    .Finish());
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
                Fail(new FailureBuilder("IsExactlyInstanceOf()")
                    .Append("Expecting", Target)
                    .Append("To be an exact instance of", typeof(T))
                    .Append("But is an instance of", Target.GetType())
                    .Finish());
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
                Fail(new FailureBuilder("IsNotExactlyInstanceOf()")
                    .Append("Expecting", Target)
                    .Append("Not to be an exact instance of", typeof(T))
                    .Finish());
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
                Fail(new FailureBuilder("IsIn()")
                    .Append("Expecting", Target)
                    .Append("To be in", enumerable)
                    .Finish());
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
                Fail(new FailureBuilder("IsNotIn()")
                    .Append("Expecting", Target)
                    .Append("Not to be in", enumerable)
                    .Finish());
            }

            return (TAssert)this;
        }
    }
}
