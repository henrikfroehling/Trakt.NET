﻿namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
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
    public partial class SyncSeasonsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:39.000Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2022-10-06T17:42:50.000Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncSeasonsLastActivities>> seasonsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await seasonsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var seasonsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                seasonsLastActivities.Should().BeNull();
            }
        }
    }
}
