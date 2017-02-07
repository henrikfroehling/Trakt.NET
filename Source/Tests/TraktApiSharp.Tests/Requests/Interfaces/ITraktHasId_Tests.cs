namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktHasId_Tests
    {
        [Fact]
        public void Test_ITraktHasId_Is_Interface()
        {
            typeof(ITraktHasId).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHasId_Inherits_ITraktObjectRequest_Interface()
        {
            typeof(ITraktHasId).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [Fact]
        public void Test_ITraktHasId_Has_Id_Property()
        {
            var propertyInfo = typeof(ITraktHasId).GetProperties()
                                                  .Where(p => p.Name == "Id")
                                                  .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
