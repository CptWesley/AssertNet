---
title: DoesNotEndWith<TAssert>(TAssert, System.String, System.String)
has_children: true
parent: Methods
grand_parent: StringAssertions
ancestor: AssertNet
---
# DoesNotEndWith&lt;TAssert&gt;(TAssert, System.String, System.String)

```csharp
public static TAssert DoesNotEndWith<TAssert>(TAssert assertion, System.String substring, System.String message);
```

## Summary
Asserts if a string does not end with a certain substring.

## Parameters
| Name      | Type                                                                        | Description                                    |
|:----------|:----------------------------------------------------------------------------|:-----------------------------------------------|
| assertion | TAssert                                                                     | The initial assertion chain.                   |
| substring | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Substring which the string may not start with. |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure.      |


## Returns
| Type    | Description                  |
|:--------|:-----------------------------|
| TAssert | The updated assertion chain. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
