---
title: HasSameHashCodeAs<TAssert>(TAssert, System.Object, System.String)
has_children: true
parent: Methods
grand_parent: ObjectAssertions
ancestor: AssertNet
---
# HasSameHashCodeAs&lt;TAssert&gt;(TAssert, System.Object, System.String)

```csharp
public static TAssert HasSameHashCodeAs<TAssert>(TAssert assertion, System.Object other, System.String message);
```

## Summary
Checks that an object has the same hash code as another object.

## Parameters
| Name      | Type                                                                        | Description                                            |
|:----------|:----------------------------------------------------------------------------|:-------------------------------------------------------|
| assertion | TAssert                                                                     |                                                        |
| other     | [System.Object](https://learn.microsoft.com/en-us/dotnet/api/system.object) | The other object which should have the same hash code. |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure.              |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
