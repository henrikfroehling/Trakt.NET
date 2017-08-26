namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IHasRequestBody_Tests
    {
        [Fact]
        public void Test_IHasRequestBody_1_Is_Interface()
        {
            typeof(IHasRequestBody<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IHasRequestBody_1_Has_GenericTypeParameter()
        {
            typeof(IHasRequestBody<>).ContainsGenericParameters.Should().BeTrue();
            typeof(IHasRequestBody<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_IHasRequestBody_1_Has_RequestBody_Property()
        {
            var propertyInfo = typeof(IHasRequestBody<int>).GetProperties()
                                                                .Where(p => p.Name == "RequestBody")
                                                                .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int));
        }
    }
}
