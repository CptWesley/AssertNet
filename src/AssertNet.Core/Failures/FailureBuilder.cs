using System;
using System.Collections;
using System.Linq;
using System.Text;

namespace AssertNet.Core.Failures
{
    /// <summary>
    /// Class representing an assertion failure text.
    /// </summary>
    public class FailureBuilder
    {
        private StringBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="FailureBuilder"/> class.
        /// </summary>
        /// <param name="name">The name of the assertion which failed.</param>
        public FailureBuilder(string name)
        {
            _builder = new StringBuilder($"{name} Assertion failure");
        }

        /// <summary>
        /// Appends an object line.
        /// </summary>
        /// <param name="objectName">Name of the object.</param>
        /// <param name="part">The object.</param>
        /// <returns>The current <see cref="FailureBuilder"/> instance.</returns>
        public FailureBuilder Append(string objectName, object part)
        {
            _builder.Append($"{Environment.NewLine}{objectName}:{Environment.NewLine}{StringOf(part)}");
            return this;
        }

        /// <summary>
        /// Appends the specified line.
        /// </summary>
        /// <param name="line">The line.</param>
        /// <returns>The current <see cref="FailureBuilder"/> instance.</returns>
        public FailureBuilder Append(string line)
        {
            _builder.Append($"{Environment.NewLine}{line}");
            return this;
        }

        /// <summary>
        /// Finishes the FailureBuilder instance.
        /// </summary>
        /// <returns>The assertion error message created.</returns>
        public string Finish() => _builder.ToString();

        /// <summary>
        /// Gets the string version of an object.
        /// </summary>
        /// <param name="ob">The object to get the string version of.</param>
        /// <returns>"null" if the object is null. The value of .ToString() otherwise.</returns>
        private static string StringOf(object ob)
        {
            if (ob == null)
            {
                return "null";
            }

            if (ob is IEnumerable)
            {
                return $"{ob.GetType().Name} [{string.Join(", ", ((IEnumerable)ob).Cast<object>())}]";
            }

            return ob.ToString();
        }
    }
}
