using AssertNet.Core.AssertionTypes;

namespace AssertNet;

/// <summary>
/// Abstract class representing assertions of objects.
/// </summary>
public static class ObjectAssertions
{
    /// <summary>
    /// Checks whether the object under test is equal to another object.
    /// </summary>
    /// <param name="other">The other object to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsEqualTo<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (!EqualityHelper.Equals(assertion.Subject, other))
        {
            assertion.Fail(new FailureBuilder("IsEqualTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equal to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the object under test is not equal to another object.
    /// </summary>
    /// <param name="other">The other object to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotEqualTo<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (EqualityHelper.Equals(assertion.Subject, other))
        {
            assertion.Fail(new FailureBuilder("IsNotEqualTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be equal to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the object under test is equivalent to another object.
    /// </summary>
    /// <param name="other">The other object to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsEquivalentTo<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (!EquivalencyHelper.AreEquivalent(assertion.Subject, other))
        {
            assertion.Fail(new FailureBuilder("IsEquivalentTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be equivalent to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the object under test is not equivalent to another object.
    /// </summary>
    /// <param name="other">The other object to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotEquivalentTo<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (EquivalencyHelper.AreEquivalent(assertion.Subject, other))
        {
            assertion.Fail(new FailureBuilder("IsNotEquivalentTo()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be equivalent to", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the object under test is the same as another object.
    /// </summary>
    /// <param name="other">The other to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsSameAs<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        var isValueType = assertion.Subject?.GetType().IsValueType ?? false;

        if ((isValueType && !EqualityHelper.Equals(assertion.Subject, other))
        || (!isValueType && !ReferenceEquals(assertion.Subject, other)))
        {
            assertion.Fail(new FailureBuilder("IsSameAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be the same object as", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether the object under test is not the same as another object.
    /// </summary>
    /// <param name="other">The other to compare with.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotSameAs<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        var isValueType = assertion.Subject?.GetType().IsValueType ?? false;

        if ((isValueType && EqualityHelper.Equals(assertion.Subject, other))
        || (!isValueType && ReferenceEquals(assertion.Subject, other)))
        {
            assertion.Fail(new FailureBuilder("IsNotSameAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be the same object as", other)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether this instance is null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNull<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is not null)
        {
            assertion.Fail(new FailureBuilder("IsNull()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append<object>("To be", null)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks whether this instance is not null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotNull<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsNotNull()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append<object>("Not to be", null)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is an instance of a certain type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type to check for.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion<T> IsInstanceOf<T>(this IAssertion assertion, string? message = null)
    {
        var t = typeof(T);

        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an instance of", t)
                .Append("But is null")
                .Finish());
            return new Assertion<T>(assertion.FailureHandler, default!);
        }
        else if (assertion.Subject is not T subject)
        {
            assertion.Fail(new FailureBuilder("IsInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an instance of", t)
                .Append("But is an instance of", assertion.Subject.GetType())
                .Finish());
            return new Assertion<T>(assertion.FailureHandler, default!);
        }
        else
        {
            return new Assertion<T>(assertion.FailureHandler, subject);
        }
    }

    /// <summary>
    /// Checks if the object under test is an instance of a certain type.
    /// </summary>
    /// <param name="t">Type to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsInstanceOf<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an instance of", t)
                .Append("But is null")
                .Finish());
        }
        else if (!assertion.Subject.GetType().IsSubclassOf(t) && assertion.Subject.GetType() != t)
        {
            assertion.Fail(new FailureBuilder("IsInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an instance of", t)
                .Append("But is an instance of", assertion.Subject.GetType())
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is not an instance of a certain type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type to check for.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion IsNotInstanceOf<T>(this IAssertion assertion, string? message = null)
        => assertion.IsNotInstanceOf(typeof(T), message);

    /// <summary>
    /// Checks if the object under test is not an instance of a certain type.
    /// </summary>
    /// <param name="t">Type to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotInstanceOf<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is { } && (assertion.Subject.GetType().IsSubclassOf(t) || assertion.Subject.GetType() == t))
        {
            assertion.Fail(new FailureBuilder("IsNotInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be an instance of", t)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is exactly an instance of a certain type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type to check for.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion<T> IsExactlyInstanceOf<T>(this IAssertion assertion, string? message = null)
    {
        var t = typeof(T);

        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsExactlyInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an exact instance of", t)
                .Append("But is null")
                .Finish());
            return new Assertion<T>(assertion.FailureHandler, default!);
        }
        else if (assertion.Subject.GetType() != t)
        {
            assertion.Fail(new FailureBuilder("IsExactlyInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an exact instance of", t)
                .Append("But is an instance of", assertion.Subject.GetType())
                .Finish());
            return new Assertion<T>(assertion.FailureHandler, default!);
        }
        else
        {
            return new Assertion<T>(assertion.FailureHandler, (T)assertion.Subject);
        }
    }

    /// <summary>
    /// Checks if the object under test is exactly an instance of a certain type.
    /// </summary>
    /// <param name="t">Type to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsExactlyInstanceOf<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsExactlyInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an exact instance of", t)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.GetType() != t)
        {
            assertion.Fail(new FailureBuilder("IsExactlyInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be an exact instance of", t)
                .Append("But is an instance of", assertion.Subject.GetType())
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is not exactly an instance of a certain type.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <typeparam name="T">Type to check for.</typeparam>
    /// <returns>The current assertion.</returns>
    public static IAssertion IsNotExactlyInstanceOf<T>(this IAssertion assertion, string? message = null)
        => assertion.IsNotExactlyInstanceOf(typeof(T), message);

    /// <summary>
    /// Checks if the object under test is not exactly an instance of a certain type.
    /// </summary>
    /// <param name="t">Type to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotExactlyInstanceOf<TAssert>(this TAssert assertion, Type t, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is { } && assertion.Subject.GetType() == t)
        {
            assertion.Fail(new FailureBuilder("IsNotExactlyInstanceOf()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be an exact instance of", t)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is in an enumerable.
    /// </summary>
    /// <param name="enumerable">The enumerable to check in.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsIn<TAssert>(this TAssert assertion, IEnumerable enumerable, string? message = null)
        where TAssert : IAssertion
    {
        if (!enumerable.AsGeneric().Contains(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsIn()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be in", enumerable)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the object under test is not in an enumerable.
    /// </summary>
    /// <param name="enumerable">The enumerable to check in.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotIn<TAssert>(this TAssert assertion, IEnumerable enumerable, string? message = null)
        where TAssert : IAssertion
    {
        if (enumerable.AsGeneric().Contains(assertion.Subject))
        {
            assertion.Fail(new FailureBuilder("IsNotIn()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be in", enumerable)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object satisfies a condition.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for the object.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static IAssertion<TSubject> Satisfies<TSubject>(this IAssertion<TSubject> assertion, Func<TSubject, bool> condition, string? message = null)
    {
        if (!condition.Invoke(assertion.Subject!))
        {
            assertion.Fail(new FailureBuilder("Satisfies()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To satisfy", condition)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object does not satisfy a condition.
    /// </summary>
    /// <param name="condition">The condition which may not hold for the object.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static IAssertion<TSubject> DoesNotSatisfy<TSubject>(this IAssertion<TSubject> assertion, Func<TSubject, bool> condition, string? message = null)
    {
        if (condition.Invoke(assertion.Subject!))
        {
            assertion.Fail(new FailureBuilder("DoesNotSatisfy()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to satisfy", condition)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object has a certain hash code.
    /// </summary>
    /// <param name="hashCode">The expected hash code of the object.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert HasHashCode<TAssert>(this TAssert assertion, int hashCode, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasHashCode()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have the hash code", hashCode)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.GetHashCode() != hashCode)
        {
            assertion.Fail(new FailureBuilder("HasHashCode()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have the hash code", hashCode)
                .Append("But has hash code", assertion.Subject.GetHashCode())
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object does not have a certain hash code.
    /// </summary>
    /// <param name="hashCode">The forbidden hash code of the object.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotHaveHashCode<TAssert>(this TAssert assertion, int hashCode, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is { } && assertion.Subject.GetHashCode() == hashCode)
        {
            assertion.Fail(new FailureBuilder("DoesNotHaveHashCode()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to have the hash code", hashCode)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object has the same hash code as another object.
    /// </summary>
    /// <param name="other">The other object which should have the same hash code.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert HasSameHashCodeAs<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            if (other is not null)
            {
                assertion.Fail(new FailureBuilder("HasSameHashCodeAs()")
                    .Append(message)
                    .Append("Expecting", assertion.Subject)
                    .Append("To have the hash code", other.GetHashCode())
                    .Append("But is null")
                    .Finish());
            }
        }
        else if (other is null)
        {
            assertion.Fail(new FailureBuilder("HasSameHashCodeAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be null")
                .Append("But has hash code", assertion.Subject.GetHashCode())
                .Finish());
        }
        else if (assertion.Subject.GetHashCode() != other.GetHashCode())
        {
            assertion.Fail(new FailureBuilder("HasSameHashCodeAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have the hash code", other.GetHashCode())
                .Append("But has hash code", assertion.Subject.GetHashCode())
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that an object has a different hash code than another object.
    /// </summary>
    /// <param name="other">The other object which may not have the same hash code.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotHaveSameHashCodeAs<TAssert>(this TAssert assertion, object? other, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null && other is null)
        {
            assertion.Fail(new FailureBuilder("DoesNotHaveSameHashCodeAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be null")
                .Finish());
        }
        else if (assertion.Subject is { } && other is { } && assertion.Subject.GetHashCode() == other.GetHashCode())
        {
            assertion.Fail(new FailureBuilder("DoesNotHaveSameHashCodeAs()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to have the hash code", other.GetHashCode())
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that the ToString() call returns the given string.
    /// </summary>
    /// <param name="str">The expected ToString() result.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ToStringYields<TAssert>(this TAssert assertion, string? str, string? message = null)
        where TAssert : IAssertion
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ToStringYields()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be represented as", str)
                .Append("But is null")
                .Finish());
        }
        else if (assertion.Subject.ToString() is { } other && !Equals(other, str))
        {
            assertion.Fail(new FailureBuilder("ToStringYields()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be represented as", str)
                .Append("But is represented as", other)
                .Finish());
        }

        return assertion;
    }
}
