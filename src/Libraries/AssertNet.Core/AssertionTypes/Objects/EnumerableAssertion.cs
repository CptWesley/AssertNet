using DotNetProjectFile.Resx;

namespace AssertNet.Core.AssertionTypes.Objects;

/// <summary>
/// Class representing assertions made on collection objects.
/// </summary>
/// <typeparam name="TElement">Element type of the enumerable.</typeparam>
/// <seealso cref="ObjectAssertion{TAssert, TTarget}" />
public class EnumerableAssertion<TElement> : ObjectAssertion<EnumerableAssertion<TElement>, IEnumerable<TElement>>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="EnumerableAssertion{TElement}"/> class.
    /// </summary>
    /// <param name="failureHandler">The failure handler of the assertion.</param>
    /// <param name="target">The object which is under test.</param>
    public EnumerableAssertion(IFailureHandler failureHandler, IEnumerable<TElement> target)
        : base(failureHandler, target)
    {
    }

    /// <summary>
    /// Checks if the enumerable is empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> IsEmpty(string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("IsEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To be empty, but is null")
                .Finish());
        }
        else if (Subject.Any())
        {
            Fail(new FailureBuilder("IsEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To be empty, but contains", Subject)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable is not empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> IsNotEmpty(string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("IsNotEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("Not to be empty, but is null")
                .Finish());
        }
        else if (!Subject.Any())
        {
            Fail(new FailureBuilder("IsNotEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("Not to be empty")
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable is null or empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> IsNullOrEmpty(string? message = null)
    {
        if (Subject is { } && Subject.Any())
        {
            Fail(new FailureBuilder("IsNullOrEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To be null or empty, but contains", Subject)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable is not null or empty.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> IsNotNullOrEmpty(string? message = null)
    {
        if (Subject is null || !Subject.Any())
        {
            Fail(new FailureBuilder("IsNotNullOrEmpty()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("Not to be null or empty")
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable has a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> HasSize(int size, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have a size of", size)
                .Append("But is null")
                .Finish());
            return this;
        }

        int realSize = Subject.Count();
        if (realSize != size)
        {
            Fail(new FailureBuilder("HasSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable has at least a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> HasAtLeastSize(int size, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have at least a size of", size)
                .Append("But is null")
                .Finish());
            return this;
        }

        int realSize = Subject.Count();
        if (realSize < size)
        {
            Fail(new FailureBuilder("HasAtLeastSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have at least a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable has at most a certain size.
    /// </summary>
    /// <param name="size">The size the enumerable should have.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> HasAtMostSize(int size, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have at most a size of", size)
                .Append("But is null")
                .Finish());
            return this;
        }

        int realSize = Subject.Count();
        if (realSize > size)
        {
            Fail(new FailureBuilder("HasAtMostSize()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have at most a size of", size)
                .Append("But has a size of", realSize)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> Contains(params TElement[] values) => Contains((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> Contains(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("Contains()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To contain", values)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> difference = values.Except(Subject);

        if (difference.Any())
        {
            Fail(new FailureBuilder("Contains()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To contain", values)
                .AppendEnumerable("But misses", difference)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable does not contain the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContain(params TElement[] values) => DoesNotContain((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable does not contain the values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContain(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        IEnumerable<TElement> intersection = values.Intersect(Subject);

        if (intersection.Any())
        {
            Fail(new FailureBuilder("DoesNotContain()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("Not to contain", values)
                .AppendEnumerable("But contains", intersection)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains only the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsOnly(params TElement[] values) => ContainsOnly((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains only the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsOnly(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("DoesNotContain()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("Not to contain", values)
                .Append("But is null")
                .Finish());
        }

        IEnumerable<TElement> difference = Subject.Except(values);

        if (difference.Any())
        {
            Fail(new FailureBuilder("ContainsOnly()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To only contain", values)
                .AppendEnumerable("But also contains", difference)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains other values than the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainOnly(params TElement[] values) => DoesNotContainOnly((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains other values than the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainOnly(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        IEnumerable<TElement> difference = Subject.Except(values);

        if (!difference.Any())
        {
            Fail(new FailureBuilder("DoesNotContainOnly()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To contain other elements besides", values)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsExactly(params TElement[] values) => ContainsExactly((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsExactly(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("ContainsExactly()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To contain exactly", values)
                .Append("But is null")
                .Finish());
            return this;
        }
        else if (!Subject.SequenceEqual(values))
        {
            Fail(new FailureBuilder("ContainsExactly()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To contain exactly", values)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainExactly(params TElement[] values) => DoesNotContainExactly((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainExactly(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }
        else if (Subject.SequenceEqual(values))
        {
            Fail(new FailureBuilder("DoesNotContainExactly()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("Not to contain exactly", values)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains exactly the given values in any order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsExactlyInAnyOrder(params TElement[] values) => ContainsExactlyInAnyOrder((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains exactly the given values in any order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsExactlyInAnyOrder(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("ContainsExactlyInAnyOrder()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To contain exactly in any order", values)
                .Append("But is null")
                .Finish());
            return this;
        }

        List<TElement> valuesList = values.ToList();
        List<TElement> targetList = Subject.ToList();

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
            failureBuilder.AppendEnumerable("Expecting", Subject);
            failureBuilder.AppendEnumerable("To contain exactly in any order", values);

            if (valuesList.Any())
            {
                failureBuilder.AppendEnumerable("But did not find", valuesList);
            }

            if (targetList.Any())
            {
                failureBuilder.AppendEnumerable("But found excess", targetList);
            }

            Fail(failureBuilder.Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given elements in any given order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainExactlyInAnyOrder(params TElement[] values) => DoesNotContainExactlyInAnyOrder((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable does not contain exactly the given elements in any given order.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainExactlyInAnyOrder(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        List<TElement> valuesList = values.ToList();
        List<TElement> targetList = Subject.ToList();

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
            Fail(new FailureBuilder("DoesNotContainExactlyInAnyOrder()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("Not to contain exactly in any order", values)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsSequence(params TElement[] values) => ContainsSequence((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsSequence(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("ContainsSequence()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To contain the sequence", values)
                .Append("But is null")
                .Finish());
            return this;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        foreach (TElement el in Subject)
        {
            if (!it.MoveNext())
            {
                return this;
            }

            if (!Equals(el, it.Current))
            {
                it.Reset();
            }
        }

        Fail(new FailureBuilder("ContainsSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To contain the sequence", values)
                .Finish());

        return null;
    }

    /// <summary>
    /// Checks if the enumerable does not contain a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainSequence(params TElement[] values) => DoesNotContainSequence((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable does not contain a given sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainSequence(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        foreach (TElement el in Subject)
        {
            if (!it.MoveNext())
            {
                Fail(new FailureBuilder("DoesNotContainSequence()")
                    .Append(message)
                    .AppendEnumerable("Expecting", Subject)
                    .AppendEnumerable("Not to contain the sequence", values)
                    .Finish());
                return this;
            }

            if (!Equals(el, it.Current))
            {
                it.Reset();
            }
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsInterleavedSequence(params TElement[] values) => ContainsInterleavedSequence((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable contains a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsInterleavedSequence(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("ContainsInterleavedSequence()")
                .Append(message)
                .Append("Expecting", Subject)
                .AppendEnumerable("To contain the interleaved sequence", values)
                .Append("But is null")
                .Finish());
            return this;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();

        if (!it.MoveNext())
        {
            return this;
        }

        foreach (TElement el in Subject)
        {
            if (Equals(el, it.Current) && !it.MoveNext())
            {
                return this;
            }
        }

        Fail(new FailureBuilder("ContainsInterleavedSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("To contain the interleaved sequence", values)
                .Finish());

        return this;
    }

    /// <summary>
    /// Checks if the enumerable does not contain a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainInterleavedSequence(params TElement[] values) => DoesNotContainInterleavedSequence((IEnumerable<TElement>)values);

    /// <summary>
    /// Checks if the enumerable does not contain a given an interleaved sequence of values.
    /// </summary>
    /// <param name="values">The values to check for.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainInterleavedSequence(IEnumerable<TElement> values, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        using IEnumerator<TElement> it = values.GetEnumerator();
        bool failed = !it.MoveNext();

        if (!failed)
        {
            foreach (TElement el in Subject)
            {
                if (Equals(el, it.Current) && !it.MoveNext())
                {
                    failed = true;
                    break;
                }
            }
        }

        if (failed)
        {
            Fail(new FailureBuilder("DoesNotContainInterleavedSequence()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .AppendEnumerable("Not to contain the interleaved sequence", values)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable contains null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> ContainsNull(string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("ContainsNull()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append<object>("To contain", null)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> nulls = Subject.Where(x => x is null);

        if (!nulls.Any())
        {
            Fail(new FailureBuilder("ContainsNull()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append<object>("To contain", null)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks if the enumerable does not contain null.
    /// </summary>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> DoesNotContainNull(string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        IEnumerable<TElement> nulls = Subject.Where(x => x is null);

        if (nulls.Any())
        {
            Fail(new FailureBuilder("DoesNotContainNull()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append<object>("Not to contain", null)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks that a condition holds for all elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for all elements.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> AllSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To all satisfy", condition)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> failed = Subject.Where(x => !condition.Invoke(x));

        if (failed.Any())
        {
            Fail(new FailureBuilder("AllSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("To all satisfy", condition)
                .AppendEnumerable("But did not hold for", failed)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks that a condition holds for some element in the enumerable.
    /// </summary>
    /// <param name="condition">The condition which needs to hold for some element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> SomeSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .Append("Expecting", Subject)
                .Append("To have any element satisfying", condition)
                .Append("But is null")
                .Finish());
            return this;
        }

        IEnumerable<TElement> holds = Subject.Where(condition);

        if (!holds.Any())
        {
            Fail(new FailureBuilder("SomeSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("To have any element satisfying", condition)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Checks that a condition holds for none of the elements in an enumerable.
    /// </summary>
    /// <param name="condition">The condition which may not hold for each element.</param>
    /// <param name="message">Custom message for the assertion failure.</param>
    /// <returns>The current assertion.</returns>
    public EnumerableAssertion<TElement> NoneSatisfy(Func<TElement, bool> condition, string? message = null)
    {
        if (Subject is null)
        {
            return this;
        }

        IEnumerable<TElement> holds = Subject.Where(condition);

        if (holds.Any())
        {
            Fail(new FailureBuilder("NoneSatisfy()")
                .Append(message)
                .AppendEnumerable("Expecting", Subject)
                .Append("Not to have elements satisfying", condition)
                .AppendEnumerable("But found", holds)
                .Finish());
        }

        return this;
    }

    /// <summary>
    /// Creates a new assertion for a filtered version of the target enumerable.
    /// </summary>
    /// <param name="condition">The condition to filter on.</param>
    /// <returns>A new assertion for a filtered version of the target enumerable.</returns>
    public EnumerableAssertion<TElement> Where(Func<TElement, bool> condition) => new EnumerableAssertion<TElement>(FailureHandler, Subject.Where(condition));

    /// <summary>
    /// Creates a new assertion for a projected version of the target enumerable.
    /// </summary>
    /// <typeparam name="T">The output type of the projection.</typeparam>
    /// <param name="selector">The selector for the projection.</param>
    /// <returns>A new assertion for a projected version of the target enumerable.</returns>
    public EnumerableAssertion<T> Select<T>(Func<TElement, T> selector) => new EnumerableAssertion<T>(FailureHandler, Subject.Select(selector));
}
