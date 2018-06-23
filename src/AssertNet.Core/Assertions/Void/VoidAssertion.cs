using System;
using AssertNet.Core.Failures;

namespace AssertNet.Core.Assertions.Void
{
    /// <summary>
    /// Class representing assertions made on actions.
    /// </summary>
    /// <seealso cref="Assertion" />
    public class VoidAssertion : Assertion
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="VoidAssertion"/> class.
        /// </summary>
        /// <param name="failureHandler">The failure handler of the assertion.</param>
        /// <param name="action">The action under test.</param>
        public VoidAssertion(IFailureHandler failureHandler, Action action)
            : base(failureHandler)
        {
            Action = action;
        }

        /// <summary>
        /// Gets the action under test.
        /// </summary>
        /// <value>
        /// The action under test.
        /// </value>
        public Action Action { get; }

        /// <summary>
        /// Assert that the action does not throw an exception of a specific type.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Type of the exception which may not be thrown.</typeparam>
        /// <returns>The current assertion.</returns>
        public VoidAssertion DoesNotThrowException<T>(string message = null)
            where T : Exception
        {
            try
            {
                Action.Invoke();
            }
            catch (T e)
            {
                Fail(new FailureBuilder("DoesNotThrowException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("Not to throw an exception of type", typeof(T))
                    .Append("But threw", e)
                    .Finish());
            }
            catch
            {
                // Pass.
            }

            return this;
        }

        /// <summary>
        /// Assert that the action does not throw any exception.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>The current assertion.</returns>
        public VoidAssertion DoesNotThrowException(string message = null)
        {
            try
            {
                Action.Invoke();
            }
            catch (Exception e)
            {
                Fail(new FailureBuilder("DoesNotThrowException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("Not to throw an exception")
                    .Append("But threw", e)
                    .Finish());
            }

            return this;
        }

        /// <summary>
        /// Assert that the action throws a specific exception.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <typeparam name="T">Exception type to expect.</typeparam>
        /// <returns>An exception assertion for the thrown exception.</returns>
        public ExceptionAssertion ThrowsException<T>(string message = null)
            where T : Exception
        {
            try
            {
                Action.Invoke();
            }
            catch (T e)
            {
                return new ExceptionAssertion(FailureHandler, e);
            }
            catch (Exception e)
            {
                Fail(new FailureBuilder("ThrowsException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("To throw an exception of type", typeof(T))
                    .Append("But threw", e)
                    .Finish());
                return null;
            }

            Fail(new FailureBuilder("ThrowsException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("To throw an exception of type", typeof(T))
                    .Finish());

            return null;
        }

        /// <summary>
        /// Assert that the action throws some exception.
        /// </summary>
        /// <param name="message">Custom message for the assertion failure.</param>
        /// <returns>An exception assertion for the thrown exception.</returns>
        public ExceptionAssertion ThrowsException(string message = null)
        {
            try
            {
                Action.Invoke();
            }
            catch (Exception e)
            {
                return new ExceptionAssertion(FailureHandler, e);
            }

            Fail(new FailureBuilder("ThrowsException()")
                    .Append(message)
                    .Append("Expecting", Action)
                    .Append("To throw an exception, but nothing was thrown")
                    .Finish());

            return null;
        }
    }
}
