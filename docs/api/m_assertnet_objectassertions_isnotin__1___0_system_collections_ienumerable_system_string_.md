---
title: IsNotIn<TAssert>(TAssert, System.Collections.IEnumerable, System.String)
has_children: true
parent: Methods
grand_parent: ObjectAssertions
ancestor: AssertNet
---
# IsNotIn&lt;TAssert&gt;(TAssert, System.Collections.IEnumerable, System.String)

```csharp
public static TAssert IsNotIn<TAssert>(TAssert assertion, System.Collections.IEnumerable enumerable, System.String message);
```

## Summary
Checks if the object under test is not in an enumerable.

## Parameters
| Name       | Type                                                                                                          | Description                               |
|:-----------|:--------------------------------------------------------------------------------------------------------------|:------------------------------------------|
| assertion  | TAssert                                                                                                       |                                           |
| enumerable | [System.Collections.IEnumerable](https://learn.microsoft.com/en-us/dotnet/api/system.collections.ienumerable) | The enumerable to check in.               |
| message    | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)                                   | Custom message for the assertion failure. |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
