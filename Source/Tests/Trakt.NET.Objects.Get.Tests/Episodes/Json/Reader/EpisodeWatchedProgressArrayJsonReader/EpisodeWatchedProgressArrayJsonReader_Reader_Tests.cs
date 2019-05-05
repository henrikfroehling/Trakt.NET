namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes.Json.Reader;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().BeNull();
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeNull();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeNull();
                watchedProgress[0].LastWatchedAt.Should().BeNull();

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().BeNull();
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().BeNull();

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().BeNull();
                watchedProgress[2].Completed.Should().BeNull();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().BeNull();
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeNull();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().Be(1);
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeTrue();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgresses = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedProgress = traktEpisodeWatchedProgresses.ToArray();

                watchedProgress[0].Number.Should().BeNull();
                watchedProgress[0].Completed.Should().BeTrue();
                watchedProgress[0].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[1].Number.Should().Be(2);
                watchedProgress[1].Completed.Should().BeNull();
                watchedProgress[1].LastWatchedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

                watchedProgress[2].Number.Should().Be(3);
                watchedProgress[2].Completed.Should().BeTrue();
                watchedProgress[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            var traktEpisodeWatchedProgress = await traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            traktEpisodeWatchedProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new EpisodeWatchedProgressArrayJsonReader();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }
    }
}
