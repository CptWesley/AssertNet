#pragma warning disable S1244 // Intentionally disabled for the exact equality.

using System.Numerics;

namespace AssertNet.Core.Helpers;

/// <summary>
/// Provides helper methods for dealing with slightly more permissive equality checks.
/// </summary>
public static class EqualityHelper
{
    /// <inheritdoc cref="object.Equals(object, object)" />
    public static new bool Equals(object? objA, object? objB)
        => (objA, objB) switch
        {
            (byte a, byte b) => a == b,
            (byte a, sbyte b) => a == b,
            (byte a, ushort b) => a == b,
            (byte a, short b) => a == b,
            (byte a, uint b) => a == b,
            (byte a, int b) => a == b,
            (byte a, ulong b) => a == b,
            (byte a, long b) => a == b,
            (byte a, float b) => a == b,
            (byte a, double b) => a == b,
            (byte a, decimal b) => a == b,
            (byte a, BigInteger b) => a == b,
            (sbyte a, byte b) => a == b,
            (sbyte a, sbyte b) => a == b,
            (sbyte a, ushort b) => a == b,
            (sbyte a, short b) => a == b,
            (sbyte a, uint b) => a == b,
            (sbyte a, int b) => a == b,
            (sbyte a, ulong b) => (BigInteger)a == (BigInteger)b,
            (sbyte a, long b) => a == b,
            (sbyte a, float b) => a == b,
            (sbyte a, double b) => a == b,
            (sbyte a, decimal b) => a == b,
            (sbyte a, BigInteger b) => a == b,
            (ushort a, byte b) => a == b,
            (ushort a, sbyte b) => a == b,
            (ushort a, ushort b) => a == b,
            (ushort a, short b) => a == b,
            (ushort a, uint b) => a == b,
            (ushort a, int b) => a == b,
            (ushort a, ulong b) => a == b,
            (ushort a, long b) => a == b,
            (ushort a, float b) => a == b,
            (ushort a, double b) => a == b,
            (ushort a, decimal b) => a == b,
            (ushort a, BigInteger b) => a == b,
            (short a, byte b) => a == b,
            (short a, sbyte b) => a == b,
            (short a, ushort b) => a == b,
            (short a, short b) => a == b,
            (short a, uint b) => a == b,
            (short a, int b) => a == b,
            (short a, ulong b) => (BigInteger)a == (BigInteger)b,
            (short a, long b) => a == b,
            (short a, float b) => a == b,
            (short a, double b) => a == b,
            (short a, decimal b) => a == b,
            (short a, BigInteger b) => a == b,
            (uint a, byte b) => a == b,
            (uint a, sbyte b) => a == b,
            (uint a, ushort b) => a == b,
            (uint a, short b) => a == b,
            (uint a, uint b) => a == b,
            (uint a, int b) => a == b,
            (uint a, ulong b) => a == b,
            (uint a, long b) => a == b,
            (uint a, float b) => a == b,
            (uint a, double b) => a == b,
            (uint a, decimal b) => a == b,
            (uint a, BigInteger b) => a == b,
            (int a, byte b) => a == b,
            (int a, sbyte b) => a == b,
            (int a, ushort b) => a == b,
            (int a, short b) => a == b,
            (int a, uint b) => a == b,
            (int a, int b) => a == b,
            (int a, ulong b) => (BigInteger)a == (BigInteger)b,
            (int a, long b) => a == b,
            (int a, float b) => a == b,
            (int a, double b) => a == b,
            (int a, decimal b) => a == b,
            (int a, BigInteger b) => a == b,
            (ulong a, byte b) => a == b,
            (ulong a, sbyte b) => (BigInteger)a == (BigInteger)b,
            (ulong a, ushort b) => a == b,
            (ulong a, short b) => (BigInteger)a == (BigInteger)b,
            (ulong a, uint b) => a == b,
            (ulong a, int b) => (BigInteger)a == (BigInteger)b,
            (ulong a, ulong b) => a == b,
            (ulong a, long b) => (BigInteger)a == (BigInteger)b,
            (ulong a, float b) => a == b,
            (ulong a, double b) => a == b,
            (ulong a, decimal b) => a == b,
            (ulong a, BigInteger b) => a == b,
            (long a, byte b) => a == b,
            (long a, sbyte b) => a == b,
            (long a, ushort b) => a == b,
            (long a, short b) => a == b,
            (long a, uint b) => a == b,
            (long a, int b) => a == b,
            (long a, ulong b) => (BigInteger)a == (BigInteger)b,
            (long a, long b) => a == b,
            (long a, float b) => a == b,
            (long a, double b) => a == b,
            (long a, decimal b) => a == b,
            (long a, BigInteger b) => a == b,
            (float a, byte b) => a == b,
            (float a, sbyte b) => a == b,
            (float a, ushort b) => a == b,
            (float a, short b) => a == b,
            (float a, uint b) => a == b,
            (float a, int b) => a == b,
            (float a, ulong b) => a == b,
            (float a, long b) => a == b,
            (float a, float b) => a == b,
            (float a, double b) => a == b,
            (double a, byte b) => a == b,
            (double a, sbyte b) => a == b,
            (double a, ushort b) => a == b,
            (double a, short b) => a == b,
            (double a, uint b) => a == b,
            (double a, int b) => a == b,
            (double a, ulong b) => a == b,
            (double a, long b) => a == b,
            (double a, float b) => a == b,
            (double a, double b) => a == b,
            (decimal a, byte b) => a == b,
            (decimal a, sbyte b) => a == b,
            (decimal a, ushort b) => a == b,
            (decimal a, short b) => a == b,
            (decimal a, uint b) => a == b,
            (decimal a, int b) => a == b,
            (decimal a, ulong b) => a == b,
            (decimal a, long b) => a == b,
            (decimal a, decimal b) => a == b,
            (BigInteger a, byte b) => a == b,
            (BigInteger a, sbyte b) => a == b,
            (BigInteger a, ushort b) => a == b,
            (BigInteger a, short b) => a == b,
            (BigInteger a, uint b) => a == b,
            (BigInteger a, int b) => a == b,
            (BigInteger a, ulong b) => a == b,
            (BigInteger a, long b) => a == b,
            (BigInteger a, BigInteger b) => a == b,

            (float a, BigInteger b) => TryAsBigInteger(a, out var c) && c == b,
            (double a, BigInteger b) => TryAsBigInteger(a, out var c) && c == b,
            (decimal a, BigInteger b) => TryAsBigInteger(a, out var c) && c == b,
            (BigInteger a, float b) => TryAsBigInteger(b, out var c) && a == c,
            (BigInteger a, double b) => TryAsBigInteger(b, out var c) && a == c,
            (BigInteger a, decimal b) => TryAsBigInteger(b, out var c) && a == c,

            (float a, decimal b) => EqualsDecimal(a, b),
            (double a, decimal b) => EqualsDecimal(a, b),
            (decimal a, float b) => EqualsDecimal(b, a),
            (decimal a, double b) => EqualsDecimal(b, a),

            _ => object.Equals(objA, objB),
        };

    private static bool TryAsBigInteger(float value, out BigInteger result)
    {
        if (value % 1 == 0)
        {
            result = (BigInteger)(long)value;
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }

    private static bool TryAsBigInteger(double value, out BigInteger result)
    {
        if (value % 1 == 0)
        {
            result = (BigInteger)(long)value;
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }

    private static bool TryAsBigInteger(decimal value, out BigInteger result)
    {
        if (value % 1 == 0)
        {
            result = (BigInteger)(long)value;
            return true;
        }
        else
        {
            result = default;
            return false;
        }
    }

    private static bool EqualsDecimal(float f, decimal d)
    {
        const float decimalMin = (float)decimal.MinValue;
        const float decimalMax = (float)decimal.MaxValue;

        if (f < decimalMin || f > decimalMax)
        {
            return false;
        }

        return (decimal)f == d;
    }

    private static bool EqualsDecimal(double f, decimal d)
    {
        const double decimalMin = (double)decimal.MinValue;
        const double decimalMax = (double)decimal.MaxValue;

        if (f < decimalMin || f > decimalMax)
        {
            return false;
        }

        return (decimal)f == d;
    }
}
