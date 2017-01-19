namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Seasons;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSeasonsAllRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestIsNotAbstract()
        {
            typeof(TraktSeasonsAllRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestIsSealed()
        {
            typeof(TraktSeasonsAllRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonsAllRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktSeason>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestHasAuthorizationNotRequired()
        {
            var request = new TraktSeasonsAllRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestHasValidUriTemplate()
        {
            var request = new TraktSeasonsAllRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/seasons{?extended}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonsAllRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(TraktSeasonsAllRequest).GetInterfaces().Should().Contain(typeof(ITraktSupportsExtendedInfo));
        }
    }
}
