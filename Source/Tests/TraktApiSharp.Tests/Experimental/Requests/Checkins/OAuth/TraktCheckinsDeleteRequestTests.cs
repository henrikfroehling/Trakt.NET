namespace TraktApiSharp.Tests.Experimental.Requests.Checkins.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Checkins.OAuth;

    [TestClass]
    public class TraktCheckinsDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinsDeleteRequestIsNotAbstract()
        {
            typeof(TraktCheckinsDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinsDeleteRequestIsSealed()
        {
            typeof(TraktCheckinsDeleteRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinsDeleteRequestIsSubclassOfATraktNoContentDeleteRequest()
        {
            typeof(TraktCheckinsDeleteRequest).IsSubclassOf(typeof(ATraktNoContentDeleteRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Checkins"), TestCategory("With OAuth")]
        public void TestTraktCheckinsDeleteRequestHasValidUriTemplate()
        {
            var request = new TraktCheckinsDeleteRequest(null);
            request.UriTemplate.Should().Be("checkin");
        }
    }
}
