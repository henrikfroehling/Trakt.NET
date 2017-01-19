namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using System.Net.Http;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
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
            var methodPropertyInfo = typeof(ITraktHttpRequest).GetProperties()
                                                              .Where(p => p.Name == "Method")
                                                              .FirstOrDefault();

            methodPropertyInfo.CanRead.Should().BeTrue();
            methodPropertyInfo.CanWrite.Should().BeFalse();
            methodPropertyInfo.PropertyType.Should().Be(typeof(HttpMethod));
        }
    }
}
