namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using TraktApiSharp.Objects.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public class ITraktSeasonCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public void Test_ITraktSeasonCollectionProgressArrayJsonReader_Implements_ITraktArrayJsonReader_Interface()
        {
            typeof(ITraktSeasonCollectionProgressArrayJsonReader).GetInterfaces().Should().Contain(typeof(ITraktArrayJsonReader<ITraktSeasonCollectionProgress>));
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().BeNull();
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().BeNull();
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().BeNull();
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().BeNull();

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().BeNull();

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().BeNull();
            collectionProgresses[0].Completed.Should().BeNull();
            collectionProgresses[0].Episodes.Should().BeNull();

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().BeNull();
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().BeNull();
            collectionProgresses[1].Episodes.Should().BeNull();

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_7()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_7);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().BeNull();
            collectionProgresses[2].Aired.Should().BeNull();
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_8()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_8);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().BeNull();
            collectionProgresses[0].Aired.Should().BeNull();
            collectionProgresses[0].Completed.Should().BeNull();
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().BeNull();
            collectionProgresses[1].Aired.Should().BeNull();
            collectionProgresses[1].Completed.Should().BeNull();
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().BeNull();
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().BeNull();
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().BeNull();
            collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().Be(1);
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().Be(3);
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().Be(2);
            collectionProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_5);
            traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

            collectionProgresses[0].Number.Should().BeNull();
            collectionProgresses[0].Aired.Should().Be(3);
            collectionProgresses[0].Completed.Should().Be(2);
            collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[1].Number.Should().Be(2);
            collectionProgresses[1].Aired.Should().BeNull();
            collectionProgresses[1].Completed.Should().Be(2);
            collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

            episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

            episodesCollectionProgress[0].Should().NotBeNull();
            episodesCollectionProgress[0].Number.Should().Be(1);
            episodesCollectionProgress[0].Completed.Should().BeTrue();
            episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            episodesCollectionProgress[1].Should().NotBeNull();
            episodesCollectionProgress[1].Number.Should().Be(2);
            episodesCollectionProgress[1].Completed.Should().BeTrue();
            episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

            // -----------------------------------------------

            collectionProgresses[2].Number.Should().Be(3);
            collectionProgresses[2].Aired.Should().Be(3);
            collectionProgresses[2].Completed.Should().BeNull();
            collectionProgresses[2].Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(default(string));
            traktSeasonCollectionProgresses.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(string.Empty);
            traktSeasonCollectionProgresses.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().BeNull();
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().BeNull();
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().BeNull();
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().BeNull();

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().BeNull();

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().BeNull();
                collectionProgresses[0].Completed.Should().BeNull();
                collectionProgresses[0].Episodes.Should().BeNull();

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().BeNull();
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().BeNull();
                collectionProgresses[1].Episodes.Should().BeNull();

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().BeNull();
                collectionProgresses[2].Aired.Should().BeNull();
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().BeNull();
                collectionProgresses[0].Aired.Should().BeNull();
                collectionProgresses[0].Completed.Should().BeNull();
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().BeNull();
                collectionProgresses[1].Aired.Should().BeNull();
                collectionProgresses[1].Completed.Should().BeNull();
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().BeNull();
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().BeNull();
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().BeNull();
                collectionProgresses[2].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[2].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().Be(1);
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().Be(3);
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().Be(2);
                collectionProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var collectionProgresses = traktSeasonCollectionProgresses.ToArray();

                collectionProgresses[0].Number.Should().BeNull();
                collectionProgresses[0].Aired.Should().Be(3);
                collectionProgresses[0].Completed.Should().Be(2);
                collectionProgresses[0].Episodes.Should().NotBeNull().And.HaveCount(2);

                var episodesCollectionProgress = collectionProgresses[0].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[1].Number.Should().Be(2);
                collectionProgresses[1].Aired.Should().BeNull();
                collectionProgresses[1].Completed.Should().Be(2);
                collectionProgresses[1].Episodes.Should().NotBeNull().And.HaveCount(2);

                episodesCollectionProgress = collectionProgresses[1].Episodes.ToArray();

                episodesCollectionProgress[0].Should().NotBeNull();
                episodesCollectionProgress[0].Number.Should().Be(1);
                episodesCollectionProgress[0].Completed.Should().BeTrue();
                episodesCollectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                episodesCollectionProgress[1].Should().NotBeNull();
                episodesCollectionProgress[1].Number.Should().Be(2);
                episodesCollectionProgress[1].Completed.Should().BeTrue();
                episodesCollectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-19T02:00:00.000Z").ToUniversalTime());

                // -----------------------------------------------

                collectionProgresses[2].Number.Should().Be(3);
                collectionProgresses[2].Aired.Should().Be(3);
                collectionProgresses[2].Completed.Should().BeNull();
                collectionProgresses[2].Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await jsonReader.ReadArrayAsync(default(JsonTextReader));
            traktSeasonCollectionProgresses.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktSeasonCollectionProgresses.Should().BeNull();
            }
        }

        private const string JSON_EMPTY_ARRAY = @"[]";

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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                },
                {
                  ""episodes"": [
                    {
                      ""number"": 1,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
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
                      ""collected_at"": ""2011-04-18T01:00:00.000Z""
                    },
                    {
                      ""number"": 2,
                      ""completed"": true,
                      ""collected_at"": ""2011-04-19T02:00:00.000Z""
                    }
                  ]
                }
              ]";
    }
}
