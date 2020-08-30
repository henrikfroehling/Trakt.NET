namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Complete()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public void Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Null()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();
            Func<Task<ITraktWatchedShowEpisode>> traktWatchedShowEpisode = () => traktJsonReader.ReadObjectAsync(default(JsonTextReader));
            traktWatchedShowEpisode.Should().Throw<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_JsonReader_Empty()
        {
            var traktJsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisode = await traktJsonReader.ReadObjectAsync(jsonReader);
                traktWatchedShowEpisode.Should().BeNull();
            }
        }
    }
}
