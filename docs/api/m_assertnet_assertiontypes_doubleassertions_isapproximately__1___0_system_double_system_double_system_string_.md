---
title: IsApproximately<TAssert>(TAssert, System.Double, System.Double, System.String)
has_children: true
parent: Methods
grand_parent: DoubleAssertions
ancestor: AssertNet
---
# IsApproximately&lt;TAssert&gt;(TAssert, System.Double, System.Double, System.String)

```csharp
public static TAssert IsApproximately<TAssert>(TAssert assertion, System.Double other, System.Double margin, System.String message);
```

## Summary
Ensures that the value under test is approximately equivalent.

## Parameters
| Name      | Type                                                                        | Description                   |
|:----------|:----------------------------------------------------------------------------|:------------------------------|
| assertion | TAssert                                                                     | The original assertion chain. |
| other     | [System.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double) | The value to compare to.      |
| margin    | [System.Double](https://learn.microsoft.com/en-us/dotnet/api/system.double) | The variance to allow.        |
| message   | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | The assertion message.        |


## Returns
| Type    | Description                  |
|:--------|:-----------------------------|
| TAssert | The updated assertion chain. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
