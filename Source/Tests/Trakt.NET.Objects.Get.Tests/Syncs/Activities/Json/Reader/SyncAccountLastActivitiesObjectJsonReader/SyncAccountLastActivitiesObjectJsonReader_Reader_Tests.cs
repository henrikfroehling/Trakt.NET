namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncAccountLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                accountLastActivities.Should().NotBeNull();
                accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
                accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2014-09-01T09:10:11.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                accountLastActivities.Should().NotBeNull();
                accountLastActivities.SettingsAt.Should().BeNull();
                accountLastActivities.FollowedAt.Should().BeNull();
                accountLastActivities.FollowingAt.Should().BeNull();
                accountLastActivities.PendingAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncAccountLastActivities>> accountLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await accountLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                accountLastActivities.Should().BeNull();
            }
        }
    }
}
