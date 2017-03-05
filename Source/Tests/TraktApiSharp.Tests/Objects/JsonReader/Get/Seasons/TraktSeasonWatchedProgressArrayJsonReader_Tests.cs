namespace TraktApiSharp.Tests.Objects.JsonReader.Get.Seasons
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.JsonReader;
    using TraktApiSharp.Objects.JsonReader.Get.Seasons;
    using Xunit;

    [Category("Objects.JsonReader.Get.Seasons")]
    public class TraktSeasonWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(TraktSeasonWatchedProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<TraktSeasonWatchedProgress>));
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_COMPLETE);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_1);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_2);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_3);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_4);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_5);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_6);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_7()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_7);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_8()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_INCOMPLETE_8);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_NOT_VALID_1);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_NOT_VALID_2);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_NOT_VALID_3);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_NOT_VALID_4);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(JSON_NOT_VALID_5);
            traktSeasonWatchedProgresses.Should().NotBeNull();

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
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(default(string));
            traktSeasonWatchedProgresses.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(string.Empty);
            traktSeasonWatchedProgresses.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().NotBeNull();

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
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var jsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            var traktSeasonWatchedProgresses = jsonReader.ReadArray(default(JsonTextReader));
            traktSeasonWatchedProgresses.Should().BeNull();
        }

        [Fact]
        public void Test_TraktSeasonWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new TraktSeasonWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgresses = traktJsonReader.ReadArray(jsonReader);
                traktSeasonWatchedProgresses.Should().BeNull();
            }
        }

        private const string JSON_COMPLETE =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_1 =
            @"[
                {
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_2 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_3 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_4 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_5 =
            @"[
                {
                  ""number"": 1
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_6 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""aired"": 3
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_INCOMPLETE_7 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""completed"": 2
                }
              ]";

        private const string JSON_INCOMPLETE_8 =
            @"[
                {
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_1 =
            @"[
                {
                  ""nu"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_2 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""ai"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_3 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""com"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_4 =
            @"[
                {
                  ""number"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""ep"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";

        private const string JSON_NOT_VALID_5 =
            @"[
                {
                  ""nu"": 1,
                  ""aired"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 2,
                  ""ai"": 3,
                  ""completed"": 2,
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""number"": 3,
                  ""aired"": 3,
                  ""com"": 2,
                  ""ep"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""last_watched_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";
    }
}
