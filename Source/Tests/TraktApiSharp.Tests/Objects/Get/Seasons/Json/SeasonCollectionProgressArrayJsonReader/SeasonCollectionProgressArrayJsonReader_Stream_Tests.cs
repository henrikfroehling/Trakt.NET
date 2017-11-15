namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Empty_Array()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_EMPTY_ARRAY.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonCollectionProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Complete()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_7()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_7.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Incomplete_8()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_INCOMPLETE_8.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Not_Valid_5()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = JSON_NOT_VALID_5.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
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
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Null()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(default(Stream));
            traktSeasonCollectionProgresses.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressArrayJsonReader_ReadArray_From_Stream_Empty()
        {
            var traktJsonReader = new SeasonCollectionProgressArrayJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktSeasonCollectionProgresses = await traktJsonReader.ReadArrayAsync(stream);
                traktSeasonCollectionProgresses.Should().BeNull();
            }
        }
    }
}
