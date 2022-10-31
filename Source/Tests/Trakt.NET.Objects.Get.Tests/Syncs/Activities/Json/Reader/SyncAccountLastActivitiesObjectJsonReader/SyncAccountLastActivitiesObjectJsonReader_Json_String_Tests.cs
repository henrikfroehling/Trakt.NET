namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncAccountLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            var accountLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid()
        {
            var jsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            var accountLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().BeNull();
            accountLastActivities.FollowedAt.Should().BeNull();
            accountLastActivities.FollowingAt.Should().BeNull();
            accountLastActivities.PendingAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncAccountLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncAccountLastActivities>> accountLastActivities = () => jsonReader.ReadObjectAsync(default(string));
            await accountLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            var accountLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            accountLastActivities.Should().BeNull();
        }
    }
}
