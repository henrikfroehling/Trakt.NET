namespace TraktApiSharp.Tests.Experimental.Requests.Movies
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Movies;
    using TraktApiSharp.Objects.Get.Movies;
    using TraktApiSharp.Requests;

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

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestHasAuthorizationNotRequired()
        {
            var request = new TraktMovieSingleTranslationRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestHasValidUriTemplate()
        {
            var request = new TraktMovieSingleTranslationRequest(null);
            request.UriTemplate.Should().Be("movies/{id}/translations/{language}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktMovieSingleTranslationRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestHasLanguageCodeProperty()
        {
            var sortingPropertyInfo = typeof(TraktMovieSingleTranslationRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LanguageCode")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Movies")]
        public void TestTraktMovieSingleTranslationRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktMovieSingleTranslationRequest).GetMethods()
                                                                       .Where(m => m.Name == "GetUriPathParameters")
                                                                       .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }
    }
}
