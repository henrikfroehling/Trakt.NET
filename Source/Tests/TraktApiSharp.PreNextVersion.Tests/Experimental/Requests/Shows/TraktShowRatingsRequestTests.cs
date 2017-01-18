namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Basic;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRatingsRequestIsNotAbstract()
        {
            typeof(TraktShowRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRatingsRequestIsSealed()
        {
            typeof(TraktShowRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktShowRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRatingsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowRatingsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowRatingsRequestHasValidUriTemplate()
        {
            var request = new TraktShowRatingsRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/ratings");
        }
    }
}
