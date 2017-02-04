namespace TraktApiSharp.Tests.Responses.Interfaces.Base
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using TraktApiSharp.Experimental.Responses.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Responses.Interfaces")]
    public class ITraktResponse_1_Tests
    {
        [Fact]
        public void Test_ITraktResponse_1_Is_Interface()
        {
            typeof(ITraktResponse<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktResponse_1_Has_GenericTypeParameter()
        {
            typeof(ITraktResponse<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktResponse<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktResponse_1_Inherits_ITraktNoContentResponse_Interface()
        {
            typeof(ITraktResponse<>).GetInterfaces().Should().Contain(typeof(ITraktNoContentResponse));
        }

        [Fact]
        public void Test_ITraktResponse_1_Inherits_ITraktResponseHeaders_Interface()
        {
            typeof(ITraktResponse<>).GetInterfaces().Should().Contain(typeof(ITraktResponseHeaders));
        }

        [Fact]
        public void Test_ITraktResponse_1_Inherits_IEquatable_Interface()
        {
            typeof(ITraktResponse<int>).GetInterfaces().Should().Contain(typeof(IEquatable<ITraktResponse<int>>));
        }

        [Fact]
        public void Test_ITraktResponse_1_Has_HasValue_Property()
        {
            var hasValuePropertyInfo = typeof(ITraktResponse<>).GetProperties()
                                                               .Where(p => p.Name == "HasValue")
                                                               .FirstOrDefault();

            hasValuePropertyInfo.CanRead.Should().BeTrue();
            hasValuePropertyInfo.CanWrite.Should().BeFalse();
            hasValuePropertyInfo.PropertyType.Should().Be(typeof(bool));
        }

        [Fact]
        public void Test_ITraktResponse_1_Has_Value_Property()
        {
            var valuePropertyInfo = typeof(ITraktResponse<int>).GetProperties()
                                                               .Where(p => p.Name == "Value")
                                                               .FirstOrDefault();

            valuePropertyInfo.CanRead.Should().BeTrue();
            valuePropertyInfo.CanWrite.Should().BeFalse();
            valuePropertyInfo.PropertyType.Should().Be(typeof(int));
        }
    }
}
