using AssertNet;
using AssertNet.AssertionTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomAttributeProvider_assertions;

public class IsDecoratedWith
{
    public class Fails
    {
        

    }

    public class Guards
    {
        [Fact]
        public void Decorated_subject()
        {
            var member = typeof(Parent).GetMethod(nameof(Parent.ToString))!;
            IAssertion<MemberInfo> assertion = Asserts.That(member);

            CustomAttributeProviderAssertions.IsDecoratedWith<IAssertion<MemberInfo>, MemberInfo>(assertion, typeof(PureAttribute));
            //assertion.IsDecoratedWith(typeof(PureAttribute), "");
        }
    }
}

file class Parent
{
    /// <inheritdoc />
    /// <remarks>Inheritable attribute.</remarks>
    [Pure]
    public override string ToString() => nameof(Parent);
}

file sealed class Child : Parent { }
