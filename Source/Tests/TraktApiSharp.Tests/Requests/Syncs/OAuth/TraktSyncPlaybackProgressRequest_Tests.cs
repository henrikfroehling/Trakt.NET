namespace TraktApiSharp.Tests.Requests.Syncs.OAuth
{
    using FluentAssertions;
    using System.Collections.Generic;
    using System.Linq;
    using System.Reflection;
    using Traits;
    using TraktApiSharp.Enums;
    using TraktApiSharp.Objects.Get.Syncs.Playback;
    using TraktApiSharp.Objects.Get.Syncs.Playback.Implementations;
    using TraktApiSharp.Requests.Syncs.OAuth;
    using Xunit;

    [Category("Requests.Syncs.OAuth")]
    public class TraktSyncPlaybackProgressRequest_Tests
    {
        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Is_Not_Abstract()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsAbstract.Should().BeFalse();
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Is_Sealed()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSealed.Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Inherits_ATraktSyncGetRequest_1()
        {
            typeof(TraktSyncPlaybackProgressRequest).IsSubclassOf(typeof(ATraktSyncGetRequest<TraktSyncPlaybackProgressItem>)).Should().BeTrue();
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Has_Valid_UriTemplate()
        {
            var request = new TraktSyncPlaybackProgressRequest();
            request.UriTemplate.Should().Be("sync/playback{/type}{?limit}");
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Has_Type_Property()
        {
            var propertyInfo = typeof(TraktSyncPlaybackProgressRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Type")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(TraktSyncType));
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Has_Limit_Property()
        {
            var propertyInfo = typeof(TraktSyncPlaybackProgressRequest)
                    .GetProperties(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance)
                    .Where(p => p.Name == "Limit")
                    .FirstOrDefault();

            propertyInfo.CanRead.Should().BeTrue();
            propertyInfo.CanWrite.Should().BeTrue();
            propertyInfo.PropertyType.Should().Be(typeof(int?));
        }

        [Fact]
        public void Test_TraktSyncPlaybackProgressRequest_Returns_Valid_UriPathParameters()
        {
            // without any properties
            var request = new TraktSyncPlaybackProgressRequest();

            request.GetUriPathParameters().Should().NotBeNull().And.BeEmpty();

            // with sync type
            var type = TraktSyncType.Episode;
            request = new TraktSyncPlaybackProgressRequest { Type = type };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["type"] = type.UriName
                                                   });

            // with limit
            var limit = 10;
            request = new TraktSyncPlaybackProgressRequest { Limit = limit };

            request.GetUriPathParameters().Should().NotBeNull()
                                                   .And.HaveCount(1)
                                                   .And.Contain(new Dictionary<string, object>
                                                   {
                                                       ["limit"] = limit.ToString()
                                                   });

            // with sync type and limit
            request = new TraktSyncPlaybackProgressRequest { Type = type, Limit = limit };

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
