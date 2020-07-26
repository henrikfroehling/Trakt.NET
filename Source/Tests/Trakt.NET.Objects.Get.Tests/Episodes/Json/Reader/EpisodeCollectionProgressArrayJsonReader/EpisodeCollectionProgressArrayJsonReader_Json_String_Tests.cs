namespace TraktNet.Objects.Get.Tests.Episodes.Json.Reader
{
    using FluentAssertions;
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Trakt.NET.Tests.Utility.Traits;
    using TraktNet.Objects.Get.Episodes;
    using TraktNet.Objects.Json;
    using Xunit;

    [Category("Objects.Get.Episodes.JsonReader")]
    public partial class EpisodeCollectionProgressArrayJsonReader_Tests
    {
        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty_Array()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_EMPTY_ARRAY);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.BeEmpty();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Complete()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_COMPLETE);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_1);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_2);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_3);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_4);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeNull();
            collectionProgress[0].CollectedAt.Should().BeNull();

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_5()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_5);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().BeNull();
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().BeNull();

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Incomplete_6()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_INCOMPLETE_6);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().BeNull();
            collectionProgress[2].Completed.Should().BeNull();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_1()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_1);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_2()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_2);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_3()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_3);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().Be(1);
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeTrue();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Not_Valid_4()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgresses = await jsonReader.ReadArrayAsync(JSON_NOT_VALID_4);
            traktEpisodeCollectionProgresses.Should().NotBeNull().And.NotBeEmpty().And.HaveCount(3);

            var collectionProgress = traktEpisodeCollectionProgresses.ToArray();

            collectionProgress[0].Number.Should().BeNull();
            collectionProgress[0].Completed.Should().BeTrue();
            collectionProgress[0].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[1].Number.Should().Be(2);
            collectionProgress[1].Completed.Should().BeNull();
            collectionProgress[1].CollectedAt.Should().Be(DateTime.Parse("2011-04-18T01:00:00.000Z").ToUniversalTime());

            collectionProgress[2].Number.Should().Be(3);
            collectionProgress[2].Completed.Should().BeTrue();
            collectionProgress[2].CollectedAt.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Null()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(default(string));
            traktEpisodeCollectionProgress.Should().BeNull();
        }

        [Fact]
        public async Task Test_EpisodeCollectionProgressArrayJsonReader_ReadArray_From_Json_String_Empty()
        {
            var jsonReader = new ArrayJsonReader<ITraktEpisodeCollectionProgress>();

            var traktEpisodeCollectionProgress = await jsonReader.ReadArrayAsync(string.Empty);
            traktEpisodeCollectionProgress.Should().BeNull();
        }
    }
}
