using System;
using AssertNet.Core.Helpers;
using Xunit;
using static AssertNet.Core.Helpers.EquivalencyHelper;

namespace AssertNet.Core.Tests.Helpers;

/// <summary>
/// Test class for the <see cref="EquivalencyHelper"/> class.
/// </summary>
public static class EquivalencyHelperTests
{
    /// <summary>
    /// Checks that we can correctly find the equalness of integers.
    /// </summary>
    [Fact]
    public static void IntegerTrueTest()
    {
        int val = 42;
        Assert.True(AreEquivalent(val, 42));
        Assert.True(AreEquivalent(42, val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of integers.
    /// </summary>
    [Fact]
    public static void IntegerFalseTest()
    {
        int val = 42;
        Assert.False(AreEquivalent(val, 43));
        Assert.False(AreEquivalent(43, val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of strings.
    /// </summary>
    [Fact]
    public static void StringTrueTest()
    {
        string val = "Hello world!";
        Assert.True(AreEquivalent(val, "Hello world!"));
        Assert.True(AreEquivalent("Hello world!", val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of strings.
    /// </summary>
    [Fact]
    public static void StringFalseTest()
    {
        string val = "Hello world!";
        Assert.False(AreEquivalent(val, "Hello!"));
        Assert.False(AreEquivalent("Hello!", val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of nulls.
    /// </summary>
    [Fact]
    public static void NullTrueTest()
    {
        object val = null;
        Assert.True(AreEquivalent(val, null));
        Assert.True(AreEquivalent(null, val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of nulls.
    /// </summary>
    [Fact]
    public static void NullFalseTest()
    {
        object val = null;
        Assert.False(AreEquivalent(val, "Hello!"));
        Assert.False(AreEquivalent("Hello!", val));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of arrays.
    /// </summary>
    [Fact]
    public static void ArrayTrueTest()
    {
        int[] a = new int[] { 1, 2, 3 };
        int[] b = new int[] { 1, 2, 3 };
        Assert.True(AreEquivalent(a, b));
        Assert.True(AreEquivalent(b, a));
    }

    /// <summary>
    /// Checks that we can correctly find the equalness of arrays.
    /// </summary>
    [Fact]
    public static void ArrayFalseTest()
    {
        int[] a = new int[] { 1, 2, 3 };
        int[] b = new int[] { 1, 2, 4 };
        Assert.False(AreEquivalent(a, b));
        Assert.False(AreEquivalent(b, a));
    }

    /// <summary>
    /// Checks that the function works for more complex objects.
    /// </summary>
    [Fact]
    public static void ComplexTest()
    {
        Random a = new Random(400);
        Random b = new Random(400);

        Assert.True(AreEquivalent(a, b));
        Assert.True(AreEquivalent(b, a));
        a.Next();
        Assert.False(AreEquivalent(a, b));
        Assert.False(AreEquivalent(b, a));
    }

    /// <summary>
    /// Checks that inheritance works correctly.
    /// </summary>
    [Fact]
    public static void InheritanceTest()
    {
        DummyClasses.SonClass a = new DummyClasses.SonClass();
        a.PublicValue = 42;
        a.SetPrivateValue(1337);
        a.SonValue = 50;
        DummyClasses.SonClass b = new DummyClasses.SonClass();
        b.PublicValue = 42;
        b.SetPrivateValue(1337);
        b.SonValue = 50;
        Assert.True(AreEquivalent(a, b));
        Assert.True(AreEquivalent(b, a));
        a.SetPrivateValue(22);
        Assert.False(AreEquivalent(a, b));
        Assert.False(AreEquivalent(b, a));
    }

    /// <summary>
    /// Checks that circular references are handled correctly in deep comparisons.
    /// </summary>
    [Fact]
    public static void CircularDeepTest()
    {
        DummyClasses.CircularClass a = new DummyClasses.CircularClass();
        DummyClasses.CircularClass b = new DummyClasses.CircularClass();
        DummyClasses.CircularClass c = new DummyClasses.CircularClass();
        a.Reference = b;
        b.Reference = a;
        c.Reference = b;
        Assert.True(AreEquivalent(a, c));
        Assert.True(AreEquivalent(c, a));
    }

    /// <summary>
    /// Checks that we can correctly determine deep and shallow equality.
    /// </summary>
    [Fact]
    public static void DeepShallowTest()
    {
        DummyClasses.CircularClass a = new DummyClasses.CircularClass();
        DummyClasses.CircularClass b = new DummyClasses.CircularClass();
        DummyClasses.CircularClass c = new DummyClasses.CircularClass();
        DummyClasses.CircularClass d = new DummyClasses.CircularClass();

        a.Reference = b;
        c.Reference = d;
        Assert.True(AreEquivalent(a, c));
        Assert.True(AreEquivalent(c, a));
        b.Reference = a;
        Assert.False(AreEquivalent(a, c));
        Assert.False(AreEquivalent(c, a));
        d.Reference = c;
        Assert.True(AreEquivalent(a, c));
        Assert.True(AreEquivalent(c, a));
    }

    /// <summary>
    /// Checks that we don't go into an infinite loop if we use this function to override equals.
    /// </summary>
    [Fact]
    public static void EqualsOverrideTest()
    {
        DummyClasses.OverriddenClass a = new DummyClasses.OverriddenClass();
        Assert.Equal(a, a);
    }
}
