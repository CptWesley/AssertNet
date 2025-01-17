﻿namespace AssertNet.AssertionTypes;

/// <summary>
/// Provides extension methods for <see cref="IAssertion"/> implementations.
/// </summary>
public static class AssertionExtensions
{
    /// <summary>
    /// Fails an <paramref name="assertion"/> with a specific <paramref name="message"/>.
    /// </summary>
    /// <param name="assertion">The assertion to trigger the failure on.</param>
    /// <param name="message">The message to fail with.</param>
    [DoesNotReturn]
    public static void Fail(this IAssertion assertion, string message)
    {
        assertion.FailureHandler.Fail(message);
    }
}