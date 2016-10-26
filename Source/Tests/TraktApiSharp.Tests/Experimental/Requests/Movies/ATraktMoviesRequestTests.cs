namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;

    [TestClass]
    public class ATraktMoviesRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesRequestIsAbstract()
        {
            typeof(ATraktMoviesRequest<>).IsAbstract.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesRequestHasGenericTypeParameter()
        {
            typeof(ATraktMoviesRequest<>).ContainsGenericParameters.Should().BeTrue();
            typeof(ATraktMoviesRequest<int>).GenericTypeArguments.Should().NotBeEmpty().And.HaveCount(1);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesRequestIsSubclassOfATraktPaginationGetRequest()
        {
            typeof(ATraktMoviesRequest<int>).IsSubclassOf(typeof(ATraktPaginationGetRequest<int>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies"), TestCategory("Lists")]
        public void TestATraktMoviesRequestImplementsITraktExtendedInfoInterface()
        {
            typeof(ATraktMoviesRequest<>).GetInterfaces().Should().Contain(typeof(ITraktExtendedInfo));
        }
    }
}
