---
title: AtMost(System.Int32, System.String)
has_children: true
parent: Methods
grand_parent: InvocationAssertion<T>
ancestor: AssertNet.Moq
---
# AtMost(System.Int32, System.String)

```csharp
public AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>> AtMost(System.Int32 count, System.String message);
```

## Summary
Asserts that the expression was invoked at most the given amount of times.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`count`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The maximum amount of invocations.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|:-|:-|
|AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>>|An assertion on the mock we were making an assertion about.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
