using AssertNet.AssertionTypes;

namespace AssertNet;

/// <summary>
/// Class representing assertions made on collection objects.
/// </summary>
/// <typeparam name="TElement">Element type of the enumerable.</typeparam>
/// <seealso cref="Assertion{TAssert, TTarget}" />
public static class EnumerableAssertions
{
    /// <summary>
    /// Checks if the enumerable is empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To be empty, but is null")
                .Finish());
        }
        else if (assertion.Subject.Any())
        {
            assertion.Fail(new FailureBuilder("IsEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To be empty, but contains", assertion.Subject)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable is not empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("IsNotEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be empty, but is null")
                .Finish());
            return assertion;
        }
        else if (!assertion.Subject.Any())
        {
            assertion.Fail(new FailureBuilder("IsNotEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be empty")
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable is null or empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNullOrEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable?>
    {
        if (assertion.Subject is { } && assertion.Subject.Any())
        {
            assertion.Fail(new FailureBuilder("IsNullOrEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To be null or empty, but contains", assertion.Subject)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable is not null or empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert IsNotNullOrEmpty<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable?>
    {
        if (assertion.Subject is null || !assertion.Subject.Any())
        {
            assertion.Fail(new FailureBuilder("IsNotNullOrEmpty()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("Not to be null or empty")
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable has a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert HasSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have a size of", size)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        int realSize = assertion.Subject.Count();
        if (realSize != size)
        {
            assertion.Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable has at least a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert HasAtLeastSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at least a size of", size)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        int realSize = assertion.Subject.Count();
        if (realSize < size)
        {
            assertion.Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at least a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable has at most a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert HasAtMostSize<TAssert>(this TAssert assertion, int size, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at most a size of", size)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        int realSize = assertion.Subject.Count();
        if (realSize > size)
        {
            assertion.Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have at most a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert Contains<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.Contains(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert Contains<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("Contains()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To contain", values)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        IEnumerable<TElement> difference = values.Except(assertion.Subject);

        if (difference.Any())
        {
            assertion.Fail(new FailureBuilder("Contains()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To contain", values)
                .AppendEnumerable("But misses", difference)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContain<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContain(values, message: null);

    /// <summary>
    /// Checks if the enumerable does not contain the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContain<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        IEnumerable<TElement> intersection = values.Intersect(assertion.Subject);

        if (intersection.Any())
        {
            assertion.Fail(new FailureBuilder("DoesNotContain()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("Not to contain", values)
                .AppendEnumerable("But contains", intersection)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains only the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsOnly<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.ContainsOnly(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains only the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsOnly<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("DoesNotContain()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("Not to contain", values)
                .Append("But is null")
                .Finish());
        }

        IEnumerable<TElement> difference = assertion.Subject.Except(values);

        if (difference.Any())
        {
            assertion.Fail(new FailureBuilder("ContainsOnly()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To only contain", values)
                .AppendEnumerable("But also contains", difference)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains other values than the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainOnly<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContainOnly(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains other values than the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainOnly<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        IEnumerable<TElement> difference = assertion.Subject.Except(values);

        if (!difference.Any())
        {
            assertion.Fail(new FailureBuilder("DoesNotContainOnly()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To contain other elements besides", values)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsExactly<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.ContainsExactly(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsExactly<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ContainsExactly()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To contain exactly", values)
                .Append("But is null")
                .Finish());
            return assertion;
        }
        else if (!assertion.Subject.SequenceEqual(values))
        {
            assertion.Fail(new FailureBuilder("ContainsExactly()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To contain exactly", values)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainExactly<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContainExactly(values, message: null);

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainExactly<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }
        else if (assertion.Subject.SequenceEqual(values))
        {
            assertion.Fail(new FailureBuilder("DoesNotContainExactly()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("Not to contain exactly", values)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains exactly the given values in any order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsExactlyInAnyOrder<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.ContainsExactlyInAnyOrder(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains exactly the given values in any order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsExactlyInAnyOrder<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ContainsExactlyInAnyOrder()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To contain exactly in any order", values)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        List<TElement> valuesList = values.ToList();
        List<TElement> targetList = assertion.Subject.ToList();

        FailureBuilder failureBuilder = new FailureBuilder("ContainsExactlyInAnyOrder()")
            .Append(message);

        for (int i = valuesList.Count - 1; i >= 0; --i)
        {
            int index = targetList.IndexOf(valuesList[i]);
            if (index >= 0)
            {
                valuesList.RemoveAt(i);
                targetList.RemoveAt(index);
            }
        }

        if (valuesList.Any() || targetList.Any())
        {
            failureBuilder.AppendEnumerable("Expecting", assertion.Subject);
            failureBuilder.AppendEnumerable("To contain exactly in any order", values);

            if (valuesList.Any())
            {
                failureBuilder.AppendEnumerable("But did not find", valuesList);
            }

            if (targetList.Any())
            {
                failureBuilder.AppendEnumerable("But found excess", targetList);
            }

            assertion.Fail(failureBuilder.Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given elements in any given order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainExactlyInAnyOrder<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContainExactlyInAnyOrder(values, message: null);

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given elements in any given order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainExactlyInAnyOrder<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        List<TElement> valuesList = values.ToList();
        List<TElement> targetList = assertion.Subject.ToList();

        for (int i = valuesList.Count - 1; i >= 0; --i)
        {
            int index = targetList.IndexOf(valuesList[i]);
            if (index >= 0)
            {
                valuesList.RemoveAt(i);
                targetList.RemoveAt(index);
            }
        }

        if (!valuesList.Any() && !targetList.Any())
        {
            assertion.Fail(new FailureBuilder("DoesNotContainExactlyInAnyOrder()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("Not to contain exactly in any order", values)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsSequence<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.ContainsSequence(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsSequence<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ContainsSequence()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To contain the sequence", values)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        foreach (TElement el in assertion.Subject)
        {
            if (!it.MoveNext())
            {
                return assertion;
            }

            if (!EqualityHelper.Equals(el, it.Current))
            {
                it.Reset();
            }
        }

        assertion.Fail(new FailureBuilder("ContainsSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To contain the sequence", values)
                .Finish());

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainSequence<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContainSequence(values, message: null);

    /// <summary>
    /// Checks if the enumerable does not contain a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainSequence<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        foreach (TElement el in assertion.Subject)
        {
            if (!it.MoveNext())
            {
                assertion.Fail(new FailureBuilder("DoesNotContainSequence()")
                    .Append(message)
                    .AppendEnumerable("Expecting", assertion.Subject)
                    .AppendEnumerable("Not to contain the sequence", values)
                    .Finish());
                return assertion;
            }

            if (!EqualityHelper.Equals(el, it.Current))
            {
                it.Reset();
            }
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsInterleavedSequence<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.ContainsInterleavedSequence(values, message: null);

    /// <summary>
    /// Checks if the enumerable contains a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsInterleavedSequence<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ContainsInterleavedSequence()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .AppendEnumerable("To contain the interleaved sequence", values)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();

        if (!it.MoveNext())
        {
            return assertion;
        }

        foreach (TElement el in assertion.Subject)
        {
            if (EqualityHelper.Equals(el, it.Current) && !it.MoveNext())
            {
                return assertion;
            }
        }

        assertion.Fail(new FailureBuilder("ContainsInterleavedSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("To contain the interleaved sequence", values)
                .Finish());

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainInterleavedSequence<TAssert, TElement>(this TAssert assertion, params IEnumerable<TElement> values)
        where TAssert : IAssertion<IEnumerable<TElement>>
        => assertion.DoesNotContainInterleavedSequence(values, message: null);

    /// <summary>
    /// Checks if the enumerable does not contain a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainInterleavedSequence<TAssert, TElement>(this TAssert assertion, IEnumerable<TElement> values, string? message = null)
        where TAssert : IAssertion<IEnumerable<TElement>>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        bool failed = !it.MoveNext();

        if (!failed)
        {
            foreach (TElement el in assertion.Subject)
            {
                if (EqualityHelper.Equals(el, it.Current) && !it.MoveNext())
                {
                    failed = true;
                    break;
                }
            }
        }

        if (failed)
        {
            assertion.Fail(new FailureBuilder("DoesNotContainInterleavedSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .AppendEnumerable("Not to contain the interleaved sequence", values)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable contains null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert ContainsNull<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("ContainsNull()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append<object>("To contain", null)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        var nulls = assertion.Subject.AsGeneric().Where(x => x is null);

        if (!nulls.Any())
        {
            assertion.Fail(new FailureBuilder("ContainsNull()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append<object>("To contain", null)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks if the enumerable does not contain null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static TAssert DoesNotContainNull<TAssert>(this TAssert assertion, string? message = null)
        where TAssert : IAssertion<IEnumerable>
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        var nulls = assertion.Subject.AsGeneric().Where(x => x is null);

        if (nulls.Any())
        {
            assertion.Fail(new FailureBuilder("DoesNotContainNull()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append<object>("Not to contain", null)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that a condition holds for all elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for all elements.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static IAssertion<IEnumerable<TElement>> AllSatisfy<TElement>(this IAssertion<IEnumerable<TElement>> assertion, Func<TElement, bool> condition, string? message = null)
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To all satisfy", condition)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        var failed = assertion.Subject.Where(x => !condition.Invoke(x));

        if (failed.Any())
        {
            assertion.Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append("To all satisfy", condition)
                .AppendEnumerable("But did not hold for", failed)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that a condition holds for some element in the enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for some element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static IAssertion<IEnumerable<TElement>> SomeSatisfy<TElement>(this IAssertion<IEnumerable<TElement>> assertion, Func<TElement, bool> condition, string? message = null)
    {
        if (assertion.Subject is null)
        {
            assertion.Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .Append("Expecting", assertion.Subject)
                .Append("To have any element satisfying", condition)
                .Append("But is null")
                .Finish());
            return assertion;
        }

        IEnumerable<TElement> holds = assertion.Subject.Where(condition);

        if (!holds.Any())
        {
            assertion.Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append("To have any element satisfying", condition)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Checks that a condition holds for none of the elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which may not hold for each element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public static IAssertion<IEnumerable<TElement>> NoneSatisfy<TElement>(this IAssertion<IEnumerable<TElement>> assertion, Func<TElement, bool> condition, string? message = null)
    {
        if (assertion.Subject is null)
        {
            return assertion;
        }

        IEnumerable<TElement> holds = assertion.Subject.Where(condition);

        if (holds.Any())
        {
            assertion.Fail(new FailureBuilder("NoneSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", assertion.Subject)
                .Append("Not to have elements satisfying", condition)
                .AppendEnumerable("But found", holds)
                .Finish());
        }

        return assertion;
    }

    /// <summary>
    /// Creates a new assertion for a filtered version of the target enumerable.
    /// </summary>
    /// <param name="condition">The condition to filter on.</param>
    /// <returns>A new assertion for a filtered version of the target enumerable.</returns>
    public static IAssertion<IEnumerable<TElement>> Where<TElement>(this IAssertion<IEnumerable<TElement>> assertion, Func<TElement, bool> condition)
        => new Assertion<IEnumerable<TElement>>(assertion.FailureHandler, assertion.Subject.Where(condition));

    /// <summary>
    /// Creates a new assertion for a projected version of the target enumerable.
    /// </summary>
    /// <typeparam name="TIn">The input type of the projection.</typeparam>
    /// <typeparam name="TOut">The output type of the projection.</typeparam>
    /// <param name="selector">The selector for the projection.</param>
    /// <returns>A new assertion for a projected version of the target enumerable.</returns>
    public static IAssertion<IEnumerable<TOut>> Select<TIn, TOut>(this IAssertion<IEnumerable<TIn>> assertion, Func<TIn, TOut> selector)
        => new Assertion<IEnumerable<TOut>>(assertion.FailureHandler, assertion.Subject.Select(selector));

    /// <summary>
    /// Creates a new assertion for a filtered version of the target enumerable.
    /// </summary>
    /// <returns>A new assertion for a filtered version of the target enumerable.</returns>
    public static IAssertion<IEnumerable<TElement>> OfType<TElement>(this IAssertion<IEnumerable> assertion)
        => new Assertion<IEnumerable<TElement>>(assertion.FailureHandler, assertion.Subject.OfType<TElement>());
}
