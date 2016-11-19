namespace TraktApiSharp.Tests.Experimental.Requests.Shows
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Shows;

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
    }
}
