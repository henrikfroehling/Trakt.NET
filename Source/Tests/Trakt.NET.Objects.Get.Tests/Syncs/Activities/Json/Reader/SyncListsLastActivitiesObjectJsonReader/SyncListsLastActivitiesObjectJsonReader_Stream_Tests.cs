namespace TraktNet.Objects.Get.Tests.Syncs.Activities.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Syncs.Activities.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class SyncListsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();
            
            using (var stream = JSON_COMPLETE.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                listsLastActivities.UpdatedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);

                listsLastActivities.Should().NotBeNull();
                listsLastActivities.LikedAt.Should().BeNull();
                listsLastActivities.UpdatedAt.Should().BeNull();
                listsLastActivities.CommentedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            var listsLastActivities = await jsonReader.ReadObjectAsync(default(Stream));
            listsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncListsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SyncListsLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var listsLastActivities = await jsonReader.ReadObjectAsync(stream);
                listsLastActivities.Should().BeNull();
            }
        }
    }
}
