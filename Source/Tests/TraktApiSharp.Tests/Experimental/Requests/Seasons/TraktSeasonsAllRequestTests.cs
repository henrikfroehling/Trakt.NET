namespace TraktApiSharp.Tests.Experimental.Requests.Seasons
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Seasons;
    using TraktApiSharp.Objects.Get.Shows.Seasons;

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
    }
}
