namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncAccountLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                accountLastActivities.Should().NotBeNull();
                accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID.ToStream())
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(stream);

                accountLastActivities.Should().NotBeNull();
                accountLastActivities.SettingsAt.Should().BeNull();
                accountLastActivities.FollowedAt.Should().BeNull();
                accountLastActivities.FollowingAt.Should().BeNull();
                accountLastActivities.PendingAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncAccountLastActivities>> accountLastActivities = () => traktJsonReader.ReadObjectAsync(default(Stream));
            await accountLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(stream);
                accountLastActivities.Should().BeNull();
            }
        }
    }
}
