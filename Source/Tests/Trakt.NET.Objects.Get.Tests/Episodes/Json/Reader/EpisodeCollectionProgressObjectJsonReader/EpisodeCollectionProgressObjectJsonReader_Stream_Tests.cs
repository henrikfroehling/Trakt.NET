namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.IO;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeCollectionProgressObjectJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Complete()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_COMPLETE.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_1()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_1.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_2()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_2.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_3()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_3.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_4()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_4.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_5()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_5.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Incomplete_6()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_INCOMPLETE_6.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_1.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_2.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_3.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().Be(2);
                traktEpisodeCollectionProgress.Completed.Should().BeTrue();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = JSON_NOT_VALID_4.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);

                traktEpisodeCollectionProgress.Should().NotBeNull();
                traktEpisodeCollectionProgress.Number.Should().BeNull();
                traktEpisodeCollectionProgress.Completed.Should().BeNull();
                traktEpisodeCollectionProgress.CollectedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Null()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(default(Stream));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressObjectJsonReader_ReadObject_From_Stream_Empty()
        {
            var traktJsonReader = new EpisodeCollectionProgressObjectJsonReader();

            using (var stream = string.Empty.ToStream())
            {
                var traktEpisodeCollectionProgress = await traktJsonReader.ReadObjectAsync(stream);
                traktEpisodeCollectionProgress.Should().BeNull();
            }
        }
    }
}
