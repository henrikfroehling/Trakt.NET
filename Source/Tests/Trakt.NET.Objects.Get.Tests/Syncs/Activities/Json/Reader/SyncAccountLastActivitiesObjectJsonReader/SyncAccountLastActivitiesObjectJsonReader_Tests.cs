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

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().BeNull();
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().BeNull();
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().BeNull();
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().BeNull();
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().BeNull();
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().BeNull();
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().BeNull();
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().BeNull();
            accountLastActivities.RequestedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().Be(DateTime.Parse("2023-06-26T18:08:03.000Z").ToUniversalTime());
            accountLastActivities.FollowedAt.Should().Be(DateTime.Parse("2020-12-14T14:12:28.000Z").ToUniversalTime());
            accountLastActivities.FollowingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.PendingAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            accountLastActivities.RequestedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncAccountLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SyncAccountLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            accountLastActivities.Should().NotBeNull();
            accountLastActivities.SettingsAt.Should().BeNull();
            accountLastActivities.FollowedAt.Should().BeNull();
            accountLastActivities.FollowingAt.Should().BeNull();
            accountLastActivities.PendingAt.Should().BeNull();
            accountLastActivities.RequestedAt.Should().BeNull();
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

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var accountLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            accountLastActivities.Should().BeNull();
        }
    }
}
