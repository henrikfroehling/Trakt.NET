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
    public partial class SyncCollaborationsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncCollaborationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var collaborationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            collaborationsLastActivities.Should().NotBeNull();
            collaborationsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid()
        {
            var traktJsonReader = new SyncCollaborationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID);
            using var jsonReader = new JsonTextReader(reader);
            var collaborationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            collaborationsLastActivities.Should().NotBeNull();
            collaborationsLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncCollaborationsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncCollaborationsLastActivities>> collaborationsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await collaborationsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncCollaborationsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncCollaborationsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var collaborationsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            collaborationsLastActivities.Should().BeNull();
        }
    }
}
