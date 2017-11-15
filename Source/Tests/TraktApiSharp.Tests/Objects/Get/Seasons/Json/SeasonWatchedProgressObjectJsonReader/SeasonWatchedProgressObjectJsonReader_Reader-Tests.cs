namespace TraktApiSharp.Tests.Objects.Get.Seasons.Json
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons.Json;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class SeasonWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().Be(2);
                traktSeasonWatchedProgress.Aired.Should().Be(3);
                traktSeasonWatchedProgress.Completed.Should().Be(2);
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonWatchedProgress.Should().NotBeNull();
                traktSeasonWatchedProgress.Number.Should().BeNull();
                traktSeasonWatchedProgress.Aired.Should().BeNull();
                traktSeasonWatchedProgress.Completed.Should().BeNull();
                traktSeasonWatchedProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSeasonWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_SeasonWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new SeasonWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSeasonWatchedProgress.Should().BeNull();
            }
        }
    }
}
