namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Requests.Parameters;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncWatchedShowsRequest_Tests
    {
        [Fact]
        public void Test_SyncWatchedShowsRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncWatchedShowsRequest();
            request.UriTemplate.Should().Be("sync/watched/shows{?extended}");
        }

        [Fact]
        public void Test_SyncWatchedShowsRequest_Returns_Valid_UriPathParameters()
        {
            // without extended info
            var request = new SyncWatchedShowsRequest();
            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with extended info
            var extendedInfo = new TraktExtendedInfo { Full = true };
            request = new SyncWatchedShowsRequest { ExtendedInfo = extendedInfo };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["extended"] = extendedInfo.ToString()
                                                   });
        }
    }
}
