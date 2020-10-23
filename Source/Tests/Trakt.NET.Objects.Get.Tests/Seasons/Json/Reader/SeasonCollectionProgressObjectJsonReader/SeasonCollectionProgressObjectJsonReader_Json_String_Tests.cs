namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesCollectionProgress = traktSeasonCollectionProgress.Episodes.ToArray();

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
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().Be(2);
            traktSeasonCollectionProgress.Aired.Should().Be(3);
            traktSeasonCollectionProgress.Completed.Should().Be(2);
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktSeasonCollectionProgress.Should().NotBeNull();
            traktSeasonCollectionProgress.Number.Should().BeNull();
            traktSeasonCollectionProgress.Aired.Should().BeNull();
            traktSeasonCollectionProgress.Completed.Should().BeNull();
            traktSeasonCollectionProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public void Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();
            Func<Task<ITraktSeasonCollectionProgress>> traktSeasonCollectionProgress = () => jsonReader.ReadObjectAsync(default(string));
            traktSeasonCollectionProgress.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_SeasonCollectionProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(string.Empty);
            traktSeasonCollectionProgress.Should().BeNull();
        }
    }
}
