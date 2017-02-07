namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHttpRequest_Tests
    {
        [Fact]
        public void Test_ITraktHttpRequest_Is_Interface()
        {
            typeof(ITraktHttpRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHttpRequest_Has_Method_Property()
        {
            var propertyInfo = typeof(ITraktHttpRequest).GetProperties()
                                                        .Where(p => p.Name == "Method")
                                                        .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(HttpMethod));
        }
    }
}
