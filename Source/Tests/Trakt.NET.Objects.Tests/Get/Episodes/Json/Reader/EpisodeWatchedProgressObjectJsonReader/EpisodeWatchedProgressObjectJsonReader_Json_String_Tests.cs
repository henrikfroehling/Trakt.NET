namespace TraktNet.Objects.Tests.Get.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Complete()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_COMPLETE);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_1()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_1);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_2()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_2);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_3()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_3);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_4()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_4);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_5()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_5);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Incomplete_6()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_INCOMPLETE_6);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_1);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_2);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_3);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().Be(2);
            traktEpisodeWatchedProgress.Completed.Should().BeTrue();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(JSON_NOT_VALID_4);

            traktEpisodeWatchedProgress.Should().NotBeNull();
            traktEpisodeWatchedProgress.Number.Should().BeNull();
            traktEpisodeWatchedProgress.Completed.Should().BeNull();
            traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Null()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(default(string));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Json_String_Empty()
        {
            var jsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await jsonReader.ReadObjectAsync(string.Empty);
            traktEpisodeWatchedProgress.Should().BeNull();
        }
    }
}
