using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Objects
{
    /// <summary>
    /// Class representing assertions made on collection objects.
    /// </summary>
    /// <seealso cref="ObjectAssertion{CollectionAssertion}" />
    public class CollectionAssertion : ObjectAssertion<CollectionAssertion>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="CollectionAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="target">The object which is under test.</param>
        public CollectionAssertion(IFailureHandler failureHandler, IEnumerable target)
            : base(failureHandler, target)
        {
        }

        /// <summary>
        /// Gets the collection under test.
        /// </summary>
        /// <value>
        /// The collection under test.
        /// </value>
        public IEnumerable<object> Collection => ((IEnumerable)Target).Cast<object>();

        /// <summary>
        /// Checks if the enumerable is empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public CollectionAssertion IsEmpty()
        {
            if (Collection.Any())
            {
                Fail(new FailureBuilder("IsEmpty()")
                    .Append("Expecting", Target)
                    .AppendEnumerable("To be empty, but contains", Collection)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable is not empty.
        /// </summary>
        /// <returns>The current assertion.</returns>
        public CollectionAssertion IsNotEmpty()
        {
            if (!Collection.Any())
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
        public CollectionAssertion HasSize(int size)
        {
            int realSize = Collection.Count();
            if (realSize != size)
            {
                Fail(new FailureBuilder("HasSize()")
                    .Append("Expecting", Target)
                    .Append("To have a size of", size)
                    .Append("But has a size of", Collection.Count())
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable has at least a certain size.
        /// </summary>
        /// <param name="size">The size the enumerable should have.</param>
        /// <returns>The current assertion.</returns>
        public CollectionAssertion HasAtLeastSize(int size)
        {
            int realSize = Collection.Count();
            if (realSize < size)
            {
                Fail(new FailureBuilder("HasAtLeastSize()")
                    .Append("Expecting", Target)
                    .Append("To have at least a size of", size)
                    .Append("But has a size of", Collection.Count())
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable has at most a certain size.
        /// </summary>
        /// <param name="size">The size the enumerable should have.</param>
        /// <returns>The current assertion.</returns>
        public CollectionAssertion HasAtMostSize(int size)
        {
            int realSize = Collection.Count();
            if (realSize > size)
            {
                Fail(new FailureBuilder("HasAtMostSize()")
                    .Append("Expecting", Target)
                    .Append("To have at most a size of", size)
                    .Append("But has a size of", Collection.Count())
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Checks if the enumerable contains the values.
        /// </summary>
        /// <param name="values">The values to check for.</param>
        /// <returns>The current assertion.</returns>
        public CollectionAssertion Contains(params object[] values)
        {
            object[] difference = values.Except(Collection).ToArray();

            if (difference.Any())
            {
                Fail(new FailureBuilder("Contains()")
                    .AppendEnumerable("Expecting", Collection)
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
        public CollectionAssertion DoesNotContain(params object[] values)
        {
            object[] intersection = values.Intersect(Collection).ToArray();

            if (intersection.Any())
            {
                Fail(new FailureBuilder("DoesNotContain()")
                    .AppendEnumerable("Expecting", Collection)
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
        public CollectionAssertion ContainsOnly(params object[] values)
        {
            object[] difference = Collection.Distinct().Except(values).ToArray();

            if (difference.Any())
            {
                Fail(new FailureBuilder("ContainsOnly()")
                    .AppendEnumerable("Expecting", Collection)
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
        public CollectionAssertion ContainsExactly(params object[] values)
        {
            if (!Collection.SequenceEqual(values))
            {
                Fail(new FailureBuilder("ContainsExactly()")
                    .AppendEnumerable("Expecting", Collection)
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
        public CollectionAssertion ContainsExactlyInAnyOrder(params object[] values)
        {
            List<object> valuesList = values.ToList();
            List<object> collectionList = Collection.ToList();

            FailureBuilder failureBuilder = new FailureBuilder("ContainsExactlyInAnyOrder()");

            for (int i = valuesList.Count - 1; i >= 0; --i)
            {
                int index = collectionList.IndexOf(valuesList[i]);
                if (index >= 0)
                {
                    valuesList.RemoveAt(i);
                    collectionList.RemoveAt(index);
                }
            }

            if (valuesList.Any() || collectionList.Any())
            {
                failureBuilder.AppendEnumerable("Expecting", Collection);
                failureBuilder.AppendEnumerable("To contain exactly in any order", values);

                if (valuesList.Any())
                {
                    failureBuilder.AppendEnumerable("But did not find", valuesList);
                }

                if (collectionList.Any())
                {
                    failureBuilder.AppendEnumerable("But found excess", collectionList);
                }

                Fail(failureBuilder.Finish());
            }

            return this;
        }
    }
}
