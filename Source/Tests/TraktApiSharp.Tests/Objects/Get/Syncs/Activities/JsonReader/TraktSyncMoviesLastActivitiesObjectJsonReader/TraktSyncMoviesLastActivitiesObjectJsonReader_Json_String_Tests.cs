namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncMoviesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_9()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_9);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_10()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_10);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_11()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_11);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_12()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_12);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_13()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_13);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_14()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_14);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_6()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_6);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_7()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_7);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            moviesLastActivities.CollectedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            moviesLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.310Z").ToUniversalTime());
            moviesLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.321Z").ToUniversalTime());
            moviesLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            moviesLastActivities.PausedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.250Z").ToUniversalTime());
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_8()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_8);

            moviesLastActivities.Should().NotBeNull();
            moviesLastActivities.WatchedAt.Should().BeNull();
            moviesLastActivities.CollectedAt.Should().BeNull();
            moviesLastActivities.RatedAt.Should().BeNull();
            moviesLastActivities.WatchlistedAt.Should().BeNull();
            moviesLastActivities.CommentedAt.Should().BeNull();
            moviesLastActivities.PausedAt.Should().BeNull();
            moviesLastActivities.HiddenAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(default(string));
            moviesLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncMoviesLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new TraktSyncMoviesLastActivitiesObjectJsonReader();

            var moviesLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            moviesLastActivities.Should().BeNull();
        }
    }
}
