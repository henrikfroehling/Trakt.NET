namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktObjectRequest_Tests
    {
        [Fact]
        public void Test_ITraktObjectRequest_Is_Interface()
        {
            typeof(ITraktObjectRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktObjectRequest_Has_RequestObjectType_Property()
        {
            var propertyInfo = typeof(ITraktObjectRequest).GetProperties()
                                                          .Where(p => p.Name == "RequestObjectType")
                                                          .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(TraktRequestObjectType));
        }
    }
}
