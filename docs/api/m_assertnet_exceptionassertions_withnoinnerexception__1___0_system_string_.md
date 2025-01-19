---
title: WithNoInnerException<TAssert>(TAssert, System.String)
has_children: true
parent: Methods
grand_parent: ExceptionAssertions
ancestor: AssertNet
---
# WithNoInnerException&lt;TAssert&gt;(TAssert, System.String)

```csharp
public static TAssert WithNoInnerException<TAssert>(TAssert assertion, System.String message);
```

## Summary
Asserts that an exception has no inner exception.

## Parameters
| Name      | Type                                                                        | Description                               |
|:----------|:----------------------------------------------------------------------------|:------------------------------------------|
| assertion | TAssert                                                                     |                                           |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure. |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
