namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IHttpRequest_Tests
    {
        [Fact]
        public void Test_IHttpRequest_Is_Interface()
        {
            typeof(IHttpRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IHttpRequest_Has_Method_Property()
        {
            var propertyInfo = typeof(IHttpRequest).GetProperties()
                                                        .Where(p => p.Name == "Method")
                                                        .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(HttpMethod));
        }
    }
}
