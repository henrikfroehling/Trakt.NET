namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Requests.Base;
    using TraktApiSharp.Requests.Interfaces.Base;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class IHasRequestAuthorization_Tests
    {
        [Fact]
        public void Test_IHasRequestAuthorization_Is_Interface()
        {
            typeof(IHasRequestAuthorization).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_IHasRequestAuthorization_Has_AuthorizationRequirement_Property()
        {
            var propertyInfo = typeof(IHasRequestAuthorization).GetProperties()
                                                                    .Where(p => p.Name == "AuthorizationRequirement")
                                                                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeFalse();
            propertyInfo.PropertyType.Should().Be(typeof(AuthorizationRequirement));
        }
    }
}
