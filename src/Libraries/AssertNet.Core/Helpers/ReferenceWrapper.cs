using System;
using System.Runtime.CompilerServices;

namespace AssertNet.Core.Helpers;

/// <summary>
/// Struct which wraps an object so we can compare the references.
/// </summary>
internal struct ReferenceWrapper : IEquatable<ReferenceWrapper>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ReferenceWrapper"/> struct.
    /// </summary>
    /// <param name="target">The target.</param>
    internal ReferenceWrapper(object target)
        => Target = target;

    /// <summary>
    /// Gets the target.
    /// </summary>
    internal object Target { get; }

    /// <inheritdoc/>
    public override bool Equals(object obj)
    {
        if (obj is ReferenceWrapper other)
        {
            return Equals(other);
        }

        return false;
    }

    /// <inheritdoc/>
    public override int GetHashCode()
        => RuntimeHelpers.GetHashCode(Target);

    /// <inheritdoc/>
    public bool Equals(ReferenceWrapper other)
        => ReferenceEquals(Target, other.Target);
}
