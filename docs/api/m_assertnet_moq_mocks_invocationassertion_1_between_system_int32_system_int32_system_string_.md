---
title: Between(System.Int32, System.Int32, System.String)
has_children: true
parent: Methods
grand_parent: InvocationAssertion<T>
ancestor: AssertNet.Moq
---
# Between(System.Int32, System.Int32, System.String)

```csharp
public AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>> Between(System.Int32 minimum, System.Int32 maximum, System.String message);
```

## Summary
Asserts that the expression was invoked a number of times in a certain range.

## Parameters
|Name|Type|Description|
|-|-|-|
|`minimum`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The minimum amount of invocations.|
|`maximum`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The maximum amount of invocations.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|-|-|
|AssertNet.AssertionTypes.IAssertion`1<Moq.Mock`1<T>>|An assertion on the mock we were making an assertion about.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
