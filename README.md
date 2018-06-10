[![CircleCI](https://circleci.com/gh/CptWesley/AssertNET.svg?style=shield)](https://circleci.com/gh/CptWesley/AssertNET)
[![BetterCodeHub](https://bettercodehub.com/edge/badge/CptWesley/AssertNET?branch=master)](https://bettercodehub.com/results/CptWesley/AssertNET)
[![CodeCov](https://codecov.io/gh/CptWesley/AssertNET/branch/master/graph/badge.svg)](https://codecov.io/gh/CptWesley/AssertNET/)

![AssertNET](https://raw.githubusercontent.com/CptWesley/AssertNET/master/logo.png)
### Description
AssertNET is a fluent assertion library for multiple different .NET testing frameworks ([xUnit](https://xunit.github.io/), [NUnit](http://nunit.org/) and [MSTest](https://github.com/Microsoft/testfx)). The library is heavily inspired by [AssertJ](http://joel-costigliola.github.io/assertj/), a fluent assertion library for Java. The project originated from a personal frustration caused by a lack of a size assertion in the xUnit framework and my love for AssertJ. Currently most of the most common AssertJ assertions are included in AssertNET, but more advanced assertions are yet to be added. More readable assertion failure messages are also on the list of things that need to be added in the future.

### Downloads
Currently there are 3 different NuGet packages available (for different testing frameworks):  
[AssertNet.Xunit](https://www.nuget.org/packages/AssertNet.Xunit/)  
[AssertNet.NUnit](https://www.nuget.org/packages/AssertNet.NUnit/)  
[AssertNet.MSTest](https://www.nuget.org/packages/AssertNet.MSTest/)  
  
There is also a fourth NuGet package available: [AssertNet.Core](https://www.nuget.org/packages/AssertNet.Core/), which contains all implementations of the custom assertions. This package can be used for adding support to other .NET testing frameworks. More information about this will be available on the wiki.

### Usage
Grab one of the available version mentioned in the __Downloads__ section above.  
Add the following line to the test files where you intend to use _AssertNET_ depending on your version:  
For xUnit:  
```cs
using static AssertNet.Xunit.Assertions;
```  
For NUnit:  
```cs
using static AssertNet.NUnit.Assertions;
```  
For MSTest:  
```cs
using static AssertNet.MSTest.Assertions;
```  
Start writing your new assertions:
```cs
AssertThat(3).IsEqualTo(3);
AssertThat(() => DoWackyStuff()).ThrowsException<EvilException>().HasMessage("Something bad went wrong.");
AssertThat("Hello world!").StartsWith("Hello");
AssertThat(new int[] { 1, 2, 3 }).HasSize(3).ContainsExactlyInAnyOrder(2, 3, 1);
```
More code examples will be supplied on the wiki.
