namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Base.Delete;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;

    [TestClass]
    public class TraktSyncPlaybackDeleteRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackDeleteRequestIsNotAbstract()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackDeleteRequestIsSealed()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackDeleteRequestIsSubclassOfATraktNoContentDeleteByIdRequest()
        {
            typeof(TraktSyncPlaybackDeleteRequest).IsSubclassOf(typeof(ATraktNoContentDeleteByIdRequest)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackDeleteRequestHasValidUriTemplate()
        {
            var request = new TraktSyncPlaybackDeleteRequest(null);
            request.UriTemplate.Should().Be("sync/playback/{id}");
        }
    }
}
