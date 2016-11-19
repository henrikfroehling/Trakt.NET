namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Get;
    using TraktApiSharp.Experimental.Requests.Shows;
    using TraktApiSharp.Objects.Get.Shows;

    [TestClass]
    public class TraktShowTranslationsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowTranslationsRequestIsNotAbstract()
        {
            typeof(TraktShowTranslationsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowTranslationsRequestIsSealed()
        {
            typeof(TraktShowTranslationsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowTranslationsRequestIsSubclassOfATraktListGetByIdRequest()
        {
            typeof(TraktShowTranslationsRequest).IsSubclassOf(typeof(ATraktListGetByIdRequest<TraktShowTranslation>)).Should().BeTrue();
        }
    }
}
