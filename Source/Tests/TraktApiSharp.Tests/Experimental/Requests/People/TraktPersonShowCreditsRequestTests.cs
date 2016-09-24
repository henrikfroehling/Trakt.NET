namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;
    using TraktApiSharp.Objects.Get.People.Credits;

    [TestClass]
    public class TraktPersonShowCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Show")]
        public void TestTraktPersonShowCreditsRequestIsNotAbstract()
        {
            typeof(TraktPersonShowCreditsRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Show")]
        public void TestTraktPersonShowCreditsRequestIsSealed()
        {
            typeof(TraktPersonShowCreditsRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Show")]
        public void TestTraktPersonShowCreditsRequestIsSubclassOfATraktPersonCreditsRequest()
        {
            typeof(TraktPersonShowCreditsRequest).IsSubclassOf(typeof(ATraktPersonCreditsRequest<TraktPersonShowCredits>)).Should().BeTrue();
        }
    }
}
