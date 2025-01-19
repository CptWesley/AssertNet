---
title: Append<T>(System.String, T)
has_children: true
parent: Methods
grand_parent: LegacyFailureBuilder
ancestor: AssertNet
---
# Append&lt;T&gt;(System.String, T)

```csharp
public AssertNet.Failures.LegacyFailureBuilder Append<T>(System.String objectName, T part);
```

## Summary
Appends an object line.

## Parameters
| Name       | Type                                                                        | Description         |
|:-----------|:----------------------------------------------------------------------------|:--------------------|
| objectName | [System.String](https://learn.microsoft.com/en-us/dotnet/api/system.string) | Name of the object. |
| part       | T                                                                           | The object.         |


## Returns
| Type                                                                 | Description                                                                                |
|:---------------------------------------------------------------------|:-------------------------------------------------------------------------------------------|
| [LegacyFailureBuilder](t_assertnet_failures_legacyfailurebuilder.md) | The current [LegacyFailureBuilder](t_assertnet_failures_legacyfailurebuilder.md) instance. |

## Available for
- [.NET 7.0 (net7.0)](https://versionsof.net/core/7.0/)
- .NET Standard 2.0 (netstandard2.0)
- .NET Standard 2.1 (netstandard2.1)
