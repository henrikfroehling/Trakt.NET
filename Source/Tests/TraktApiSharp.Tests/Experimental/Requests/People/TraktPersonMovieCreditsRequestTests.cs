namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;
    using TraktApiSharp.Objects.Get.People.Credits;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktPersonMovieCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestIsNotAbstract()
        {
            typeof(TraktPersonMovieCreditsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestIsSealed()
        {
            typeof(TraktPersonMovieCreditsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestIsSubclassOfATraktPersonCreditsRequest()
        {
            typeof(TraktPersonMovieCreditsRequest).IsSubclassOf(typeof(ATraktPersonCreditsRequest<TraktPersonMovieCredits>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestHasAuthorizationNotRequired()
        {
            var request = new TraktPersonMovieCreditsRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestHasValidUriTemplate()
        {
            var request = new TraktPersonMovieCreditsRequest(null);
            request.UriTemplate.Should().Be("people/{id}/movies{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestHasValidRequestObjectType()
        {
            var request = new TraktPersonMovieCreditsRequest(null);
            request.RequestObjectType.Should().Be(TraktRequestObjectType.People);
        }
    }
}
