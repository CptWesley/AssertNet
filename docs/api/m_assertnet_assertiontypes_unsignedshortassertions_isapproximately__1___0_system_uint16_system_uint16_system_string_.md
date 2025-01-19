---
title: IsApproximately<TAssert>(TAssert, System.UInt16, System.UInt16, System.String)
has_children: true
parent: Methods
grand_parent: UnsignedShortAssertions
ancestor: AssertNet
---
# IsApproximately&lt;TAssert&gt;(TAssert, System.UInt16, System.UInt16, System.String)

```csharp
public static TAssert IsApproximately<TAssert>(TAssert assertion, System.UInt16 other, System.UInt16 margin, System.String message);
```

## Summary
Ensures that the value under test is approximately equivalent.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert|The original assertion chain.|
|`other`|[System.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16)|The value to compare to.|
|`margin`|[System.UInt16](https://learn.microsoft.com/en-us/dotnet/api/system.uint16)|The variance to allow.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The assertion message.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The updated assertion chain.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
