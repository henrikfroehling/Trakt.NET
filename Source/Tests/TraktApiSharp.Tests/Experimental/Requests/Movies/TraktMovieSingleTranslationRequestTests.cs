namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMovieSingleTranslationRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestIsNotAbstract()
        {
            typeof(TraktMovieSingleTranslationRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestIsSealed()
        {
            typeof(TraktMovieSingleTranslationRequest).IsSealed.Should().BeTrue();
        }
    }
}
