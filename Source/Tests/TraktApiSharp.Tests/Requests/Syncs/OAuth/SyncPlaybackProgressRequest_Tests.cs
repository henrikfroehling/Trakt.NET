namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class SyncPlaybackProgressRequest_Tests
    {
        [Fact]
        public void Test_SyncPlaybackProgressRequest_Is_Not_Abstract()
        {
            typeof(SyncPlaybackProgressRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Is_Sealed()
        {
            typeof(SyncPlaybackProgressRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Inherits_ASyncGetRequest_1()
        {
            typeof(SyncPlaybackProgressRequest).IsSubclassOf(typeof(ASyncGetRequest<ITraktSyncPlaybackProgressItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new SyncPlaybackProgressRequest();
            request.UriTemplate.Should().Be("sync/playback{/type}{?limit}");
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(SyncPlaybackProgressRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncType));
        }

        [Fact]
        public void Test_SyncPlaybackProgressRequest_Has_Limit_Property()
        {
            var propertyInfo = typeof(SyncPlaybackProgressRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Limit")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(uint?));
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
