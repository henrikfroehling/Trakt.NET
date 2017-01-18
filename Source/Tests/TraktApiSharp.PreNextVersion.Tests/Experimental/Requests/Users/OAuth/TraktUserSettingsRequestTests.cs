namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserSettingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserSettingsRequestIsNotAbstract()
        {
            typeof(TraktUserSettingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserSettingsRequestIsSealed()
        {
            typeof(TraktUserSettingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserSettingsRequestIsSubclassOfATraktUsersSingleItemGetRequest()
        {
            typeof(TraktUserSettingsRequest).IsSubclassOf(typeof(ATraktUsersSingleItemGetRequest<TraktUserSettings>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserSettingsRequestHasAuthorizationRequired()
        {
            var request = new TraktUserSettingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserSettingsRequestHasValidUriTemplate()
        {
            var request = new TraktUserSettingsRequest(null);
            request.UriTemplate.Should().Be("users/settings");
        }
    }
}
