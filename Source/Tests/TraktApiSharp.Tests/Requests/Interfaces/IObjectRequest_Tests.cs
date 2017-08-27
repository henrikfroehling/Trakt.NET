namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class IObjectRequest_Tests
    {
        [Fact]
        public void Test_IObjectRequest_Is_Interface()
        {
            typeof(IObjectRequest).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IObjectRequest_Has_RequestObjectType_Property()
        {
            var propertyInfo = typeof(IObjectRequest).GetProperties()
                                                          .Where(p => p.Name == "RequestObjectType")
                                                          .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(RequestObjectType));
        }
    }
}
