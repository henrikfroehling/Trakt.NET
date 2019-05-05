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
    public partial class SyncEpisodesLastActivitiesObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_7()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_8()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_9()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_9.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_10()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_10.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_11()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_11.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Incomplete_12()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_12.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_5()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_6()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_6.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Not_Valid_7()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = JSON_NOT_VALID_7.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);

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
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            var episodesLastActivities = await jsonReader.ReadObjectAsync(default(Stream));
            episodesLastActivities.Should().BeNull();
        }

        [Fact]
        public async Task Test_SyncEpisodesLastActivitiesObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new SyncEpisodesLastActivitiesObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var episodesLastActivities = await jsonReader.ReadObjectAsync(stream);
                episodesLastActivities.Should().BeNull();
            }
        }
    }
}
