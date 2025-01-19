---
title: IsNotApproximately<TAssert, TNumber>(TAssert, TNumber, TNumber, System.String)
has_children: true
parent: Methods
grand_parent: NumberAssertions
ancestor: AssertNet
---
# IsNotApproximately&lt;TAssert, TNumber&gt;(TAssert, TNumber, TNumber, System.String)

```csharp
public static TAssert IsNotApproximately<TAssert, TNumber>(TAssert assertion, TNumber other, TNumber margin, System.String message);
```

## Summary
Ensures that the value under test is not approximately equivalent.

## Parameters
|Name|Type|Description|
|-|-|-|
|`assertion`|TAssert|The original assertion chain.|
|`other`|TNumber|The value to compare to.|
|`margin`|TNumber|The variance to disallow.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The assertion message.|

## Returns
|Type|Description|
|-|-|
|TAssert|The updated assertion chain.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
