namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class TraktMovieTranslationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieTranslationsRequestIsNotAbstract()
        {
            typeof(TraktMovieTranslationsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
