using System;
using System.Collections.Generic;
using System.Linq;
using AssertNet.Core.Failures;

namespace AssertNet.FailureHandlers
{
    /// <summary>
    /// Creates a <see cref="IFailureHandler"/> instance based on the available frameworks.
    /// </summary>
    public static class FailureHandlerFactory
    {
        /// <summary>
        /// Creates a <see cref="IFailureHandler"/> instance based on the avaiable testing frameworks.
        /// </summary>
        /// <returns>A new <see cref="IFailureHandler"/> instance.</returns>
        public static IFailureHandler Create()
        {
            IEnumerable<Type> types = typeof(FailureHandlerFactory).Assembly.GetTypes()
                .Where(t => typeof(IFailureHandler).IsAssignableFrom(t) && !t.IsAbstract && t != typeof(FallbackFailureHandler));
            foreach (Type type in types)
            {
                IFailureHandler handler = Activator.CreateInstance(type) as IFailureHandler;

                if (handler.IsAvailable())
                {
                    return handler;
                }
            }

            return new FallbackFailureHandler();
        }
    }
}
