namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncShowsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            showsLastActivities.Should().NotBeNull();
            showsLastActivities.RatedAt.Should().BeNull();
            showsLastActivities.WatchlistedAt.Should().BeNull();
            showsLastActivities.CommentedAt.Should().BeNull();
            showsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(default(string));
            showsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            showsLastActivities.Should().BeNull();
        }
    }
}
