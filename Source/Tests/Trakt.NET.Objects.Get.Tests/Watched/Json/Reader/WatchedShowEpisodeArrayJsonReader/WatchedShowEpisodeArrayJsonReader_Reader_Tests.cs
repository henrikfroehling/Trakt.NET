namespace TraktNet.Objects.Get.Tests.Watched.Json.Reader
{
    using FluentAssertions;
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Watched;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Watched.JsonReader")]
    public partial class WatchedShowEpisodeArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty_Array()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_EMPTY_ARRAY))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.BeEmpty();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Complete()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_COMPLETE))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().BeNull();
                watchedShowEpisodes[0].LastWatchedAt.Should().BeNull();

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_5()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_5))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().BeNull();
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().BeNull();

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Incomplete_6()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_INCOMPLETE_6))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().BeNull();
                watchedShowEpisodes[2].Plays.Should().BeNull();
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_1()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_NOT_VALID_1))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_2()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_NOT_VALID_2))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_3()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_NOT_VALID_3))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().Be(1);
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().Be(1);
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Not_Valid_4()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(JSON_NOT_VALID_4))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktWatchedShowEpisodes = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktWatchedShowEpisodes.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

                var watchedShowEpisodes = traktWatchedShowEpisodes.ToArray();

                watchedShowEpisodes[0].Should().NotBeNull();
                watchedShowEpisodes[0].Number.Should().BeNull();
                watchedShowEpisodes[0].Plays.Should().Be(1);
                watchedShowEpisodes[0].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[1].Should().NotBeNull();
                watchedShowEpisodes[1].Number.Should().Be(2);
                watchedShowEpisodes[1].Plays.Should().BeNull();
                watchedShowEpisodes[1].LastWatchedAt.Should().Be(DateTime.Parse("2014-10-12T17:00:54.000Z").ToUniversalTime());

                watchedShowEpisodes[2].Should().NotBeNull();
                watchedShowEpisodes[2].Number.Should().Be(3);
                watchedShowEpisodes[2].Plays.Should().Be(1);
                watchedShowEpisodes[2].LastWatchedAt.Should().BeNull();
            }
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Null()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();
            Func<Task<IList<ITraktWatchedShowEpisode>>> traktEpisodeWatchedProgress = () => traktJsonReader.ReadArrayAsync(default(JsonTextReader));
            await traktEpisodeWatchedProgress.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_WatchedShowEpisodeArrayJsonReader_ReadArray_From_JsonReader_Empty()
        {
            var traktJsonReader = new ArrayJsonReader<ITraktWatchedShowEpisode>();

            using (var reader = new StringReader(string.Empty))
            using (var jsonReader = new JsonTextReader(reader))
            {
                var traktEpisodeWatchedProgress = await traktJsonReader.ReadArrayAsync(jsonReader);
                traktEpisodeWatchedProgress.Should().BeNull();
            }
        }
    }
}
