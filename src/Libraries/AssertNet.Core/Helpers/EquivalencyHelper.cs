namespace AssertNet.Core.Helpers;

/// <summary>
/// Helper class for checking equivalence of two objects.
/// </summary>
public static class EquivalencyHelper
{
    /// <summary>
    /// Checks if two objects are equivalent.
    /// </summary>
    /// <param name="that">The object to check for.</param>
    /// <param name="other">The object to check with.</param>
    /// <returns>True if internally equal, false otherwise.</returns>
    public static bool AreEquivalent(object? that, object? other)
        => AreEquivalent(that, other, new Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>>());

    private static bool AreEquivalent(this object? that, object? other, Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>> comparisons)
    {
        if (that is null || other is null)
        {
            return that == other;
        }

        Type type = that.GetType();

        if (that is string || type.IsPrimitive)
        {
            return that.Equals(other);
        }

        if (type != other.GetType())
        {
            return false;
        }

        ReferenceWrapper thatWrapper = new ReferenceWrapper(that);
        ReferenceWrapper otherWrapper = new ReferenceWrapper(other);

        if (comparisons.TryGetValue(thatWrapper, out var set) && set.Contains(otherWrapper))
        {
            return true;
        }

        comparisons.AddComparison(thatWrapper, otherWrapper);
        comparisons.AddComparison(otherWrapper, thatWrapper);

        if (type.IsArray)
        {
            return ArrayEquals((Array)that, (Array)other, comparisons);
        }

        return ObjectEquals(that, other, comparisons);
    }

    private static bool ArrayEquals(Array that, Array other, Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>> comparisons)
    {
        if (that.Length != other.Length)
        {
            return false;
        }

        for (int i = 0; i < that.Length; ++i)
        {
            object thatCur = that.GetValue(i);
            object otherCur = other.GetValue(i);
            if (thatCur == null && otherCur == null)
            {
                continue;
            }

            if (!AreEquivalent(thatCur, otherCur, comparisons))
            {
                return false;
            }
        }

        return true;
    }

    private static bool ObjectEquals(object that, object other, Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>> comparisons)
    {
        Type type = that.GetType();
        while (type != null)
        {
            if (!EqualsForType(that, other, type, comparisons))
            {
                return false;
            }

            type = type.BaseType;
        }

        return true;
    }

    private static bool EqualsForType(object that, object other, Type type, Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>> comparisons)
    {
        FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.DeclaredOnly);

        foreach (FieldInfo field in fields)
        {
            object thatValue = field.GetValue(that);
            object otherValue = field.GetValue(other);

            if (!AreEquivalent(thatValue, otherValue, comparisons))
            {
                return false;
            }
        }

        return true;
    }

    private static void AddComparison(this Dictionary<ReferenceWrapper, HashSet<ReferenceWrapper>> comparisons, ReferenceWrapper that, ReferenceWrapper other)
    {
        if (!comparisons.ContainsKey(that))
        {
            comparisons[that] = new HashSet<ReferenceWrapper>();
        }

        comparisons[that].Add(other);
    }
}
