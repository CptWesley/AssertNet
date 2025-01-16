namespace AssertNet.Core.Internal;

internal static class EnumerableExtensions
{
    public static IEnumerable<object> AsGeneric(this IEnumerable enumerable)
    {
        foreach (var item in enumerable)
        {
            yield return item;
        }
    }

    public static int Count(this IEnumerable enumerable)
    {
        if (enumerable is ICollection collection)
        {
            return collection.Count;
        }

        if (enumerable is string str)
        {
            return str.Length;
        }

        return Enumerable.Count(enumerable.AsGeneric());
    }

    public static bool Any(this IEnumerable enumerable)
    {
        if (enumerable is ICollection collection)
        {
            return collection.Count > 0;
        }

        if (enumerable is string str)
        {
            return str.Length > 0;
        }

        return Enumerable.Any(enumerable.AsGeneric());
    }
}
