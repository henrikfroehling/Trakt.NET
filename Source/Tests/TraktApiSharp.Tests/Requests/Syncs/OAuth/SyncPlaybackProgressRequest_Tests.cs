namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncPlaybackProgressRequest_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncPlaybackProgressRequest();
            request.UriTemplate.Should().Be("sync/playback{/type}{?limit}");
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Returns_Valid_UriPathParameters()
        {
            // without any properties
            var request = new SyncPlaybackProgressRequest();

            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with sync type
            var type = TraktSyncType.Episode;
            request = new SyncPlaybackProgressRequest { Type = type };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["type"] = type.UriName
                                                   });

            // with limit
            uint limit = 10;
            request = new SyncPlaybackProgressRequest { Limit = limit };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["limit"] = limit.ToString()
                                                   });

            // with sync type and limit
            request = new SyncPlaybackProgressRequest { Type = type, Limit = limit };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["type"] = type.UriName,
                                                       ["limit"] = limit.ToString()
                                                   });
        }
    }
}
