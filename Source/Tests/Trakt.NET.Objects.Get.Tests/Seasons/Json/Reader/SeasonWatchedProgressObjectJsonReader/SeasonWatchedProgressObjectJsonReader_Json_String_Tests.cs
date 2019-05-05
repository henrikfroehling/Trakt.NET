namespace TraktNet.Objects.Get.Tests.Seasons.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Seasons.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_7()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_7);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_8()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_8);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().NotBeNull().And.HaveCount(2);

            var episodesWatchedProgress = traktSeasonWatchedProgress.Episodes.ToArray();

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
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().Be(2);
            traktSeasonWatchedProgress.Aired.Should().Be(3);
            traktSeasonWatchedProgress.Completed.Should().Be(2);
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_5()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_5);

            traktSeasonWatchedProgress.Should().NotBeNull();
            traktSeasonWatchedProgress.Number.Should().BeNull();
            traktSeasonWatchedProgress.Aired.Should().BeNull();
            traktSeasonWatchedProgress.Completed.Should().BeNull();
            traktSeasonWatchedProgress.Episodes.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(default(string));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await jsonReader.ReadObjectAsync(string.Empty);
            traktSeasonWatchedProgress.Should().BeNull();
        }
    }
}
