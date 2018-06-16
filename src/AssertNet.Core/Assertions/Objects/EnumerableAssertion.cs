using System.Collections.Generic;
using System.Linq;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> IsEmpty()
        {
            if (Target.Any())
            {
                Fail(new FailureBuilder("IsEmpty()")
                    .Append("Expecting", Target)
                    .AppendEnumerable("To be empty, but contains", Target)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable is not empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> IsNotEmpty()
        {
            if (!Target.Any())
            {
                Fail(new FailureBuilder("IsNotEmpty()")
                    .Append("Expecting", Target)
                    .Append("Not to be empty")
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable has a certain size.
        /// </summary>
        /// <param name="size">The size the enumerable should have.</param>
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> HasSize(int size)
        {
            int realSize = Target.Count();
            if (realSize != size)
            {
                Fail(new FailureBuilder("HasSize()")
                    .Append("Expecting", Target)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> HasAtLeastSize(int size)
        {
            int realSize = Target.Count();
            if (realSize < size)
            {
                Fail(new FailureBuilder("HasAtLeastSize()")
                    .Append("Expecting", Target)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> HasAtMostSize(int size)
        {
            int realSize = Target.Count();
            if (realSize > size)
            {
                Fail(new FailureBuilder("HasAtMostSize()")
                    .Append("Expecting", Target)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> Contains(IEnumerable<TElement> values)
        {
            IEnumerable<TElement> difference = values.Except(Target);

            if (difference.Any())
            {
                Fail(new FailureBuilder("Contains()")
                    .AppendEnumerable("Expecting", Target)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> DoesNotContain(IEnumerable<TElement> values)
        {
            IEnumerable<TElement> intersection = values.Intersect(Target);

            if (intersection.Any())
            {
                Fail(new FailureBuilder("DoesNotContain()")
                    .AppendEnumerable("Expecting", Target)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> ContainsOnly(IEnumerable<TElement> values)
        {
            IEnumerable<TElement> difference = Target.Except(values);

            if (difference.Any())
            {
                Fail(new FailureBuilder("ContainsOnly()")
                    .AppendEnumerable("Expecting", Target)
                    .AppendEnumerable("To only contain", values)
                    .AppendEnumerable("But also contains", difference)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> ContainsExactly(IEnumerable<TElement> values)
        {
            if (!Target.SequenceEqual(values))
            {
                Fail(new FailureBuilder("ContainsExactly()")
                    .AppendEnumerable("Expecting", Target)
                    .AppendEnumerable("To contain exactly", values)
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
        /// <returns>The current assertion.</returns>
        public EnumerableAssertion<TElement> ContainsExactlyInAnyOrder(IEnumerable<TElement> values)
        {
            List<TElement> valuesList = values.ToList();
            List<TElement> targetList = Target.ToList();

            FailureBuilder failureBuilder = new FailureBuilder("ContainsExactlyInAnyOrder()");

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
                failureBuilder.AppendEnumerable("Expecting", Target);
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
    }
}
