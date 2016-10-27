namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieSummaryRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestIsNotAbstract()
        {
            typeof(TraktMovieSummaryRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestIsSealed()
        {
            typeof(TraktMovieSummaryRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktMovieSummaryRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktMovie>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieSummaryRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestHasValidUriTemplate()
        {
            var request = new TraktMovieSummaryRequest(null);
            request.UriTemplate.Should().Be("movies/{id}{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktMovieSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSummaryRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktMovieSummaryRequest).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
