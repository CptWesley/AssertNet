---
title: IsNotApproximately<TAssert>(TAssert, System.Int32, System.Int32, System.String)
has_children: true
parent: Methods
grand_parent: SignedIntAssertions
ancestor: AssertNet
---
# IsNotApproximately&lt;TAssert&gt;(TAssert, System.Int32, System.Int32, System.String)

```csharp
public static TAssert IsNotApproximately<TAssert>(TAssert assertion, System.Int32 other, System.Int32 margin, System.String message);
```

## Summary
Ensures that the value under test is not approximately equivalent.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert|The original assertion chain.|
|`other`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The value to compare to.|
|`margin`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The variance to disallow.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The assertion message.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The updated assertion chain.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
