namespace TraktApiSharp.Tests.Objects.Get.Episodes.JsonReader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Traits;
    using TraktApiSharp.Objects.Get.Episodes.JsonReader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class ITraktEpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeCollectionProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeCollectionProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}
