namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using Xunit;

    public class ITraktHttpRequest_Tests
    {
        [Fact]
        [Trait("Category", "Requests.Interfaces.Base")]
        public void Test_ITraktHttpRequest_IsInterface()
        {
            typeof(ITraktHttpRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        [Trait("Category", "Requests.Interfaces.Base")]
        public void Test_ITraktHttpRequest_Has_Method_Property()
        {
            var methodPropertyInfo = typeof(ITraktHttpRequest).GetProperties()
                                                              .Where(p => p.Name == "Method")
                                                              .FirstOrDefault();

            methodPropertyInfo.CanRead.Should().BeTrue();
            methodPropertyInfo.CanWrite.Should().BeFalse();
            methodPropertyInfo.PropertyType.Should().Be(typeof(HttpMethod));
        }
    }
}
