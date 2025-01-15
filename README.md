[![CodeCov](https://codecov.io/gh/CptWesley/AssertNet/branch/master/graph/badge.svg)](https://codecov.io/gh/CptWesley/AssertNet/)

![AssertNet](https://raw.githubusercontent.com/CptWesley/AssertNet/master/logo.png)
### Description
AssertNet is a fluent assertion library for multiple different .NET testing frameworks ([xUnit](https://xunit.github.io/), [NUnit](http://nunit.org/), [MSTest](https://github.com/Microsoft/testfx)) and the mocking framework [Moq](https://github.com/Moq/moq4/). The library is heavily inspired by [AssertJ](http://joel-costigliola.github.io/assertj/), a fluent assertion library for Java. The project originated from a personal frustration caused by a lack of a size assertion in the xUnit framework and my love for AssertJ. Currently most of the most common AssertJ assertions are included in AssertNet, but more advanced assertions are yet to be added. The package for Moq simply adds sugared assertions that look similar to the assertions in the other packages to have more consitensy in the way your tests look like.

### Downloads
Currently there are multiple different NuGet packages available (for different frameworks):  
[AssertNet](https://www.nuget.org/packages/AssertNet/) [![NuGet](https://img.shields.io/nuget/v/AssertNet.svg)](https://www.nuget.org/packages/AssertNet/)  
[AssertNet.Moq](https://www.nuget.org/packages/AssertNet.Moq/) [![NuGet](https://img.shields.io/nuget/v/AssertNet.Moq.svg)](https://www.nuget.org/packages/AssertNet.Moq/)  
  
There is also a third NuGet package available: [AssertNet.Core](https://www.nuget.org/packages/AssertNet.Core/) [![NuGet](https://img.shields.io/nuget/v/AssertNet.Core.svg)](https://www.nuget.org/packages/AssertNet.Core/), which contains all implementations of the custom assertions. This package can be used for adding support to other .NET testing frameworks. More information about this will be available on the wiki.

### Usage
Grab one of the available version mentioned in the __Downloads__ section above.  
Add the following line to the test files where you intend to use _AssertNet_ depending on your version:  
```cs
using AssertNet;
using static AssertNet.AssertionBuilder;
```  

Start writing your new assertions:
```cs
Asserts.That(3).IsEqualTo(3);
Asserts.That(() => DoWackyStuff()).ThrowsException<EvilException>().HasMessage("Something bad went wrong.");
Asserts.That("Hello world!").StartsWith("Hello");
Asserts.That(new int[] { 1, 2, 3 }).HasSize(3).ContainsExactlyInAnyOrder(2, 3, 1);
Asserts.That(someMock).HasInvoked(x => x.SomeStubbedFunction()).Once();
```
More code examples will be supplied on the wiki.
