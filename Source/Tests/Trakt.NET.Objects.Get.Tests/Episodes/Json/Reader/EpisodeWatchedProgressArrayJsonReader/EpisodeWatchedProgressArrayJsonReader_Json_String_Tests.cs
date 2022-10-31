namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [TestCategory("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeWatchedProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktEpisodeWatchedProgresses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
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

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();
            Func<Task<IEnumerable<ITraktEpisodeWatchedProgress>>> traktEpisodeWatchedProgress = () => jsonReader.ReadArrayAsync(default(string));
            await traktEpisodeWatchedProgress.Should().ThrowAsync<ArgumentNullException>();
        }

        [Fact]
        public async Task Test_EpisodeWatchedProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeWatchedProgress>();

            var traktEpisodeWatchedProgress = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeWatchedProgress.Should().BeNull();
        }
    }
}
