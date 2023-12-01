namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Implementations
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [TestCategory("Objects.Get.Syncs.Activities.Implementations")]
    public class TraktSyncNotesLastActivities_Tests
    {
        [Fact]
        public void Test_TraktSyncNotesLastActivities_Default_Constructor()
        {
            var notesLastActivities = new TraktSyncNotesLastActivities();
            notesLastActivities.UpdatedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncNotesLastActivities_From_Json()
        {
            var jsonReader = new SyncNotesLastActivitiesObjectJsonReader();
            var notesLastActivities = await jsonReader.ReadObjectAsync(JSON) as TraktSyncNotesLastActivities;

            notesLastActivities.Should().NotBeNull();
            notesLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        private const string JSON =
            @"{
                ""updated_at"": ""2015-02-18T12:54:39.000Z""
              }";
    }
}
