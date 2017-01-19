namespace TraktApiSharp.Tests.Requests.Interfaces.Base
{
    using FluentAssertions;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces.Base;
    using TraktApiSharp.Requests;
    using TraktApiSharp.Tests.Traits;
    using Xunit;

    [Category("Requests.Interfaces.Base")]
    public class ITraktHasRequestAuthorization_Tests
    {
        [Fact]
        public void Test_ITraktHasRequestAuthorization_Is_Interface()
        {
            typeof(ITraktHasRequestAuthorization).IsInterface.Should().BeTrue();
        }

        [Fact]
        public void Test_ITraktHasRequestAuthorization_Has_AuthorizationRequirement_Property()
        {
            var authorizationRequirementPropertyInfo = typeof(ITraktHasRequestAuthorization).GetProperties()
                                                                                            .Where(p => p.Name == "AuthorizationRequirement")
                                                                                            .FirstOrDefault();

            authorizationRequirementPropertyInfo.CanRead.Should().BeTrue();
            authorizationRequirementPropertyInfo.CanWrite.Should().BeFalse();
            authorizationRequirementPropertyInfo.PropertyType.Should().Be(typeof(TraktAuthorizationRequirement));
        }
    }
}
