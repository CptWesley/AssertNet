---
title: IsLessThanOrEqualTo<TAssert, TSubject>(TAssert, TSubject, System.String)
has_children: true
parent: Methods
grand_parent: ComparableAssertions
ancestor: AssertNet
---
# IsLessThanOrEqualTo&lt;TAssert, TSubject&gt;(TAssert, TSubject, System.String)

```csharp
public static TAssert IsLessThanOrEqualTo<TAssert, TSubject>(TAssert assertion, TSubject other, System.String message);
```

## Summary
Asserts if the asserted value is less than or equal to the value under test.

## Parameters
|Name|Type|Description|
|:-|:-|:-|
|`assertion`|TAssert|The value under test to assert on.|
|`other`|TSubject|Value which should be less than or equal to the value under test.|
|`message`|[System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string)|Custom message for the assertion failure.|

## Returns
|Type|Description|
|:-|:-|
|TAssert|The current assertion.|

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
