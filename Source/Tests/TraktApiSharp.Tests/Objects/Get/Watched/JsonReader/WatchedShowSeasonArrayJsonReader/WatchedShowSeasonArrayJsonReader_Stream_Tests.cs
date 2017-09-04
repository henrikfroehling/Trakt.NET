namespace TraktApiSharp.Tests.Objects.Get.Watched.JsonReader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.JsonReader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().Be(1);
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = watchedShowSeasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().BeNull();
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = watchedShowSeasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().Be(1);
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().BeNull();
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodes = watchedShowSeasons[1].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().Be(1);
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(stream);
                traktWatchedShowSeasons.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(2);

                var watchedShowSeasons = traktWatchedShowSeasons.ToArray();

                watchedShowSeasons[0].Should().NotBeNull();
                watchedShowSeasons[0].Number.Should().BeNull();
                watchedShowSeasons[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodes = watchedShowSeasons[0].Episodes.ToArray();

                episodes[0].Should().NotBeNull();
                episodes[0].Number.Should().Be(1);
                episodes[0].Plays.Should().Be(1);
                episodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                episodes[1].Should().NotBeNull();
                episodes[1].Number.Should().Be(2);
                episodes[1].Plays.Should().Be(1);
                episodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowSeasons[1].Should().NotBeNull();
                watchedShowSeasons[1].Number.Should().Be(2);
                watchedShowSeasons[1].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadArrayAsync(default(Stream));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSeasonWatchedProgress = await jsonReader.ReadArrayAsync(stream);
                traktSeasonWatchedProgress.Should().BeNull();
            }
        }
    }
}
