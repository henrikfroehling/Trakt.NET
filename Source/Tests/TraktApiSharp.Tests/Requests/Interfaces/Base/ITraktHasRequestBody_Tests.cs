namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHasRequestBody_Tests
    {
        [Fact]
        public void Test_ITraktHasRequestBody_Is_Interface()
        {
            typeof(ITraktHasRequestBody<>).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHasRequestBody_Has_GenericTypeParameter()
        {
            typeof(ITraktHasRequestBody<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ITraktHasRequestBody<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [Fact]
        public void Test_ITraktHasRequestBody_Has_RequestBody_Property()
        {
            var requestBodyContentPropertyInfo = typeof(ITraktHasRequestBody<int>).GetProperties()
                                                                                  .Where(p => p.Name == "RequestBody")
                                                                                  .FirstOrDefault();

            requestBodyContentPropertyInfo.CanRead.Should().BeTrue();
            requestBodyContentPropertyInfo.CanWrite.Should().BeTrue();
            requestBodyContentPropertyInfo.PropertyType.Should().Be(typeof(int));
        }
    }
}
