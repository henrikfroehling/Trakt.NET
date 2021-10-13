namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().BeNull();
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().BeNull();
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().BeNull();
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().BeNull();

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().BeNull();

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().BeNull();
            watchedProgresses[0].Completed.Should().BeNull();
            watchedProgresses[0].Episodes.Should().BeNull();

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().BeNull();
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().BeNull();
            watchedProgresses[1].Episodes.Should().BeNull();

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_7);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().BeNull();
            watchedProgresses[2].Aired.Should().BeNull();
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_8);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().BeNull();
            watchedProgresses[0].Aired.Should().BeNull();
            watchedProgresses[0].Completed.Should().BeNull();
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().BeNull();
            watchedProgresses[1].Aired.Should().BeNull();
            watchedProgresses[1].Completed.Should().BeNull();
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().BeNull();
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().BeNull();
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().BeNull();
            watchedProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[2].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().Be(1);
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().Be(3);
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().Be(2);
            watchedProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_5);
            traktSeasonWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var watchedProgresses = traktSeasonWatchedProgresses.ToArray();

            watchedProgresses[0].Number.Should().BeNull();
            watchedProgresses[0].Aired.Should().Be(3);
            watchedProgresses[0].Completed.Should().Be(2);
            watchedProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = watchedProgresses[0].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[1].Number.Should().Be(2);
            watchedProgresses[1].Aired.Should().BeNull();
            watchedProgresses[1].Completed.Should().Be(2);
            watchedProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesWatchedProgress = watchedProgresses[1].Episodes.ToArray();

            episodesWatchedProgress[0].Should().NotBeNull();
            episodesWatchedProgress[0].Number.Should().Be(1);
            episodesWatchedProgress[0].Completed.Should().BeTrue();
            episodesWatchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesWatchedProgress[1].Should().NotBeNull();
            episodesWatchedProgress[1].Number.Should().Be(2);
            episodesWatchedProgress[1].Completed.Should().BeTrue();
            episodesWatchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            watchedProgresses[2].Number.Should().Be(3);
            watchedProgresses[2].Aired.Should().Be(3);
            watchedProgresses[2].Completed.Should().BeNull();
            watchedProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();
            Func<Task<IEnumerable<ITraktSeasonWatchedProgress>>> traktSeasonWatchedProgresses = () => jsonReader.ReadArrayAsync(default(string));
            await traktSeasonWatchedProgresses.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktSeasonWatchedProgress>();

            var traktSeasonWatchedProgresses = await jsonReader.ReadArrayAsync(string.Empty);
            traktSeasonWatchedProgresses.Should().BeNull();
        }
    }
}
