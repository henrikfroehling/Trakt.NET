namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IHasUri_Tests
    {
        [Fact]
        public void Test_IHasUri_Is_Interface()
        {
            typeof(IHasUri).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IHasUri_Inherits_IHasUriPathParameters_Interface()
        {
            typeof(IHasUri).GetInterfaces().Should().Contain(typeof(IHasUriPathParameters));
        }

        [Fact]
        public void Test_IHasUri_Has_UriTemplate_Property()
        {
            var propertyInfo = typeof(IHasUri).GetProperties()
                                                   .Where(p => p.Name == "UriTemplate")
                                                   .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
