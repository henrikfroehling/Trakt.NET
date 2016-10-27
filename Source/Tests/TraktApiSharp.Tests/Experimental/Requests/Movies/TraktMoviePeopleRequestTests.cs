namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Basic;

    [TestClass]
    public class TraktMoviePeopleRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMoviePeopleRequestIsNotAbstract()
        {
            typeof(TraktMoviePeopleRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMoviePeopleRequestIsSealed()
        {
            typeof(TraktMoviePeopleRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMoviePeopleRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktMoviePeopleRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktCastAndCrew>)).Should().BeTrue();
        }
    }
}
