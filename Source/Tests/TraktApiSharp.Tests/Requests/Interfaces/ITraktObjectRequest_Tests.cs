namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktObjectRequest_Tests
    {
        [Fact]
        public void Test_ITraktObjectRequest_IsInterface()
        {
            typeof(ITraktObjectRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktObjectRequest_Has_RequestObjectType_Property()
        {
            var requestObjectTypePropertyInfo = typeof(ITraktObjectRequest).GetProperties()
                                                                           .Where(p => p.Name == "RequestObjectType")
                                                                           .FirstOrDefault();

            requestObjectTypePropertyInfo.CanRead.Should().BeTrue();
            requestObjectTypePropertyInfo.CanWrite.Should().BeFalse();
            requestObjectTypePropertyInfo.PropertyType.Should().Be(typeof(TraktRequestObjectType));
        }
    }
}
