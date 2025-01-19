---
title: IsExactlyInstanceOf<TAssert>(TAssert, System.Type, System.String)
has_children: true
parent: Methods
grand_parent: ObjectAssertions
ancestor: AssertNet
---
# IsExactlyInstanceOf&lt;TAssert&gt;(TAssert, System.Type, System.String)

```csharp
public static TAssert IsExactlyInstanceOf<TAssert>(TAssert assertion, System.Type t, System.String message);
```

## Summary
Checks if the object under test is exactly an instance of a certain type.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert||
|`t`|[System.Type](https://learn.microsoft.com/en-us/dotnet/api/system.type)|Type to check for.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The current assertion.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
