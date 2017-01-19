namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktMovieSingleReleaseRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestIsNotAbstract()
        {
            typeof(TraktMovieSingleReleaseRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestIsSealed()
        {
            typeof(TraktMovieSingleReleaseRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            //typeof(TraktMovieSingleReleaseRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktMovieRelease>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieSingleReleaseRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestHasValidUriTemplate()
        {
            var request = new TraktMovieSingleReleaseRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/releases/{language}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestHasLanguageCodeProperty()
        {
            var sortingPropertyInfo = typeof(TraktMovieSingleReleaseRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LanguageCode")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktMovieSingleReleaseRequest).GetMethods()
                                                                   .Where(m => m.Name == "GetUriPathParameters")
                                                                   .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleReleaseRequestUriParamsWithLanguageCode()
        {
            var languageCode = "de";

            var request = new TraktMovieSingleReleaseRequest(null)
            {
                LanguageCode = languageCode
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("language", languageCode);
        }
    }
}
