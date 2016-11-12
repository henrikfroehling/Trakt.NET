namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowsMostPlayedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostPlayedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsSealed()
        {
            typeof(TraktShowsMostPlayedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestIsSubclassOfATraktShowsMostPWCRequest()
        {
            typeof(TraktShowsMostPlayedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostPlayedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowsMostPlayedRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostPlayedRequestHasValidUriTemplate()
        {
            var request = new TraktShowsMostPlayedRequest(null);
            request.UriTemplate.Should().Be("shows/played{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }
    }
}
