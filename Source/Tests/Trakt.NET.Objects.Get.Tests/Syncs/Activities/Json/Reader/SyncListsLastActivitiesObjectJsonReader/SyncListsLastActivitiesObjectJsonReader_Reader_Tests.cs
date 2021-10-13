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
    public partial class SyncListsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();
            Func<Task<ITraktSyncListsLastActivities>> listsLastActivities = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            await listsLastActivities.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var listsLastActivities = await traktJsonReader.ReadObjectAsync(jsonReader);
                listsLastActivities.Should().BeNull();
            }
        }
    }
}
