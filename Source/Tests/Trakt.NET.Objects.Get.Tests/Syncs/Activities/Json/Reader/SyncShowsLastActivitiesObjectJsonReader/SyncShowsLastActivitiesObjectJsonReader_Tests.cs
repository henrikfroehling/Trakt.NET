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
    public partial class SyncShowsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_COMPLETE);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_1);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_2);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_3);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().BeNull();
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_4);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_5);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_INCOMPLETE_6);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_1);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_2);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_3);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().BeNull();
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_4);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_5);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2022-12-20T19:34:50.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_6);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2022-06-25T23:46:52.000Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2023-06-22T16:39:23.000Z").ToUniversalTime());
            showsLastActivities.FavoritedAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.RecommendationsAt.Should().Be(DateTime.Parse("2021-06-28T00:13:46.000Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2015-02-18T12:54:39.000Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(JSON_NOT_VALID_7);
            using var jsonReader = new JsonTextReader(reader);
            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.FavoritedAt.Should().BeNull();
            showsLastActivities.RecommendationsAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncShowsLastActivities>> showsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await showsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using var reader = new StringReader(string.Empty);
            using var jsonReader = new JsonTextReader(reader);

            var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
            showsLastActivities.Should().BeNull();
        }
    }
}
