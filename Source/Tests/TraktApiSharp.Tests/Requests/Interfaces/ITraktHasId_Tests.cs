namespace TraktApiSharp.Tests.Requests.Interfaces
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces")]
    public class ITraktHasId_Tests
    {
        [Fact]
        public void Test_ITraktHasId_IsInterface()
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
            var idPropertyInfo = typeof(ITraktHasId).GetProperties()
                                                    .Where(p => p.Name == "Id")
                                                    .FirstOrDefault();

            idPropertyInfo.CanRead.Should().BeTrue();
            idPropertyInfo.CanWrite.Should().BeTrue();
            idPropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
