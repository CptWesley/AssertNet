using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AssertNet.Core.FailureHandlers;

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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to be empty.");
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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to contain at least 1 element.");
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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to have a length of '{size}', while it was '{realSize}'.");
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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to have at least a length of '{size}', while it was '{realSize}'.");
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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to have at most a length of '{size}', while it was '{realSize}'.");
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
            foreach (object value in values)
            {
                if (!Collection.Contains(value))
                {
                    Fail($"Expected '{value}' to be in '[{string.Join(", ", Collection)}]'.");
                }
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
            foreach (object value in values)
            {
                if (Collection.Contains(value))
                {
                    Fail($"Expected '{value}' not to be in '[{string.Join(", ", Collection)}]'.");
                }
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
            IEnumerable<object> difference = Collection.Distinct().Except(values);
            if (difference.Any())
            {
                Fail($"Expected difference to be empty, but found '[{string.Join(", ", difference)}]'.");
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
                Fail($"Expected '[{string.Join(", ", Collection)}]' to be equal to '[{string.Join(", ", values)}]'.");
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

            if (valuesList.Count != collectionList.Count)
            {
                Fail($"Expected '[{string.Join(", ", collectionList)}]' ({collectionList.Count}) to be of the same length as '[{string.Join(", ", valuesList)}]' ({valuesList.Count}).");
            }

            for (int i = valuesList.Count - 1; i >= 0; --i)
            {
                int index = collectionList.IndexOf(valuesList[i]);
                if (index == -1)
                {
                    Fail($"Excess element '{valuesList[i]}' found in values '[{string.Join(", ", values)}]'.");
                }
                else
                {
                    valuesList.RemoveAt(index);
                }
            }

            return this;
        }
    }
}
