namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users;

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
    }
}
