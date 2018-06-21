namespace TraktNet.Tests.Objects.Get.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using TestUtils;
    using Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().Be(2);
                traktEpisodeWatchedProgress.Completed.Should().BeTrue();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeWatchedProgress.Should().NotBeNull();
                traktEpisodeWatchedProgress.Number.Should().BeNull();
                traktEpisodeWatchedProgress.Completed.Should().BeNull();
                traktEpisodeWatchedProgress.LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new EpisodeWatchedProgressObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadObjectAsync(stream);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }
    }
}
