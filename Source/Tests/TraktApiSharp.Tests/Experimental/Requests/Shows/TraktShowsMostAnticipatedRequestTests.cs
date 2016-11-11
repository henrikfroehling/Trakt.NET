namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows.Common;

    [TestClass]
    public class TraktShowsMostAnticipatedRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsNotAbstract()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsSealed()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows"), TestCategory("Lists")]
        public void TestTraktShowsMostAnticipatedRequestIsSubclassOfATraktMoviesRequest()
        {
            typeof(TraktShowsMostAnticipatedRequest).IsSubclassOf(typeof(ATraktMoviesRequest<TraktMostAnticipatedShow>)).Should().BeTrue();
        }
    }
}
