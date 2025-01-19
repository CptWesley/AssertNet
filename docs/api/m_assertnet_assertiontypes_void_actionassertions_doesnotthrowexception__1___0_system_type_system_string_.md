---
title: DoesNotThrowException<TAssert>(TAssert, System.Type, System.String)
has_children: true
parent: Methods
grand_parent: ActionAssertions
ancestor: AssertNet
---
# DoesNotThrowException&lt;TAssert&gt;(TAssert, System.Type, System.String)

```csharp
public static TAssert DoesNotThrowException<TAssert>(TAssert assertion, System.Type t, System.String message);
```

## Summary
Assert that the action does not throw an exception of a specific type.

## Parameters
| Name      | Type                                                                        | Description                                    |
|:----------|:----------------------------------------------------------------------------|:-----------------------------------------------|
| assertion | TAssert                                                                     |                                                |
| t         | [System.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type)     | Type of the exception which may not be thrown. |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure.      |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
