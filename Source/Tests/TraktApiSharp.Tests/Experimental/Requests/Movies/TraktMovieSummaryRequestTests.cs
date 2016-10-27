namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;

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
    }
}
