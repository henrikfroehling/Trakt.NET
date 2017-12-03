namespace TraktApiSharp.Tests.Objects.Get.Watched.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktApiSharp.Objects.Get.Watched.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().Be(1);
                traktWatchedShowEpisode.Plays.Should().Be(1);
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);

                traktWatchedShowEpisode.Should().NotBeNull();
                traktWatchedShowEpisode.Number.Should().BeNull();
                traktWatchedShowEpisode.Plays.Should().BeNull();
                traktWatchedShowEpisode.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(default(Stream));
            traktWatchedShowEpisode.Should().BeNull();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var jsonReader = new WatchedShowEpisodeObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktWatchedShowEpisode = await jsonReader.ReadObjectAsync(stream);
                traktWatchedShowEpisode.Should().BeNull();
            }
        }
    }
}
