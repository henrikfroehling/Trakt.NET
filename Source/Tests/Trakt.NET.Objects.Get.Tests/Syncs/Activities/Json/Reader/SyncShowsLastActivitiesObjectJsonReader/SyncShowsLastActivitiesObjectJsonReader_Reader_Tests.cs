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

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncShowsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncShowsLastActivities>> showsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            showsLastActivities.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncShowsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncShowsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var showsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                showsLastActivities.Should().BeNull();
            }
        }
    }
}
