namespace TraktApiSharp.Tests.Objects.Get.Syncs.Activities.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Syncs.Activities.JsonReader;
    using Xunit;

    [Category("Objects.Get.Syncs.Activities.JsonReader")]
    public partial class TraktSyncShowsLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.305Z").ToUniversalTime());
                showsLastActivities.WatchlistedAt.Should().Be(DateTime.Parse("2014-11-19T22:02:41.308Z").ToUniversalTime());
                showsLastActivities.CommentedAt.Should().Be(DateTime.Parse("2014-11-20T06:51:30.325Z").ToUniversalTime());
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);

                showsLastActivities.Should().NotBeNull();
                showsLastActivities.RatedAt.Should().BeNull();
                showsLastActivities.WatchlistedAt.Should().BeNull();
                showsLastActivities.CommentedAt.Should().BeNull();
                showsLastActivities.HiddenAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            var showsLastActivities = await jsonReader.ReadObjectAsync(default(Stream));
            showsLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_TraktSyncShowsLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new TraktSyncShowsLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var showsLastActivities = await jsonReader.ReadObjectAsync(stream);
                showsLastActivities.Should().BeNull();
            }
        }
    }
}
