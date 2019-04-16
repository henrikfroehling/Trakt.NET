﻿namespace TraktNet.Objects.Tests.Get.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowSeasonArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktWatchedShowSeasons.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktWatchedShowSeasons = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
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

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadArrayAsync(default(string));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowSeasonArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new WatchedShowSeasonArrayJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadArrayAsync(string.Empty);
            traktSeasonWatchedProgress.Should().BeNull();
        }
    }
}
