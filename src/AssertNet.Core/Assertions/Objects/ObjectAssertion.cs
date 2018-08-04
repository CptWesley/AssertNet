using System;
using System.Collections;
using System.Linq;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Abstract class representing assertions of objects.
    /// </summary>
    /// <typeparam name="TAssert">Derived type of the assertion.</typeparam>
    /// <typeparam name="TTarget">Type of the object under test.</typeparam>
    /// <seealso cref="Assertion" />
    public abstract class ObjectAssertion<TAssert, TTarget> : Assertion
        where TAssert : ObjectAssertion<TAssert, TTarget>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ObjectAssertion{TAssert, TTarget}"/> class.
        /// </summary>
        /// <param name="target">The object which is under test.</param>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        public ObjectAssertion(IFailureHandler failureHandler, TTarget target)
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
        public TTarget Target { get; }

        /// <summary>
        /// Checks whether the object under test is equal to another object.
        /// </summary>
        /// <param name="other">The other object to compare with.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsEqualTo(object other, string message = null)
        {
            if (!Target.Equals(other))
            {
                Fail(new FailureBuilder("IsEqualTo()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotEqualTo(object other, string message = null)
        {
            if (Target.Equals(other))
            {
                Fail(new FailureBuilder("IsNotEqualTo()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsSameAs(object other, string message = null)
        {
            if ((Target.GetType().IsValueType && !Target.Equals(other)) || (!Target.GetType().IsValueType && !ReferenceEquals(Target, other)))
            {
                Fail(new FailureBuilder("IsSameAs()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotSameAs(object other, string message = null)
        {
            if ((Target.GetType().IsValueType && Target.Equals(other)) || (!Target.GetType().IsValueType && ReferenceEquals(Target, other)))
            {
                Fail(new FailureBuilder("IsNotSameAs()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be the same object as", other)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether this instance is null.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNull(string message = null)
        {
            if (Target != null)
            {
                Fail(new FailureBuilder("IsNull()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append<object>("To be", null)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks whether this instance is not null.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotNull(string message = null)
        {
            if (Target == null)
            {
                Fail(new FailureBuilder("IsNotNull()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append<object>("Not to be", null)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is an instance of a certain type.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsInstanceOf<T>(string message = null) => IsInstanceOf(typeof(T), message);

        /// <summary>
        /// Checks if the object under test is an instance of a certain type.
        /// </summary>
        /// <param name="t">Type to check for.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsInstanceOf(Type t, string message = null)
        {
            if (!Target.GetType().IsSubclassOf(t) && Target.GetType() != t)
            {
                Fail(new FailureBuilder("IsInstanceOf()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be an instance of", t)
                    .Append("But is an instance of", Target.GetType())
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is not an instance of a certain type.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotInstanceOf<T>(string message = null) => IsNotInstanceOf(typeof(T), message);

        /// <summary>
        /// Checks if the object under test is not an instance of a certain type.
        /// </summary>
        /// <param name="t">Type to check for.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotInstanceOf(Type t, string message = null)
        {
            if (Target.GetType().IsSubclassOf(t) || Target.GetType() == t)
            {
                Fail(new FailureBuilder("IsNotInstanceOf()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be an instance of", t)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is exactly an instance of a certain type.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsExactlyInstanceOf<T>(string message = null) => IsExactlyInstanceOf(typeof(T), message);

        /// <summary>
        /// Checks if the object under test is exactly an instance of a certain type.
        /// </summary>
        /// <param name="t">Type to check for.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsExactlyInstanceOf(Type t, string message = null)
        {
            if (Target.GetType() != t)
            {
                Fail(new FailureBuilder("IsExactlyInstanceOf()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be an exact instance of", t)
                    .Append("But is an instance of", Target.GetType())
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is not exactly an instance of a certain type.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Type to check for.</typeparam>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotExactlyInstanceOf<T>(string message = null) => IsNotExactlyInstanceOf(typeof(T), message);

        /// <summary>
        /// Checks if the object under test is not exactly an instance of a certain type.
        /// </summary>
        /// <param name="t">Type to check for.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotExactlyInstanceOf(Type t, string message = null)
        {
            if (Target.GetType() == t)
            {
                Fail(new FailureBuilder("IsNotExactlyInstanceOf()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be an exact instance of", t)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks if the object under test is in an enumerable.
        /// </summary>
        /// <param name="enumerable">The enumerable to check in.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsIn(IEnumerable enumerable, string message = null)
        {
            if (!enumerable.Cast<object>().Contains(Target))
            {
                Fail(new FailureBuilder("IsIn()")
                    .Append(message)
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
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert IsNotIn(IEnumerable enumerable, string message = null)
        {
            if (enumerable.Cast<object>().Contains(Target))
            {
                Fail(new FailureBuilder("IsNotIn()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to be in", enumerable)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object satisfies a condition.
        /// </summary>
        /// <param name="condition">The condition which needs to hold for the object.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert Satisfies(Func<TTarget, bool> condition, string message = null)
        {
            if (!condition.Invoke(Target))
            {
                Fail(new FailureBuilder("Satisfies()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To satisfy", condition)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object does not satisfy a condition.
        /// </summary>
        /// <param name="condition">The condition which may not hold for the object.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert DoesNotSatisfy(Func<TTarget, bool> condition, string message = null)
        {
            if (condition.Invoke(Target))
            {
                Fail(new FailureBuilder("DoesNotSatisfy()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to satisfy", condition)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object has a certain hash code.
        /// </summary>
        /// <param name="hashCode">The expected hash code of the object.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert HasHashCode(int hashCode, string message = null)
        {
            if (Target.GetHashCode() != hashCode)
            {
                Fail(new FailureBuilder("HasHashCode()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To have the hash code", hashCode)
                    .Append("But has hash code", Target.GetHashCode())
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object does not have a certain hash code.
        /// </summary>
        /// <param name="hashCode">The forbidden hash code of the object.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert DoesNotHaveHashCode(int hashCode, string message = null)
        {
            if (Target.GetHashCode() == hashCode)
            {
                Fail(new FailureBuilder("DoesNotHaveHashCode()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to have the hash code", hashCode)
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object has the same hash code as another object.
        /// </summary>
        /// <param name="other">The other object which should have the same hash code.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert HasSameHashCodeAs(object other, string message = null)
        {
            if (Target.GetHashCode() != other.GetHashCode())
            {
                Fail(new FailureBuilder("HasSameHashCodeAs()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To have the hash code", other.GetHashCode())
                    .Append("But has hash code", Target.GetHashCode())
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that an object has a different hash code than another object.
        /// </summary>
        /// <param name="other">The other object which may not have the same hash code.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert DoesNotHaveSameHashCodeAs(object other, string message = null)
        {
            if (Target.GetHashCode() == other.GetHashCode())
            {
                Fail(new FailureBuilder("DoesNotHaveSameHashCodeAs()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("Not to have the hash code", other.GetHashCode())
                    .Finish());
            }

            return (TAssert)this;
        }

        /// <summary>
        /// Checks that the ToString() call returns the given string.
        /// </summary>
        /// <param name="str">The expected ToString() result.</param>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public TAssert ToStringYields(string str, string message = null)
        {
            if (Target.ToString() != str)
            {
                Fail(new FailureBuilder("ToStringYields()")
                    .Append(message)
                    .Append("Expecting", Target)
                    .Append("To be represented as", str)
                    .Finish());
            }

            return (TAssert)this;
        }
    }
}
