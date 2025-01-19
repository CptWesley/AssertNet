---
title: AtMostOnce(System.String)
has_children: true
parent: Methods
grand_parent: InvocationAssertion<T>
ancestor: AssertNet.Moq
---
# AtMostOnce(System.String)

```csharp
public AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>> AtMostOnce(System.String message);
```

## Summary
Asserts that the expression was invoked at most once.

## Parameters
| Name    | Type                                                                        | Description                               |
|:--------|:----------------------------------------------------------------------------|:------------------------------------------|
| message | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure. |


## Returns
| Type                                                 | Description                                                 |
|:-----------------------------------------------------|:------------------------------------------------------------|
| AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>> | An assertion on the mock we were making an assertion about. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
