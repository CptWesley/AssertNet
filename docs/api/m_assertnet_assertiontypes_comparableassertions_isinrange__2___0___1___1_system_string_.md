---
title: IsInRange<TAssert, TSubject>(TAssert, TSubject, TSubject, System.String)
has_children: true
parent: Methods
grand_parent: ComparableAssertions
ancestor: AssertNet
---
# IsInRange&lt;TAssert, TSubject&gt;(TAssert, TSubject, TSubject, System.String)

```csharp
public static TAssert IsInRange<TAssert, TSubject>(TAssert assertion, TSubject minimum, TSubject maximum, System.String message);
```

## Summary
Asserts if a double is within a certain range.

## Parameters
| Name      | Type                                                                        | Description                                      |
|:----------|:----------------------------------------------------------------------------|:-------------------------------------------------|
| assertion | TAssert                                                                     | The value under test to assert on.               |
| minimum   | TSubject                                                                    | Lower bound of the range the value should be in. |
| maximum   | TSubject                                                                    | Upper bound of the range the value should be in. |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Custom message for the assertion failure.        |


## Returns
| Type    | Description            |
|:--------|:-----------------------|
| TAssert | The current assertion. |

# Exceptions
| Type                                                                                              | Description                                              |
|:--------------------------------------------------------------------------------------------------|:---------------------------------------------------------|
| [System.ArgumentException](https://learn.microsoft.com/en-us/dotnet/api/system.argumentexception) | Thrown if the maximum is larger or equal to the minimum. |


## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
