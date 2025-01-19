---
title: ToStringYields<TAssert>(TAssert, System.String, System.String)
has_children: true
parent: Methods
grand_parent: ObjectAssertions
ancestor: AssertNet
---
# ToStringYields&lt;TAssert&gt;(TAssert, System.String, System.String)

```csharp
public static TAssert ToStringYields<TAssert>(TAssert assertion, System.String str, System.String message);
```

## Summary
Checks that the ToString() call returns the given string.

## Parameters
| Name      | Type                                                                        | Description                               |
|:----------|:----------------------------------------------------------------------------|:------------------------------------------|
| assertion | TAssert                                                                     |                                           |
| str       | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | The expected ToString() result.           |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure. |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
