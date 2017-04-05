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
    public partial class ITraktEpisodeWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var jsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(default(JsonTextReader));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_ITraktEpisodeWatchedProgressObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new ITraktEpisodeWatchedProgressObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }
    }
}
