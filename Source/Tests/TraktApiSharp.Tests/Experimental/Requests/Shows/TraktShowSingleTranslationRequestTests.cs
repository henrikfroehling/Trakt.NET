namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
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
    }
}
