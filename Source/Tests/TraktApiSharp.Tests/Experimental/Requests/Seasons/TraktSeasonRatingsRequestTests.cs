namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Basic;

    [TestClass]
    public class TraktSeasonRatingsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsNotAbstract()
        {
            typeof(TraktSeasonRatingsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsSealed()
        {
            typeof(TraktSeasonRatingsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonRatingsRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktSeasonRatingsRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktRating>)).Should().BeTrue();
        }
    }
}
