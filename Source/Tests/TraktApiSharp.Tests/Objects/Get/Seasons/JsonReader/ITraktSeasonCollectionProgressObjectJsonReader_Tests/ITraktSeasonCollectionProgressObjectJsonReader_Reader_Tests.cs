namespace TraktApiSharp.Tests.Objects.Get.Seasons.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Seasons.JsonReader;
    using Xunit;

    [Category("Objects.Get.Seasons.JsonReader")]
    public partial class ITraktSeasonCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_7()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_7))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_8()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_8))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

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
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().Be(2);
                traktSeasonCollectionProgress.Aired.Should().Be(3);
                traktSeasonCollectionProgress.Completed.Should().Be(2);
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_5()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktSeasonCollectionProgress.Should().NotBeNull();
                traktSeasonCollectionProgress.Number.Should().BeNull();
                traktSeasonCollectionProgress.Aired.Should().BeNull();
                traktSeasonCollectionProgress.Completed.Should().BeNull();
                traktSeasonCollectionProgress.Episodes.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            var traktSeasonCollectionProgress = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktSeasonCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktSeasonCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktSeasonCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktSeasonCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktSeasonCollectionProgress.Should().BeNull();
            }
        }
    }
}
