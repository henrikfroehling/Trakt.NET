namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktMovieSingleTranslationRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktMovieTranslation>)).Should().BeTrue();
        }
    }
}
