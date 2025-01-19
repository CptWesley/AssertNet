---
title: IsNotApproximately<TAssert>(TAssert, System.SByte, System.SByte, System.String)
has_children: true
parent: Methods
grand_parent: SignedByteAssertions
ancestor: AssertNet
---
# IsNotApproximately&lt;TAssert&gt;(TAssert, System.SByte, System.SByte, System.String)

```csharp
public static TAssert IsNotApproximately<TAssert>(TAssert assertion, System.SByte other, System.SByte margin, System.String message);
```

## Summary
Ensures that the value under test is not approximately equivalent.

## Parameters
|Name|Type|Description|
|-|-|-|
|`assertion`|TAssert|The original assertion chain.|
|`other`|[System.SByte](https://learn.microsoft.com/en-us/dotnet/api/system.sbyte)|The value to compare to.|
|`margin`|[System.SByte](https://learn.microsoft.com/en-us/dotnet/api/system.sbyte)|The variance to disallow.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The assertion message.|

## Returns
|Type|Description|
|-|-|
|TAssert|The updated assertion chain.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
