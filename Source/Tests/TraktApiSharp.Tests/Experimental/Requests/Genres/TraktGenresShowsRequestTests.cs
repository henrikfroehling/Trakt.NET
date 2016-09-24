namespace TraktApiSharp.Tests.Experimental.Requests.Genres
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Genres;

    [TestClass]
    public class TraktGenresShowsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestIsNotAbstract()
        {
            typeof(TraktGenresShowsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Genres"), TestCategory("Shows")]
        public void TestTraktGenresShowsRequestIsSealed()
        {
            typeof(TraktGenresShowsRequest).IsSealed.Should().BeTrue();
        }
    }
}
