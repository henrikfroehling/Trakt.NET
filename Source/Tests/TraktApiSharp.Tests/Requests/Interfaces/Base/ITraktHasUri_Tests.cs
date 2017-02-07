namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHasUri_Tests
    {
        [Fact]
        public void Test_ITraktHasUri_Is_Interface()
        {
            typeof(ITraktHasUri).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHasUri_Inherits_ITraktHasUriPathParameters_Interface()
        {
            typeof(ITraktHasUri).GetInterfaces().Should().Contain(typeof(ITraktHasUriPathParameters));
        }

        [Fact]
        public void Test_ITraktHasUri_Has_UriTemplate_Property()
        {
            var propertyInfo = typeof(ITraktHasUri).GetProperties()
                                                   .Where(p => p.Name == "UriTemplate")
                                                   .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
