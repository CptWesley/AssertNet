---
title: DoesNotHaveHashCode<TAssert>(TAssert, System.Int32, System.String)
has_children: true
parent: Methods
grand_parent: ObjectAssertions
ancestor: AssertNet
---
# DoesNotHaveHashCode&lt;TAssert&gt;(TAssert, System.Int32, System.String)

```csharp
public static TAssert DoesNotHaveHashCode<TAssert>(TAssert assertion, System.Int32 hashCode, System.String message);
```

## Summary
Checks that an object does not have a certain hash code.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert||
|`hashCode`|[System.Int32](https://learn.microsoft.com/en-us/dotnet/api/system.int32)|The forbidden hash code of the object.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The current assertion.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
