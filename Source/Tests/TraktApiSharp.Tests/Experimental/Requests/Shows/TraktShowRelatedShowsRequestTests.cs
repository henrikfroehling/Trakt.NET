namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowRelatedShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestIsNotAbstract()
        {
            typeof(TraktShowRelatedShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestIsSealed()
        {
            typeof(TraktShowRelatedShowsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestIsSubclassOfATraktPaginationGetByIdRequest()
        {
            typeof(TraktShowRelatedShowsRequest).IsSubclassOf(typeof(ATraktPaginationGetByIdRequest<TraktShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowRelatedShowsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestHasValidUriTemplate()
        {
            var request = new TraktShowRelatedShowsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/related{?extended,page,limit}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktShowRelatedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRelatedShowsRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktShowRelatedShowsRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
