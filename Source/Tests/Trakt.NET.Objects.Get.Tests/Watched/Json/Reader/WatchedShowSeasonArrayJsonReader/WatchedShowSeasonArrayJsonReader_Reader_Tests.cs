namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowSeasons.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowSeasons = await traktJsonReader.ReadArrayAsync(jsonReader);
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
        public void Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();
            Func<Task<IEnumerable<ITraktWatchedShowSeason>>> traktSeasonWatchedProgress = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktSeasonWatchedProgress.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowSeason>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonWatchedProgress.Should().BeNull();
            }
        }
    }
}
