namespace TraktApiSharp.Tests.Experimental.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using TraktApiSharp.Experimental.Requests.Syncs.OAuth;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Requests;

    [TestClass]
    public class TraktSyncPlaybackProgressRequestTests
    {
        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsNotAbstract()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsAbstract.Should().BeFalse();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsSealed()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSealed.Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestIsSubclassOfATraktSyncListRequest()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSubclassOf(typeof(ATraktSyncListRequest<TraktSyncPlaybackProgressItem>)).Should().BeTrue();
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasAuthorizationRequired()
        {
            var request = new TraktSyncPlaybackProgressRequest(null);
            request.AuthorizationRequirement.Should().Be(TraktAuthorizationRequirement.Required);
        }

        [TestMethod, TestCategory("Requests"), TestCategory("Syncs")]
        public void TestTraktSyncPlaybackProgressRequestHasValidUriTemplate()
        {
            var request = new TraktSyncPlaybackProgressRequest(null);
            request.UriTemplate.Should().Be("sync/playback{/type}{?limit}");
        }
    }
}
