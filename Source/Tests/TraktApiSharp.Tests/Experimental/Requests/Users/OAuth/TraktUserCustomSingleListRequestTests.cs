namespace TraktApiSharp.Tests.Experimental.Requests.Users.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Users.OAuth;
    using TraktApiSharp.Objects.Get.Users.Lists;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktUserCustomSingleListRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsNotAbstract()
        {
            typeof(TraktUserCustomSingleListRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsSealed()
        {
            typeof(TraktUserCustomSingleListRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktUserCustomSingleListRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktList>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasAuthorizationOptional()
        {
            var request = new TraktUserCustomSingleListRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Optional);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Users")]
        public void TestTraktUserCustomSingleListRequestHasValidUriTemplate()
        {
            var request = new TraktUserCustomSingleListRequest(null);
            request.UriTemplate.Should().Be("users/{username}/lists/{id}");
        }
    }
}
