namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncListsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
            listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            listsLastActivities.Should().NotBeNull();
            listsLastActivities.LikedAt.Should().BeNull();
            listsLastActivities.UpdatedAt.Should().BeNull();
            listsLastActivities.CommentedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(default(string));
            listsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(string.Empty);
            listsLastActivities.Should().BeNull();
        }
    }
}
