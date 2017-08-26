namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class IHasId_Tests
    {
        [Fact]
        public void Test_IHasId_Is_Interface()
        {
            typeof(IHasId).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IHasId_Inherits_ITraktObjectRequest_Interface()
        {
            typeof(IHasId).GetInterfaces().Should().Contain(typeof(IObjectRequest));
        }

        [Fact]
        public void Test_IHasId_Has_Id_Property()
        {
            var propertyInfo = typeof(IHasId).GetProperties()
                                                  .Where(p => p.Name == "Id")
                                                  .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
