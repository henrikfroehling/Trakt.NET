namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Interfaces;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktShowSingleTranslationRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestIsNotAbstract()
        {
            typeof(TraktShowSingleTranslationRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestIsSealed()
        {
            typeof(TraktShowSingleTranslationRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestIsSubclassOfATraktSingleItemGetByIdRequest()
        {
            typeof(TraktShowSingleTranslationRequest).IsSubclassOf(typeof(ATraktSingleItemGetByIdRequest<TraktShowTranslation>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestHasAuthorizationNotRequired()
        {
            var request = new TraktShowSingleTranslationRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.NotRequired);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestHasValidUriTemplate()
        {
            var request = new TraktShowSingleTranslationRequest(null);
            request.UriTemplate.Should().Be("shows/{id}/translations/{language}");
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestImplementsITraktObjectRequestInterface()
        {
            typeof(TraktShowSingleTranslationRequest).GetInterfaces().Should().Contain(typeof(ITraktObjectRequest));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestHasLanguageCodeProperty()
        {
            var sortingPropertyInfo = typeof(TraktShowSingleTranslationRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "LanguageCode")
                    .FirstOrDefault();

            sortingPropertyInfo.CanRead.Should().BeTrue();
            sortingPropertyInfo.CanWrite.Should().BeTrue();
            sortingPropertyInfo.PropertyType.Should().Be(typeof(string));
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestHasGetUriPathParametersMethod()
        {
            var methodInfo = typeof(TraktShowSingleTranslationRequest).GetMethods()
                                                                      .Where(m => m.Name == "GetUriPathParameters")
                                                                      .FirstOrDefault();

            methodInfo.ReturnType.Should().Be(typeof(IDictionary<string, object>));
            methodInfo.GetParameters().Should().BeEmpty();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestUriParamsWithLanguageCode()
        {
            var languageCode = "de";

            var request = new TraktShowSingleTranslationRequest(null)
            {
                LanguageCode = languageCode
            };

            var uriParams = request.GetUriPathParameters();

            uriParams.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(1);
            uriParams.Should().Contain("language", languageCode);
        }
    }
}
