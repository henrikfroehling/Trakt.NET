namespace TraktApiSharp.Tests.Experimental.Requests.People
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.People;

    [TestClass]
    public class TraktPersonMovieCreditsRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("People"), TestCategory("Credits"), TestCategory("Movie")]
        public void TestTraktPersonMovieCreditsRequestIsNotAbstract()
        {
            typeof(TraktPersonMovieCreditsRequest).IsAbstract.Should().BeFalse();
        }
    }
}
