namespace TraktApiSharp.Tests.Objects.Get.Watched.Json
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Json;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().BeNull();
                watchedShowEpisodes[0].LastWatchedAt.Should().BeNull();

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().BeNull();
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().BeNull();

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().BeNull();
                watchedShowEpisodes[2].Plays.Should().BeNull();
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktWatchedShowEpisodes = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadArrayAsync(default(Stream));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new WatchedShowEpisodeArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeWatchedProgress = await jsonReader.ReadArrayAsync(stream);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }
    }
}
