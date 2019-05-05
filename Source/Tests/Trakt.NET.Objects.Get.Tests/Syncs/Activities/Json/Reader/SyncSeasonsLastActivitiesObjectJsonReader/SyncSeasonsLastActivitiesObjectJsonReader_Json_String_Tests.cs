namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncSeasonsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            seasonsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            seasonsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            seasonsLastActivities.Should().NotBeNull();
            seasonsLastActivities.RatedAt.Should().BeNull();
            seasonsLastActivities.WatchlistedAt.Should().BeNull();
            seasonsLastActivities.CommentedAt.Should().BeNull();
            seasonsLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(default(string));
            seasonsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncSeasonsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncSeasonsLastActivitiesObjectJsonReader();

            var seasonsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            seasonsLastActivities.Should().BeNull();
        }
    }
}
