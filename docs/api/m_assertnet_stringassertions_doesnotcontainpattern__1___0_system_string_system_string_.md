---
title: DoesNotContainPattern<TAssert>(TAssert, System.String, System.String)
has_children: true
parent: Methods
grand_parent: StringAssertions
ancestor: AssertNet
---
# DoesNotContainPattern&lt;TAssert&gt;(TAssert, System.String, System.String)

```csharp
public static TAssert DoesNotContainPattern<TAssert>(TAssert assertion, System.String pattern, System.String message);
```

## Summary
Determines whether the string under test does not contain a given pattern.

## Parameters
|Name|Type|Description|
|-|-|-|
|`assertion`|TAssert|The initial assertion chain.|
|`pattern`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The pattern to check for.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|-|-|
|TAssert|The updated assertion chain.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
