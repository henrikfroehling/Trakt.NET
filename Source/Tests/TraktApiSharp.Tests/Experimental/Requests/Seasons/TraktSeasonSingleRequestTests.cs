namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Episodes;

    [TestClass]
    public class TraktSeasonSingleRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsNotAbstract()
        {
            typeof(TraktSeasonSingleRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSealed()
        {
            typeof(TraktSeasonSingleRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Seasons")]
        public void TestTraktSeasonSingleRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktSeasonSingleRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktEpisode>)).Should().BeTrue();
        }
    }
}
