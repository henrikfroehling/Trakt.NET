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
    public partial class SyncEpisodesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_9()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_9))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_10()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_10))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_11()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_11))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_12()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_12))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_6()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                episodesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                episodesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
                episodesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
                episodesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_7()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                episodesLastActivities.Should().NotBeNull();
                episodesLastActivities.WatchedAt.Should().BeNull();
                episodesLastActivities.CollectedAt.Should().BeNull();
                episodesLastActivities.RatedAt.Should().BeNull();
                episodesLastActivities.WatchlistedAt.Should().BeNull();
                episodesLastActivities.CommentedAt.Should().BeNull();
                episodesLastActivities.PausedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncEpisodesLastActivities>> episodesLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await episodesLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var episodesLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                episodesLastActivities.Should().BeNull();
            }
        }
    }
}
