namespace TraktApiSharp.Tests.Experimental.Requests.Interfaces
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Linq;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Requests;

    [TestClass]
    public class ITraktRequestAuthorizationTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestAuthorizationIsInterface()
        {
            typeof(ITraktRequestAuthorization).IsInterface.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Interfaces")]
        public void TestITraktRequestAuthorizationHasAuthorizationRequirementProperty()
        {
            var authorizationRequirementPropertyInfo = typeof(ITraktRequestAuthorization).GetProperties()
                                                                                         .Where(p => p.Name == "AuthorizationRequirement")
                                                                                         .FirstOrDefault();

            authorizationRequirementPropertyInfo.CanRead.Should().BeTrue();
            authorizationRequirementPropertyInfo.CanWrite.Should().BeFalse();
            authorizationRequirementPropertyInfo.PropertyType.Should().Be(typeof(TraktAuthorizationRequirement));
        }
    }
}
