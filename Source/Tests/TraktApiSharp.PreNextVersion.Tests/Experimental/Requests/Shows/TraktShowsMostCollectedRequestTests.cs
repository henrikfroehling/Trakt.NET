namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowsMostCollectedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostCollectedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestIsSealed()
        {
            typeof(TraktShowsMostCollectedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestIsSubclassOfATraktShowsMostPWCRequest()
        {
            typeof(TraktShowsMostCollectedRequest).IsSubclassOf(typeof(ATraktShowsMostPWCRequest<TraktMostCollectedShow>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowsMostCollectedRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestHasValidUriTemplate()
        {
            var request = new TraktShowsMostCollectedRequest(null);
            request.UriTemplate.Should().Be("shows/collected{/period}{?extended,page,limit,query,years,genres,languages,countries,runtimes,ratings,certifications,networks,status}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestUriParamsWithoutPeriod()
        {
            var request = new TraktShowsMostCollectedRequest(null);
            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestUriParamsWithUnspecifiedPeriod()
        {
            var period = TraktTimePeriod.Unspecified;

            var request = new TraktShowsMostCollectedRequest(null)
            {
                Period = period
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostCollectedRequestUriParamsWithPeriod()
        {
            var period = TraktTimePeriod.Monthly;

            var request = new TraktShowsMostCollectedRequest(null)
            {
                Period = period
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("period", period.UriName);
        }
    }
}
