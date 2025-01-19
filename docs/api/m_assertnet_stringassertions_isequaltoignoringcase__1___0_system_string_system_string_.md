---
title: IsEqualToIgnoringCase<TAssert>(TAssert, System.String, System.String)
has_children: true
parent: Methods
grand_parent: StringAssertions
ancestor: AssertNet
---
# IsEqualToIgnoringCase&lt;TAssert&gt;(TAssert, System.String, System.String)

```csharp
public static TAssert IsEqualToIgnoringCase<TAssert>(TAssert assertion, System.String other, System.String message);
```

## Summary
Asserts if a string is equal to a given other string if cases are ignored.

## Parameters
| Name      | Type                                                                        | Description                               |
|:----------|:----------------------------------------------------------------------------|:------------------------------------------|
| assertion | TAssert                                                                     | The initial assertion chain.              |
| other     | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | The other string to compare with.         |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure. |


## Returns
| Type    | Description                  |
|:--------|:-----------------------------|
| TAssert | The updated assertion chain. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
