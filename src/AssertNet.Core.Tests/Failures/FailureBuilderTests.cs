using AssertNet.Core.Failures;
using Xunit;
using static System.Environment;

namespace AssertNet.Core.Tests.Failures
{
    /// <summary>
    /// Test class for the <see cref="FailureBuilder"/> class.
    /// </summary>
    public class FailureBuilderTests
    {
        private const string Name = "4fhhnf74m80,h";

        private readonly FailureBuilder _builder;

        /// <summary>
        /// Initializes a new instance of the <see cref="FailureBuilderTests"/> class.
        /// </summary>
        public FailureBuilderTests()
        {
            _builder = new FailureBuilder(Name);
        }

        /// <summary>
        /// Checks that an empty instance is correctly finished.
        /// </summary>
        [Fact]
        public void FinishEmptyTest()
        {
            Assert.Equal($"{Name} Assertion failure", _builder.Finish());
        }

        /// <summary>
        /// Checks that a null instance is correctly appended.
        /// </summary>
        [Fact]
        public void AppendNullTest()
        {
            string title = "vg3y56";
            Assert.Equal($"{Name} Assertion failure{NewLine}{title}:{NewLine}null", _builder.Append(title, null).Finish());
        }

        /// <summary>
        /// Checks that an object instance is correctly appended.
        /// </summary>
        [Fact]
        public void AppendNonNullTest()
        {
            string title = "456445";
            int val = 42;
            Assert.Equal($"{Name} Assertion failure{NewLine}{title}:{NewLine}{val}", _builder.Append(title, val).Finish());
        }

        /// <summary>
        /// Checks that multiple objects are appended correctly.
        /// </summary>
        [Fact]
        public void AppendMultipleTest()
        {
            string title1 = "43266f54r";
            int val1 = 45;
            string title2 = "f6fre";
            int val2 = 87;
            Assert.Equal(
                $"{Name} Assertion failure{NewLine}{title1}:{NewLine}{val1}{NewLine}{title2}:{NewLine}{val2}",
                _builder.Append(title1, val1).Append(title2, val2).Finish());
        }

        /// <summary>
        /// Checks that an IEnumerable instance is correctly appended.
        /// </summary>
        [Fact]
        public void AppendIEnumerableTest()
        {
            string title = "4325f324";
            Assert.Equal(
                $"{Name} Assertion failure{NewLine}{title}:{NewLine}Int32[] [1, 2, 3]",
                _builder.Append(title, new int[] { 1, 2, 3 }).Finish());
        }
    }
}
