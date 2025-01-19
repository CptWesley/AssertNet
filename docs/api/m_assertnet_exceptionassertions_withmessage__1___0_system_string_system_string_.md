---
title: WithMessage<TAssert>(TAssert, System.String, System.String)
has_children: true
parent: Methods
grand_parent: ExceptionAssertions
ancestor: AssertNet
---
# WithMessage&lt;TAssert&gt;(TAssert, System.String, System.String)

```csharp
public static TAssert WithMessage<TAssert>(TAssert assertion, System.String message, System.String customMessage);
```

## Summary
Asserts that an exception has a certain message.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert||
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|The message which the exception should have.|
|`customMessage`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The current assertion.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
