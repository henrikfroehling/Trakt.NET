﻿namespace TraktNet.Requests.Tests.Syncs.OAuth
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Enums;
    using TraktNet.Extensions;
    using TraktNet.Requests.Syncs.OAuth;
    using Xunit;

    [TestCategory("Requests.Syncs.OAuth")]
    public class SyncPlaybackProgressRequest_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncPlaybackProgressRequest();
            request.UriTemplate.Should().Be("sync/playback{/type}{?start_at,end_at,page,limit}");
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

            // with start at date and time
            var startAt = DateTime.UtcNow;
            request = new SyncPlaybackProgressRequest { StartAt = startAt };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["start_at"] = startAt.ToTraktLongDateTimeString()
                                                   });

            // with end at date and time
            var endAt = DateTime.UtcNow;
            request = new SyncPlaybackProgressRequest { EndAt = endAt };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["end_at"] = endAt.ToTraktLongDateTimeString()
                                                   });

            // with page
            uint page = 5;
            request = new SyncPlaybackProgressRequest { Page = page };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["page"] = page.ToString()
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

            // with sync type and page
            request = new SyncPlaybackProgressRequest { Type = type, Page = page };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(2)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["type"] = type.UriName,
                                                       ["page"] = page.ToString()
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

            // with sync type and page and limit
            request = new SyncPlaybackProgressRequest { Type = type, Page = page, Limit = limit };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(3)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["type"] = type.UriName,
                                                       ["page"] = page.ToString(),
                                                       ["limit"] = limit.ToString()
                                                   });
        }
    }
}
