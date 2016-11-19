namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

    [TestClass]
    public class TraktShowSingleTranslationRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Shows")]
        public void TestTraktShowSingleTranslationRequestIsNotAbstract()
        {
            typeof(TraktShowSingleTranslationRequest).IsAbstract.Should().BeFalse();
        }
    }
}
