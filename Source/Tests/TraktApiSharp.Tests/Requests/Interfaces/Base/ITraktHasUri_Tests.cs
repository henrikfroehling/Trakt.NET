namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHasUri_Tests
    {
        [Fact]
        public void Test_ITraktHasUri_IsInterface()
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
            var uriTemplatePropertyInfo = typeof(ITraktHasUri).GetProperties()
                                                              .Where(p => p.Name == "UriTemplate")
                                                              .FirstOrDefault();

            uriTemplatePropertyInfo.CanRead.Should().BeTrue();
            uriTemplatePropertyInfo.CanWrite.Should().BeFalse();
            uriTemplatePropertyInfo.PropertyType.Should().Be(typeof(string));
        }
    }
}
